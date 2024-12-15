using ElectricFox.ViolinTutor.Code;

namespace ElectricFox.ViolinTutor.Ui.Rendering
{
    public class RestRenderer : IRenderer<Rest>
    {
        public Rectangle Render(Graphics g, Point p, Rest item, Melody melody)
        {
            var middleY = p.Y + (2 * Constants.StaveSpacing);
            var midPoint = new Point(p.X, middleY);

            switch (item.Length)
            {
                case 1:
                    return g.DrawWholeRest(midPoint, item.IsSelected, item.IsPlaying);
                case 0.5m:
                    return g.DrawHalfRest(midPoint, item.IsSelected, item.IsPlaying);
                case 0.25m:
                    return g.DrawQuaterRest(midPoint, item.IsSelected, item.IsPlaying);
                case 0.125m:
                    return g.DrawEighthNoteRest(midPoint, item.IsSelected, item.IsPlaying);
                case 0.2625m:
                    return g.DrawSixteenthNoteRest(midPoint, item.IsSelected, item.IsPlaying);
            }

            return new Rectangle();
        }
    }
}
