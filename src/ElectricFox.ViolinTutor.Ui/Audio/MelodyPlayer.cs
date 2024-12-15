using ElectricFox.ViolinTutor.Code;
using NAudio.Wave;

namespace ElectricFox.ViolinTutor.Ui.Audio
{
    public class MelodyPlayer : IDisposable
    {
        private readonly WaveOutEvent outputDevice;

        private readonly SineWaveProvider32 waveProvider;

        private Thread? melodyThread;

        private readonly CancellationTokenSource cancellationTokenSource = new();

        private bool isPlaying;
        private bool disposedValue;
        private readonly object playbackLock = new();

        public event Action PlayingItemChanged;

        public MelodyPlayer()
        {
            outputDevice = new WaveOutEvent();
            waveProvider = new SineWaveProvider32();
            outputDevice.Init(waveProvider);
        }

        public NotationItem? PlayingItem
        {
            get; set;
        }

        public void Start(Melody melody)
        {
            lock (playbackLock)
            {
                if (isPlaying)
                {
                    Stop();
                }

                var token = cancellationTokenSource.Token;

                var start = new ThreadStart(() => PlayMelody(melody, token));
                melodyThread = new Thread(start);
                melodyThread.Start();
            }
        }

        public void Stop()
        {
            lock (playbackLock)
            {
                cancellationTokenSource.Cancel();
                melodyThread?.Join();
                melodyThread = null;
            }
        }

        private void PlayMelody(Melody melody, CancellationToken token)
        {
            isPlaying = true;

            var tempoMs = 60000 / melody.Tempo;
            foreach (var item in melody.Items)
            {
                if (token.IsCancellationRequested)
                {
                    isPlaying = false;
                    return;
                }

                PlayingItem = item;
                PlayingItemChanged?.Invoke();

                if (item is IPlayable playable)
                {
                    var lengthMs = (int)(tempoMs * playable.Length);

                    if (item is Rest)
                    {
                        WaitForCancellation(lengthMs, token);
                    }
                    else if (item is PlayableNote note)
                    {
                        waveProvider.SetWave(note.Note.Frequency, 0.5f);

                        outputDevice.Play();
                        WaitForCancellation(lengthMs - 50, token);
                        outputDevice.Stop();

                        WaitForCancellation(50, token);
                    }
                }
            }

            isPlaying = false;
        }

        private void WaitForCancellation(int durationMs, CancellationToken token)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds < durationMs)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                Thread.Sleep(1); // Small sleep to prevent busy-waiting
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Stop();
                    outputDevice.Dispose();
                    cancellationTokenSource.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
