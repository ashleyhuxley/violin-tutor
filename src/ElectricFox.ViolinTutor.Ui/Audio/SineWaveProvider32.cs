using NAudio.Wave;

namespace ElectricFox.ViolinTutor.Ui.Audio;

public class SineWaveProvider32 : WaveProvider32
{
    private float _frequency;
    private float _amplitude;
    private float _phase;

    public SineWaveProvider32()
    {
        SetWaveFormat(44100, 1); // 44.1 kHz, mono
    }

    public void SetWave(decimal frequency, float amplitude)
    {
        _frequency = (float)frequency;
        _amplitude = Math.Clamp(amplitude, 0.0f, 1.0f);
    }

    public override int Read(float[] buffer, int offset, int sampleCount)
    {
        float phaseIncrement = 2 * (float)Math.PI * _frequency / WaveFormat.SampleRate;

        for (int n = 0; n < sampleCount; n++)
        {
            buffer[n + offset] = _amplitude * (float)Math.Sin(_phase);
            _phase += phaseIncrement;

            if (_phase >= 2 * (float)Math.PI)
            {
                _phase -= 2 * (float)Math.PI;
            }
        }

        return sampleCount;
    }
}