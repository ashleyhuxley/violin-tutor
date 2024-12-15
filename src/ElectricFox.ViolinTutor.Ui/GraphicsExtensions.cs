using ElectricFox.ViolinTutor.Code;
using ElectricFox.ViolinTutor.Ui.Rendering;
using System.Drawing.Drawing2D;

namespace ElectricFox.ViolinTutor.Ui;

public static class GraphicsExtensions
{
    public static Rectangle DrawCircle(this Graphics graphics, Pen pen, Point center, float radius)
    {
        float diameter = radius * 2;
        float upperLeftX = center.X - radius;
        float upperLeftY = center.Y - radius;
        graphics.DrawEllipse(pen, upperLeftX, upperLeftY, diameter, diameter);
        return new Rectangle(
            Convert.ToInt32(upperLeftX),
            Convert.ToInt32(upperLeftY),
            Convert.ToInt32(diameter),
            Convert.ToInt32(diameter));
    }

    public static Rectangle FillCircle(this Graphics graphics, Brush brush, Point center, float radius)
    {
        float diameter = radius * 2;
        float upperLeftX = center.X - radius;
        float upperLeftY = center.Y - radius;
        graphics.FillEllipse(brush, upperLeftX, upperLeftY, diameter, diameter);
        return new Rectangle(
            Convert.ToInt32(upperLeftX),
            Convert.ToInt32(upperLeftY),
            Convert.ToInt32(diameter),
            Convert.ToInt32(diameter));
    }

    public static RectangleF DrawCenteredString(this Graphics graphics, string text, Font font, Brush brush, Point center)
    {
        SizeF textSize = graphics.MeasureString(text, font);

        float x = center.X - (textSize.Width / 2);
        float y = center.Y - (textSize.Height / 2);

        var size = graphics.MeasureString(text, font);

        graphics.DrawString(text, font, brush, x, y);

        return new RectangleF(new PointF(x, y), size);
    }

    public static Rectangle DrawSemibreve(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        return g.DrawCircle(Assets.NotePen(isSelected, isPlaying), p, 5);
    }

    public static Rectangle DrawMinim(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        var calc = new BoundsCalculator(); 
        calc.Add(g.DrawCircle(Assets.NotePen(isSelected, isPlaying), p, 5));
        calc.Add(g.DrawStem(p, isSelected, isPlaying));
        return calc.Bounds;
    }

    public static Rectangle DrawStem(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        g.DrawLine(Assets.NotePen(isSelected, isPlaying), p.X + 5, p.Y, p.X + 5, p.Y - 23);
        return new Rectangle(p.X + 5, p.Y - 23, 1, 23);
    }

    public static Rectangle DrawFlag(this Graphics g, Point p, int offset, bool isSelected, bool isPlaying)
    {
        var start = new Point(p.X + 5, p.Y - 23 + (offset * 4));
        var end = new Point(p.X + 10, start.Y + 4);
        g.DrawLine(Assets.NotePen(isSelected, isPlaying), start, end);

        return new Rectangle(p.X + 5, p.Y - 23, 5, 4);
    }

    public static Rectangle DrawCrotchet(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        var calc = new BoundsCalculator();
        calc.Add(g.FillCircle(Assets.NoteBrush(isSelected, isPlaying), p, 5));
        calc.Add(g.DrawStem(p, isSelected, isPlaying));
        return calc.Bounds;
    }

    public static Rectangle DrawAccidental(this Graphics g, Point p, Accidental accidental, bool isSelected, bool isPlaying)
    {
        switch (accidental)
        {
            case Accidental.Sharp:
                return g.DrawSharp(p, isSelected, isPlaying);
            case Accidental.Flat:
                return g.DrawFlat(p, isSelected, isPlaying);
            case Accidental.Neutral:
                return g.DrawNeutral(p, isSelected, isPlaying);
        }

        return new Rectangle();
    }

    public static Rectangle DrawNeutral(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        var pen = Assets.NotePen(isSelected, isPlaying);
        g.DrawLine(pen, p.X - 3, p.Y - 7, p.X - 3, p.Y + 4);
        g.DrawLine(pen, p.X + 3, p.Y - 4, p.X + 3, p.Y + 7);
        g.DrawLine(pen, p.X - 3, p.Y - 1, p.X + 3, p.Y - 4);
        g.DrawLine(pen, p.X - 3, p.Y + 4, p.X + 3, p.Y + 1);

        return new Rectangle(p.X - 3, p.Y - 7, 7, 14);
    }

    public static Rectangle DrawSharp(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        var pen = Assets.NotePen(isSelected, isPlaying);
        g.DrawLine(pen, p.X - 2, p.Y - 7, p.X - 2, p.Y + 7);
        g.DrawLine(pen, p.X + 2, p.Y - 7, p.X + 2, p.Y + 7);
        g.DrawLine(pen, p.X - 7, p.Y - 1, p.X + 7, p.Y - 3);
        g.DrawLine(pen, p.X - 7, p.Y + 3, p.X + 7, p.Y + 1);
        return new Rectangle(p.X - 7, p.Y - 7, 14, 14);
    }

    public static Rectangle DrawFlat(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        var pen = Assets.NotePen(isSelected, isPlaying);
        g.DrawLine(pen, p.X - 3, p.Y + 4, p.X - 3, p.Y - 15);
        g.DrawBezier(pen, p.X - 3, p.Y + 4, p.X + 2, p.Y + 4, p.X + 2, p.Y - 5, p.X - 3, p.Y - 5);
        return new Rectangle(p.X - 3, p.Y - 15, 4, 20);
    }

