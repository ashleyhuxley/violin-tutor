using ElectricFox.ViolinTutor.Code;

namespace ElectricFox.ViolinTutor.Ui.Rendering
{
    public class KeySignatureRenderer : IRenderer<KeySignature>
    {
        public Rectangle Render(Graphics g, Point p, KeySignature keySig, Melody melody)
        {
            int x = 0;
            var calculator = new BoundsCalculator();

            if (keySig.Sharps.Any())
            {
                foreach (var sharp in keySig.Sharps)
                {
                    var glyphOffset = 'F' - sharp;
                    var rect = g.DrawSharp(new Point(p.X + x, p.Y + (glyphOffset * (Constants.StaveSpacing / 2))), keySig.IsSelected, keySig.IsPlaying);
                    calculator.Add(rect);
                    x += 10;
                }
            }
            else if (keySig.Flats.Any())
            {
                foreach (var flat in keySig.Flats)
                {
                    var glyphOffset = 'F' - flat;
                    var rect = g.DrawFlat(new Point(p.X + x, p.Y + (glyphOffset * (Constants.StaveSpacing / 2))), keySig.IsSelected, keySig.IsPlaying);
                    calculator.Add(rect);
                    x += 10;
                }
            }
            else
            {
                // Special case for C
                var i = melody.Items.IndexOf(keySig) - 1;
                while (i >= 0 && melody.Items[i] is not KeySignature)
                {
                    i--;
                }
                if (i >= 0 && melody.Items[i] is KeySignature previous)
                {
                    foreach (var acc in previous.Flats.Concat(previous.Sharps))
                    {
                        var glyphOffset = 'F' - acc;
                        var rect = g.DrawNeutral(new Point(p.X + x, p.Y + (glyphOffset * (Constants.StaveSpacing / 2))), keySig.IsSelected, keySig.IsPlaying);
                        calculator.Add(rect);
                        x += 10;
                    }
                }
            }

            return calculator.Bounds;
        }
    }
}
