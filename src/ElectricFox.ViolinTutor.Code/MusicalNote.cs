namespace ElectricFox.ViolinTutor.Code
{
    public class MusicalNote
    {
        private static Dictionary<(NoteValue, Accidental), int> baseValues = new()
        {
            { (NoteValue.C, Accidental.Neutral), 0 },

            { (NoteValue.C, Accidental.Sharp), 1 },
            { (NoteValue.D, Accidental.Flat), 1 },

            { (NoteValue.D, Accidental.Neutral), 2 },

            { (NoteValue.D, Accidental.Sharp), 3 },
            { (NoteValue.E, Accidental.Flat), 3 },

            { (NoteValue.E, Accidental.Neutral), 4 },

            { (NoteValue.F, Accidental.Neutral),5 },

            { (NoteValue.F, Accidental.Sharp), 6 },
            { (NoteValue.G, Accidental.Flat), 6 },

            { (NoteValue.G, Accidental.Neutral), 7 },

            { (NoteValue.G, Accidental.Sharp), 8 },
            { (NoteValue.A, Accidental.Flat), 8 },

            { (NoteValue.A, Accidental.Neutral), 9 },

            { (NoteValue.A, Accidental.Sharp), 10 },
            { (NoteValue.B, Accidental.Flat), 10 },

            { (NoteValue.B, Accidental.Neutral), 11 },
        };

        private int absoluteValue = 0;

        public decimal Frequency => FrequncyList[this.absoluteValue];

        public MusicalNote()
        {
        }

        public MusicalNote(NoteValue value, Accidental accidental, int octave)
        {
            var baseValue = baseValues[(value, accidental)];
            this.absoluteValue = (octave * 12) + baseValue;
        }

        public static MusicalNote FromAbsoluteValue(int absoluteValue)
        {
            if (absoluteValue < 0 || absoluteValue >= FrequncyList.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(absoluteValue), "Absolute value is out of range for musical notes.");
            }

            var note = new MusicalNote
            {
                absoluteValue = absoluteValue
            };

            return note;
        }

        public IEnumerable<NamedNote> GetNamedNotes()
        {
            var octave = absoluteValue / 12;

            var baseValue = absoluteValue % 12;

            return 
                baseValues
                .Where(b => b.Value == baseValue)
                .Select(b => new NamedNote(b.Key.Item1, b.Key.Item2, octave));
        }

        public NamedNote GetNoteInKey(KeySignature key)
        {
            var octave = absoluteValue / 12;

            var baseValue = absoluteValue % 12;

            var candidates = GetNamedNotes();
            if (candidates.Any(key.IsContained))
            {
                return candidates.First(key.IsContained);
            }
            else
            {
                return candidates.First();
            }
        }

        public MusicalNote ShiftOctaveUp()
        {
            return FromAbsoluteValue(this.absoluteValue + 12);
        }

        public MusicalNote ShiftOctaveDown()
        {
            return FromAbsoluteValue(this.absoluteValue - 12);
        }

        public override bool Equals(object? obj) => obj is MusicalNote other && Equals(other);

        public override int GetHashCode() => absoluteValue.GetHashCode();

        public static MusicalNote operator +(MusicalNote a, int b)
            => FromAbsoluteValue(a.absoluteValue + b);
        public static MusicalNote operator -(MusicalNote a, int b)
            => FromAbsoluteValue(a.absoluteValue - b);
        public static MusicalNote operator ++(MusicalNote a)
            => FromAbsoluteValue(a.absoluteValue + 1);
        public static MusicalNote operator --(MusicalNote a)
            => FromAbsoluteValue(a.absoluteValue - 1);
        public static bool operator ==(MusicalNote a, MusicalNote b)
            => a.absoluteValue == b.absoluteValue;
        public static bool operator !=(MusicalNote a, MusicalNote b)
            => a.absoluteValue != b.absoluteValue;

        private static readonly decimal[] FrequncyList = [
            16.35m,   17.32m,   18.35m,   19.45m,   20.60m,   21.83m,   23.12m,   24.50m,   25.96m,   27.50m,   29.14m,   30.87m,
            32.70m,   34.65m,   36.71m,   38.89m,   41.20m,   43.65m,   46.25m,   49.00m,   51.91m,   55.00m,   58.27m,   61.74m,
            65.41m,   69.30m,   73.42m,   77.78m,   82.41m,   87.31m,   92.50m,   98.00m,   103.83m,  110.00m,  116.54m,  123.47m,
            130.81m,  138.59m,  146.83m,  155.56m,  164.81m,  174.61m,  185.00m,  196.00m,  207.65m,  220.00m,  233.08m,  246.94m,
            261.63m,  277.18m,  293.66m,  311.13m,  329.63m,  349.23m,  369.99m,  392.00m,  415.30m,  440.00m,  466.16m,  493.88m,
            523.25m,  554.37m,  587.33m,  622.25m,  659.25m,  698.46m,  739.99m,  783.99m,  830.61m,  880.00m,  923.33m,  987.77m,
            1046.50m, 1108.73m, 1174.66m, 1244.51m, 1318.51m, 1396.91m, 1479.98m, 1567.98m, 1661.22m, 1760.00m, 1864.66m, 1975.53m,
            2093.00m, 2217.46m, 2349.32m, 2489.02m, 2637.02m, 2793.83m, 2959.96m, 3135.96m, 3322.44m, 3520.00m, 3729.31m, 3951.07m,
            4186.01m, 4434.92m, 4698.63m, 4978.03m, 5274.04m, 5587.65m, 5919.91m, 6271.93m, 6644.88m, 7040.00m, 7458.62m, 7902.13m
        ];

    }
}