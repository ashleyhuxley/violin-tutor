using ElectricFox.ViolinTutor.Code;
using ElectricFox.ViolinTutor.Ui.Audio;
using ElectricFox.ViolinTutor.Ui.Rendering;
using System.Diagnostics;

namespace ElectricFox.ViolinTutor.Ui
{
    public partial class MainForm : Form
    {
        private Melody melody;

        private readonly MelodyPlayer player;

        private List<Tuple<Rectangle, MusicalNote>> violinPositions = new();

        public MainForm()
        {
            InitializeComponent();

            RendererFactory.RegisterRenderer(new TimeSignatureRenderer());
            RendererFactory.RegisterRenderer(new BarSeparatorRenderer());
            RendererFactory.RegisterRenderer(new PlayableNoteRenderer());
            RendererFactory.RegisterRenderer(new RestRenderer());
            RendererFactory.RegisterRenderer(new ClefRenderer());

            FillKeySigs();

            player = new MelodyPlayer();
            player.PlayingItemChanged += Player_PlayingItemChanged;

            melody = new Melody("New Melody", 80);
            melody.Items.Add(new Clef());
            melody.Items.Add(new TimeSignature(4, 4));
        }

        private void Player_PlayingItemChanged()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(RefreshView));
            }
            else
            {
                RefreshView();
            }
        }

        private void RefreshView()
        {
            violinLayout.Refresh();
            staveBox.Refresh();
        }

        private void FillKeySigs()
        {
            foreach (var sig in KeySignature.Keys)
            {
                keyDropDown.Items.Add(sig);
            }

            keyDropDown.SelectedIndex = 0;
        }

        private void KeySignatureItemClick(object? sender, EventArgs e)
        {
            var key = keyDropDown.SelectedItem as KeySignature;
            if (key is null || melody is null)
            {
                return;
            }

            melody.KeySignature = key;

            RefreshView();
        }

        private void ViolinLayoutPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            violinPositions.Clear();

            const int margin = 30;

            var width = violinLayout.Width - (margin * 2);
            var height = violinLayout.Height - (margin * 2);

            var totalStringWidth = width / 4;

            var fingerSpace = height / 8;
            var fingerSpacing = fingerSpace / 2;

            // Frets
            var fretY1 = margin + (fingerSpace * 2) + fingerSpacing;
            e.Graphics.DrawLine(Assets.FretLine, margin, fretY1, width + margin, fretY1);
            var fretY2 = margin + (fingerSpace * 4) + fingerSpacing;
            e.Graphics.DrawLine(Assets.FretLine, margin, fretY2, width + margin, fretY2);
            var fretY3 = margin + (fingerSpace * 5) + fingerSpacing;
            e.Graphics.DrawLine(Assets.FretLine, margin, fretY3, width + margin, fretY3);
            var fretY4 = margin + (fingerSpace * 7) + fingerSpacing;
            e.Graphics.DrawLine(Assets.FretLine, margin, fretY4, width + margin, fretY4);

            // Strings
            for (int x = 0; x < 4; x++)
            {
                var posX = margin + (x * totalStringWidth) + (totalStringWidth / 2);
                e.Graphics.DrawLine(Assets.StringPen, posX, margin + (fingerSpace / 2), posX, height + margin);

                // Note Circles
                for (int fingers = 0; fingers < 8; fingers++)
                {
                    var note = GetNote(x, fingers);

                    var posY = margin + (fingerSpace * fingers) + fingerSpacing;
                    var radius = Math.Min((totalStringWidth / 2) - 10, fingerSpacing - 10);

                    var isInKey = melody.KeySignature.IsContained(note);
                    var isSelected = melody.Items.OfType<PlayableNote>().Any(n => n.IsSelected && n.Note == note);

                    var playingNote = player.PlayingItem as PlayableNote;
                    var isPlaying = playingNote is not null && playingNote.Note == note;

                    var rect = e.Graphics.DrawViolinNote(new Point(posX, posY), radius, note, isInKey, isSelected, isPlaying, fingers == 0);

                    violinPositions.Add(new Tuple<Rectangle, MusicalNote>(rect, note));
                }
            }
        }

        private static MusicalNote GetNote(int x, int y)
        {
            switch (x)
            {
                case 0:
                    switch (y)
                    {
                        case 0: return new MusicalNote("G", 3);
                        case 1: return new MusicalNote("G#", 3);
                        case 2: return new MusicalNote("A", 3);
                        case 3: return new MusicalNote("A#", 3);
                        case 4: return new MusicalNote("B", 3);
                        case 5: return new MusicalNote("C", 4);
                        case 6: return new MusicalNote("C#", 4);
                        case 7: return new MusicalNote("D", 4);
                    }
                    break;
                case 1:
                    switch (y)
                    {
                        case 0: return new MusicalNote("D", 4);
                        case 1: return new MusicalNote("D#", 4);
                        case 2: return new MusicalNote("E", 4);
                        case 3: return new MusicalNote("F", 4);
                        case 4: return new MusicalNote("F#", 4);
                        case 5: return new MusicalNote("G", 4);
                        case 6: return new MusicalNote("G#", 4);
                        case 7: return new MusicalNote("A", 4);
                    }
                    break;
                case 2:
                    switch (y)
                    {
                        case 0: return new MusicalNote("A", 4);
                        case 1: return new MusicalNote("A#", 4);
                        case 2: return new MusicalNote("B", 4);
                        case 3: return new MusicalNote("C", 5);
                        case 4: return new MusicalNote("C#", 5);
                        case 5: return new MusicalNote("D", 5);
                        case 6: return new MusicalNote("D#", 5);
                        case 7: return new MusicalNote("E", 5);
                    }
                    break;
                case 3:
                    switch (y)
                    {
                        case 0: return new MusicalNote("E", 5);
                        case 1: return new MusicalNote("F", 5);
                        case 2: return new MusicalNote("F#", 5);
                        case 3: return new MusicalNote("G", 5);
                        case 4: return new MusicalNote("G#", 5);
                        case 5: return new MusicalNote("A", 5);
                        case 6: return new MusicalNote("A#", 5);
                        case 7: return new MusicalNote("B", 5);
                    }
                    break;
            }

            return new MusicalNote("C", 0);
        }

        private void ViolinLayoutResize(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void PlayButtonClick(object sender, EventArgs e)
        {
            player.Start(melody);
        }

        private void StaveBoxPaint(object sender, PaintEventArgs e)
        {
            var width = staveBox.Width - (Constants.StaveMargin * 2);

            int x = Constants.StaveMargin + 10;
            int y = Constants.StaveMargin - 50;

            // Stave Lines
            //for (int i = 0; i < 5; i++)
            //{
            //    int iy = y + (i * Constants.StaveSpacing);
            //    e.Graphics.DrawLine(Assets.StaveLine, Constants.StaveMargin, iy, width + Constants.StaveMargin, iy);
            //}

            //// Draw treble clef
            //var clefRenderer = new ClefRenderer();
            //var clefRect = clefRenderer.Render(e.Graphics, new Point(x, Constants.StaveMargin + 15));
            //x += clefRect.Width + Constants.ItemSpacing;

            //// Draw Key Signature
            //var keyRenderer = new KeySignatureRenderer();
            //var keyRect = keyRenderer.Render(e.Graphics, new Point(x, y), melody.KeySignature, melody);
            //x += keyRect.Width + Constants.ItemSpacing;

            //// Draw time signature
            //var tsRenderer = new TimeSignatureRenderer();
            //var timeSigRect = tsRenderer.Render(e.Graphics, new Point(x, y), melody.TimeSignature, melody);
            //x += timeSigRect.Width + Constants.ItemSpacing;

            // Notation Items
            foreach (var item in melody.Items)
            {
                if (item is Clef)
                {
                    x = Constants.StaveMargin + 10;
                    y += Constants.StaveSpacing * 5 + 50;

                    for (int i = 0; i < 5; i++)
                    {
                        int iy = y + (i * Constants.StaveSpacing);
                        e.Graphics.DrawLine(Assets.StaveLine, Constants.StaveMargin, iy, width + Constants.StaveMargin, iy);
                    }
                }

                var renderer = RendererFactory.GetRenderer(item);
                var rect = renderer.Render(e.Graphics, new Point(x, y), item, melody);
                melody.Bounds[item] = rect;
                x += rect.Width + Constants.ItemSpacing;
            }
        }

        private void BarSeparatorButtonClick(object sender, EventArgs e)
        {
            melody.Items.Add(new BarSeparator());
            RefreshView();
        }

        private void NoteButtonClick(object sender, EventArgs e)
        {
            var length = Convert.ToDecimal(((Button)sender).Tag);

            var selectedNote = melody.Items.FirstOrDefault(i => i.IsSelected) as PlayableNote;

            if (selectedNote is null)
            {
                melody.Items.Add(new PlayableNote(new MusicalNote("B", 4), length));
                RefreshView();
            }
            else
            {
                selectedNote.Length = length;
            }

            RefreshView();
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void StaveBoxMouseDown(object sender, MouseEventArgs e)
        {
            var item = melody.Items.FirstOrDefault(i => melody.Bounds[i].Contains(e.Location));
            melody.Items.ForEach(i => i.IsSelected = false);
            if (item is not null)
            {
                item.IsSelected = true;
            }

            RefreshView();
        }

        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var note = melody.Items.FirstOrDefault(i => i.IsSelected) as PlayableNote;
            if (note is null)
            {
                return;
            }

            int octave;

            if (e.Modifiers == Keys.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        octave = note.Note.Octave - 1;
                        if (octave < 0) return;
                        note.Note = new MusicalNote(note.Note.Name, octave);
                        break;
                    case Keys.Up:
                        octave = note.Note.Octave + 1;
                        if (octave < 0) return;
                        note.Note = new MusicalNote(note.Note.Name, octave);
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        note.Note++;
                        break;
                    case Keys.Up:
                        note.Note--;
                        break;
                }
            }

            RefreshView();
        }

        private void ViolinLayoutMouseDown(object sender, MouseEventArgs e)
        {
            var clickedNote = violinPositions.FirstOrDefault(p => p.Item1.Contains(e.Location));
            if (clickedNote is null)
            {
                return;
            }

            Debug.WriteLine($"{clickedNote.Item2.Name} {clickedNote.Item2.Octave}");

            var selectedNote = melody.Items.FirstOrDefault(i => i.IsSelected) as PlayableNote;

            if (selectedNote is null)
            {
                melody.Items.Add(new PlayableNote(clickedNote.Item2, 0.25m));
            }
            else
            {
                selectedNote.Note = clickedNote.Item2;
            }

            RefreshView();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.melody.Save(saveFileDialog.FileName);
            }
        }

        private void OpenButtonClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.melody = Melody.Load(openFileDialog.FileName);
            }

            RefreshView();
        }

        private void DotButtonClick(object sender, EventArgs e)
        {
            var selectedNote = melody.Items.FirstOrDefault(i => i.IsSelected) as PlayableNote;

            if (selectedNote is null)
            {
                return;
            }

            selectedNote.Dots += 1;
            if (selectedNote.Dots > 3)
            {
                selectedNote.Dots = 0;
            }

            RefreshView();
        }

        private void NewMelodyButtonClick(object sender, EventArgs e)
        {
            this.melody = new Melody("New Melody", 120);
            RefreshView();
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            melody.Items.RemoveAll(i => i.IsSelected);
            RefreshView();
        }

        private void TempoSliderScroll(object sender, EventArgs e)
        {
            melody.Tempo = tempoSlider.Value;
        }

        private void StaveBoxResize(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void RestClick(object sender, EventArgs e)
        {
            var length = Convert.ToDecimal(((Button)sender).Tag);

            var selectedNote = melody.Items.FirstOrDefault(i => i.IsSelected) as PlayableNote;

            if (selectedNote is null)
            {
                melody.Items.Add(new Rest(length));
                RefreshView();
            }
            else
            {
                selectedNote.Length = length;
            }

            RefreshView();
        }

        private void NewLineButtonClick(object sender, EventArgs e)
        {
            this.melody.Items.Add(new Clef());
            RefreshView();
        }
    }
}
