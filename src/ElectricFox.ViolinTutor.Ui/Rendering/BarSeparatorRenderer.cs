using ElectricFox.ViolinTutor.Code;

namespace ElectricFox.ViolinTutor.Ui.Rendering
{
    public class BarSeparatorRenderer : IRenderer<BarSeparator>
    {
        public Rectangle Render(Graphics g, Point p, BarSeparator item, Melody melody)
        {
            var height = (4 * Constants.StaveSpacing);
            g.DrawLine(Assets.BarLine(item.IsSelected, false), p.X + 5, p.Y, p.X + 5, p.Y + height);
            return new Rectangle(p.X, p.Y, 10, height);
        }
    }
}
