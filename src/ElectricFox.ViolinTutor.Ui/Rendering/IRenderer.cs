using ElectricFox.ViolinTutor.Code;

namespace ElectricFox.ViolinTutor.Ui.Rendering
{
    public interface IRenderer<in T>
        where T : NotationItem
    {
        Rectangle Render(Graphics g, Point p, T item, Melody melody);
    }

    public interface IRenderer
    {
        Rectangle Render(Graphics g, Point p);
    }
}