    public static Rectangle DrawQuaver(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        var calc = new BoundsCalculator();
        calc.Add(g.FillCircle(Assets.NoteBrush(isSelected, isPlaying), p, 5));
        calc.Add(g.DrawStem(p, isSelected, isPlaying));
        calc.Add(g.DrawFlag(p, 0, isSelected, isPlaying));
        return calc.Bounds;
    }

    public static Rectangle DrawSemiQuaver(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        var calc = new BoundsCalculator();
        calc.Add(g.FillCircle(Assets.NoteBrush(isSelected, isPlaying), p, 5));
        calc.Add(g.DrawStem(p, isSelected, isPlaying));
        calc.Add(g.DrawFlag(p, 0, isSelected, isPlaying));
        calc.Add(g.DrawFlag(p, 1, isSelected, isPlaying));
        return calc.Bounds;
    }

    public static Rectangle DrawDot(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        return g.FillCircle(Assets.NoteBrush(isSelected, isPlaying), p, 2);
    }

    public static Rectangle DrawWholeRest(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        var rect = new Rectangle(p.X, p.Y, 15, 6);
        g.FillRectangle(Assets.NoteBrush(isSelected, isPlaying), rect);
        return rect;
    }

    public static Rectangle DrawHalfRest(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        var rect = new Rectangle(p.X, p.Y - 6, 15, 6);
        g.FillRectangle(Assets.NoteBrush(isSelected, isPlaying), rect);
        return rect;
    }

    public static Rectangle DrawQuaterRest(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        g.TranslateTransform(p.X, p.Y - 13);
        g.ScaleTransform(0.1f, 0.1f);

        var path = new GraphicsPath();
        path.AddBezier(new Point(102, 82), new Point(102, 100), new Point(65, 130), new Point(65, 165));
        path.AddBezier(new Point(65, 165), new Point(65, 181), new Point(91, 222), new Point(113, 248));
        path.AddBezier(new Point(113, 248), new Point(100, 240), new Point(95, 238), new Point(79, 239));
        path.AddBezier(new Point(79, 239), new Point(52, 238), new Point(41, 258), new Point(41, 274));
        path.AddBezier(new Point(41, 274), new Point(41, 286), new Point(51, 293), new Point(57, 305));
        path.AddBezier(new Point(57, 305), new Point(25, 285), new Point(8, 267), new Point(8, 247));
        path.AddBezier(new Point(8, 247), new Point(8, 201), new Point(41, 217), new Point(64, 209));
        path.AddBezier(new Point(64, 209), new Point(38, 184), new Point(17, 149), new Point(18, 135));
        path.AddBezier(new Point(18, 135), new Point(18, 124), new Point(57, 91), new Point(56, 73));
        path.AddBezier(new Point(56, 73), new Point(57, 40), new Point(50, 22), new Point(43, 8));
        path.AddBezier(new Point(43, 8), new Point(60, 31), new Point(101, 71), new Point(103, 82));

        g.FillPath(Assets.NoteBrush(isSelected, isPlaying), path);
        g.ResetTransform();

        return new Rectangle(p.X, p.Y, 11, 31);
    }

    public static Rectangle DrawEighthNoteRest(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        g.TranslateTransform(p.X, p.Y);
        g.ScaleTransform(0.16f, 0.16f);

        var path = SvgPathBuilder.Create("M197 221C205 220 209 212 213 206 216 202 223 198 226 201 230 206 222 213 220 219 209 258 197 297 185 336 181 339 172 339 171 335 183 300 196 265 209 230 196 232 183 236 169 236 159 235 148 228 146 217 143 209 146 198 154 193 162 187 176 186 182 196 187 203 186 213 192 219 193 220 195 221 197 221");

        g.FillPath(Assets.NoteBrush(isSelected, isPlaying), path);
        g.ResetTransform();

        return new Rectangle(p.X, p.Y, 10, 20);
    }

    public static Rectangle DrawSixteenthNoteRest(this Graphics g, Point p, bool isSelected, bool isPlaying)
    {
        g.TranslateTransform(p.X, p.Y);
        g.ScaleTransform(0.16f, 0.16f);

        // TODO: Update path data
        var path = SvgPathBuilder.Create("M197 221C205 220 209 212 213 206 216 202 223 198 226 201 230 206 222 213 220 219 209 258 197 297 185 336 181 339 172 339 171 335 183 300 196 265 209 230 196 232 183 236 169 236 159 235 148 228 146 217 143 209 146 198 154 193 162 187 176 186 182 196 187 203 186 213 192 219 193 220 195 221 197 221");

        g.FillPath(Assets.NoteBrush(isSelected, isPlaying), path);
        g.ResetTransform();

        return new Rectangle(p.X, p.Y, 10, 20);
    }

    public static Rectangle DrawViolinNote(
        this Graphics g, 
        Point p, 
        int radius, 
        MusicalNote note, 
        bool isInKey, 
        bool isSelected,
        bool isPlaying, 
        bool isOpenString)
    {
        if (isOpenString)
        {
            g.FillRectangle(Assets.WhiteBrush, p.X - radius, p.Y - radius, radius * 2, radius * 2);
            g.DrawRectangle(Assets.ViolinNotePen(isSelected, isPlaying, isInKey), p.X - radius, p.Y - radius, radius * 2, radius * 2);
        }
        else
        {
            g.FillCircle(Assets.WhiteBrush, p, radius);
            g.DrawCircle(Assets.ViolinNotePen(isSelected, isPlaying, isInKey), p, radius);
        }

        g.DrawCenteredString(note.Name, Assets.NoteFont(radius - 5), Assets.NoteNameBrush(isSelected, isPlaying, isInKey), p);

        return new Rectangle(p.X - radius, p.Y - radius, (radius * 2), (radius * 2));
    }
}