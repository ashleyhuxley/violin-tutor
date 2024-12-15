namespace ElectricFox.ViolinTutor.Code
{
    public class KeySignature : NotationItem
    {
        public static readonly KeySignature C = new("C", "", "");
        public static readonly KeySignature G = new("G", "F", "");
        public static readonly KeySignature D = new("D", "FC", "");
        public static readonly KeySignature A = new("A", "FCG", "");
        public static readonly KeySignature E = new("E", "FCGD", "");
        public static readonly KeySignature B = new("B", "FCGDA", "");
        public static readonly KeySignature CFlat = new("Cb", "FCGDA", "");
        public static readonly KeySignature FSharp = new("F#", "FCGDAE", "");
        public static readonly KeySignature GFlat = new("Gb", "FCGDAE", "");
        public static readonly KeySignature DFlat = new("Db", "", "BEADG");
        public static readonly KeySignature CSharp = new("C#", "", "BEADG");
        public static readonly KeySignature AFlat = new("Ab", "", "BEAD");
        public static readonly KeySignature EFlat = new("Eb", "", "BEA");
        public static readonly KeySignature BFlat = new("Bb", "", "BE");
        public static readonly KeySignature F = new("F", "", "B");

        public static IReadOnlyCollection<KeySignature> Keys =>
        [
            C, G, D, A, E, B, CFlat, FSharp, GFlat, DFlat, CSharp, AFlat, EFlat, BFlat, F
        ];

        public List<char> Sharps { get; set; } = [];
        public List<char> Flats { get; set; } = [];

        public string Name { get; set; }

        private KeySignature(string name, string sharpNotes, string flatNotes)
        {
            Sharps.AddRange(sharpNotes);
            Flats.AddRange(flatNotes);
            Name = name;
        }

        public KeySignature() { }

        public MusicalNote Adjust(MusicalNote note)
        {
            var baseNote = note.Name[0];
            if (Sharps.Contains(baseNote))
            {
                return new MusicalNote(baseNote + "#", note.Octave);
            }
            else if (Flats.Contains(baseNote))
            {
                return new MusicalNote(baseNote + "b", note.Octave);
            }

            return note;
        }

        public Accidental GetAccidentalForNote(NoteValue note)
        {
            var name = Enum.GetName(typeof(NoteValue), note);
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Could not get the name of the note");
            }

            if (Sharps.Contains(name[0]))
            {
                return Accidental.Sharp;
            }
            else if (Flats.Contains(name[0]))
            {
                return Accidental.Flat;
            }
            else
            {
                return Accidental.Neutral;
            }
        }

        public bool IsContained(MusicalNote note)
        {
            var name = Enum.GetName(typeof(NoteValue), note.Value);
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Could not get the name of the note");
            }

            switch (note.Accidental)
            {
                case Accidental.Neutral:
                    return !Sharps.Contains(name[0]) && !Flats.Contains(name[0]);
                case Accidental.Sharp:
                    return Sharps.Contains(name[0]);
                case Accidental.Flat:
                    return Flats.Contains(name[0]);
            }

            return false;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
