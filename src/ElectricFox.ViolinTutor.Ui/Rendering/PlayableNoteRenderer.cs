using ElectricFox.ViolinTutor.Code;
using System.Windows.Forms;

namespace ElectricFox.ViolinTutor.Ui.Rendering
{
    public class PlayableNoteRenderer : IRenderer<PlayableNote>
    {
        public Rectangle Render(Graphics g, Point p, PlayableNote note, Melody melody)
        {
            var middleY = p.Y + (2 * Constants.StaveSpacing);
            var bNote = new MusicalNote("B", 4);
            var noteOffset = bNote.StavePosition - note.Note.StavePosition;

            var notePoint = new Point(p.X, middleY + (noteOffset * (Constants.StaveSpacing / 2)));

            if (note.Note.StavePosition > (bNote.StavePosition + 5))
            {
                var y = middleY - (Constants.StaveSpacing * 3);
                g.DrawLine(Assets.StaveLine, p.X - 10, y, p.X + 10, y);
            }
            if (note.Note.StavePosition < (bNote.StavePosition - 5))
            {
                var y = middleY + (Constants.StaveSpacing * 3);
                g.DrawLine(Assets.StaveLine, p.X - 10, y, p.X + 10, y);
            }
            if (note.Note.StavePosition < (bNote.StavePosition - 7))
            {
                var y = middleY + (Constants.StaveSpacing * 4);
                g.DrawLine(Assets.StaveLine, p.X - 10, y, p.X + 10, y);
            }

            var calc = new BoundsCalculator();

            switch (note.Length)
            {
                case 1:
                    calc.Add(g.DrawSemibreve(notePoint, note.IsSelected, note.IsPlaying));
                    break;
                case 0.5m:
                    calc.Add(g.DrawMinim(notePoint, note.IsSelected, note.IsPlaying));
                    break;
                case 0.25m:
                    calc.Add(g.DrawCrotchet(notePoint, note.IsSelected, note.IsPlaying));
                    break;
                case 0.125m:
                    calc.Add(g.DrawQuaver(notePoint, note.IsSelected, note.IsPlaying));
                    break;
                case 0.0625m:
                    calc.Add(g.DrawSemiQuaver(notePoint, note.IsSelected, note.IsPlaying));
                    break;
                default:
                    return new Rectangle();
            }

            var x = notePoint.X + 15;

            for (int i = 0; i < note.Dots; i++)
            {
                var rect = g.DrawDot(new Point(x, notePoint.Y), note.IsSelected, note.IsPlaying);
                calc.Add(rect);
                x += rect.Width + 5;
            }

            var expectedAccidental = melody.KeySignature.GetAccidentalForNote(note.Note.Value);
            if (expectedAccidental != note.Note.Accidental)
            {
                calc.Add(g.DrawAccidental(new Point(x, notePoint.Y), note.Note.Accidental, note.IsSelected, note.IsPlaying));
            }

            return calc.Bounds;
        }
    }
}
