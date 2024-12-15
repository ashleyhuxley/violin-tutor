namespace ElectricFox.ViolinTutor.Ui
{
    public static class Assets
    {
        public static Pen StringPen => new(Color.Black, 3);
        public static Pen FretLine => new(Color.Gold, 5);
        public static Pen StaveLine => new(Color.Black, 1);
        public static Pen BarLine(bool isSelected, bool isThick)
            => new Pen(Colour(isSelected, false, true), isThick ? 2 : 1);
        public static Pen NotePen(bool isSelected, bool isPlaying)
            =>  new(Colour(isSelected, isPlaying, true), 2);
        public static Pen ViolinNotePen(bool isSelected, bool isPlaying, bool isInKey)
            => new (Colour(isSelected, isPlaying, isInKey), 2);
        public static Pen PlayingNotePen => new(Color.Red, 2);
        public static Brush WhiteBrush => new SolidBrush(Color.White);
        public static Brush StringNameBrush => new SolidBrush(Color.Black);
        public static Brush NoteBrush(bool isSelected, bool isPlaying)
            => new SolidBrush(Colour(isSelected, isPlaying, true));
        public static Brush NoteNameBrush(bool isSelected, bool isPlaying, bool isInKey)
            => new SolidBrush(Colour(isSelected, isPlaying, isInKey));
        public static Brush PlayingNoteBrush => new SolidBrush(Color.Red);
        public static Brush TimeSignatureBrush => new SolidBrush(Color.Black);
        public static Font StringFont
            => new ("Source Code Pro", 40);
        public static Font TimeSignatureFont
            => new ("Source Code Pro", 24);
        public static Font NoteFont(float size)
            => new ("Source Code Pro", size);

        public static Color Colour(bool selected, bool playing, bool inKey)
        {
            if (playing)
            {
                return Color.Blue;
            }

            if (selected)
            {
                return Color.Red;
            }

            if (!inKey)
            {
                return Color.LightGray;
            }

            return Color.Black;
        }
    }
}
