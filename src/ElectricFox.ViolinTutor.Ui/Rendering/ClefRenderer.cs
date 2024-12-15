using ElectricFox.ViolinTutor.Code;

namespace ElectricFox.ViolinTutor.Ui.Rendering
{
    public class ClefRenderer
    {
        public Rectangle Render(Graphics g, Point p)
        {
            Size size;

            using (var image = Image.FromFile("D:\\code\\me\\violin-tutor\\treble-clef.png"))
            {
                g.DrawImage(image, p);
                g.ResetTransform();
                size = image.Size;
            }

            return new Rectangle(p, size);
        }
    }
}
