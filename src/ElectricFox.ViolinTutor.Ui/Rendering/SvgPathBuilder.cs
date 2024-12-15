using System.Drawing.Drawing2D;

namespace ElectricFox.ViolinTutor.Ui.Rendering
{
    public static class SvgPathBuilder
    {
        public static GraphicsPath Create(string input)
        {
            var path = new GraphicsPath();

            var mPos = input.IndexOf('M');
            var cPos = input.IndexOf('C');

            var initial = input.Substring(mPos + 1, cPos - (mPos + 1))
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var start = new Point(initial[0], initial[1]);

            var remainder = input.Substring(cPos + 1)
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < remainder.Length; i += 6)
            {
                var c1 = new Point(remainder[i], remainder[i + 1]);
                var c2 = new Point(remainder[i + 2], remainder[i + 3]);
                var end = new Point(remainder[i + 4], remainder[i + 5]);

                path.AddBezier(start, c1, c2, end);

                start = end;
            }

            return path;
        }
    }
}
