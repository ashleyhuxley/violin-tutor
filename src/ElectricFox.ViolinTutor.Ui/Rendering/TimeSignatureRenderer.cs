using ElectricFox.ViolinTutor.Code;

namespace ElectricFox.ViolinTutor.Ui.Rendering
{
    public class TimeSignatureRenderer : IRenderer<TimeSignature>
    {
        public Rectangle Render(Graphics g, Point p, TimeSignature timeSig, Melody melody)
        {
            var top = timeSig.BeatsPerMeasure.ToString();
            var btm = timeSig.BeatNoteValue.ToString();

            var topSize = g.MeasureString(top, Assets.TimeSignatureFont);
            var btmSize = g.MeasureString(btm, Assets.TimeSignatureFont);

            g.DrawString(top, Assets.TimeSignatureFont, Assets.TimeSignatureBrush, p.X, p.Y - 10);
            g.DrawString(btm, Assets.TimeSignatureFont, Assets.TimeSignatureBrush, p.X, p.Y + 10);

            var calculator = new BoundsCalculator();
            calculator.Add(new Rectangle(p, new Size(Convert.ToInt32(topSize.Width), Convert.ToInt32(topSize.Height))));
            calculator.Add(new Rectangle(new Point(p.X, p.Y + 20), new Size(Convert.ToInt32(btmSize.Width), Convert.ToInt32(btmSize.Height))));
            return calculator.Bounds;
        }
    }
}
