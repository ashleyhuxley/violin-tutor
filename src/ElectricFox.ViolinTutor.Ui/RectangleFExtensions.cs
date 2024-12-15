namespace ElectricFox.ViolinTutor.Ui
{
    public static class RectangleFExtensions
    {
        public static Rectangle ToRectangle(this RectangleF rect)
        {
            return new Rectangle(
                Convert.ToInt32(rect.X),
                Convert.ToInt32(rect.Y),
                Convert.ToInt32(rect.Width),
                Convert.ToInt32(rect.Height));
        }
    }
}
