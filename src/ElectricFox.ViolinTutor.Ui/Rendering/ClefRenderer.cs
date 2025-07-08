using System.Reflection;
using ElectricFox.ViolinTutor.Code;

namespace ElectricFox.ViolinTutor.Ui.Rendering
{
    public class ClefRenderer : IRenderer<Clef>
    {
        public Rectangle Render(Graphics g, Point p, Clef item, Melody melody)
        {
            Size size;

            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("ElectricFox.ViolinTutor.Ui.Resources.treble-clef.png"))
            using (var image = Image.FromStream(stream))
            {
                g.DrawImage(image, p);
                g.ResetTransform();
                size = image.Size;
            }

            return new Rectangle(p, size);
        }
    }
}
