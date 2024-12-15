using System.Text.Json.Serialization;

namespace ElectricFox.ViolinTutor.Code
{
    public class MusicalNote
    {
        private static List<(NoteValue, Accidental)> baseValues = new()
        {
            (NoteValue.C, Accidental.Neutral), // 3: C
            (NoteValue.C, Accidental.Sharp),   // 4: C#
            (NoteValue.D, Accidental.Neutral), // 5: D
            (NoteValue.D, Accidental.Sharp),   // 6: D#
            (NoteValue.E, Accidental.Neutral), // 7: E
            (NoteValue.F, Accidental.Neutral), // 8: F
            (NoteValue.F, Accidental.Sharp),   // 9: F#
            (NoteValue.G, Accidental.Neutral), // 10: G
            (NoteValue.G, Accidental.Sharp),    // 11: G#
            (NoteValue.A, Accidental.Neutral), // 0: A
            (NoteValue.A, Accidental.Sharp),   // 1: A#
            (NoteValue.B, Accidental.Neutral), // 2: B
        };

        public MusicalNote()
        {
            Value = NoteValue.C;
            Accidental = Accidental.Neutral;
            Octave = 4;
        }

        public MusicalNote(NoteValue value, Accidental accidental, int octave)
        {
            Value = value;
            Accidental = accidental;
            Octave = octave;
        }

        public MusicalNote(string name, int octave)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Value = name.ToUpperInvariant()[0] switch
            {
                'A' => NoteValue.A,
                'B' => NoteValue.B,
                'C' => NoteValue.C,
                'D' => NoteValue.D,
                'E' => NoteValue.E,
                'F' => NoteValue.F,
                'G' => NoteValue.G,
                _ => throw new ArgumentException("Name must be a note A-G with optional # or b")
            };

            Accidental = Accidental.Neutral;
            if (name.Length > 1)
            {
                Accidental = name[1] switch
                {
                    '#' => Accidental.Sharp,
                    'b' => Accidental.Flat,
                    _ => Accidental.Neutral
                };
            }

            Octave = octave;
        }

        public NoteValue Value { get; set; }
        public int Octave { get; set; }
        public Accidental Accidental { get; set; }

        [JsonIgnore]
        public string Name
        {
            get
            {
                var note = Enum.GetName(typeof(NoteValue), Value);
                var acc = Accidental switch
                {
                    Accidental.Sharp => "#",
                    Accidental.Flat => "b",
                    _ => ""
                };

                return $"{note}{acc}";
            }
        }

        public override string ToString()
        {
            return Name;
        }

        [JsonIgnore]
        public decimal Frequency => FrequncyList[this.AbsoluteValue];

        [JsonIgnore]
        public int AbsoluteValue
        {
            get
            {
                var baseValue = baseValues.IndexOf((Value, Accidental));
                return (Octave * 12) + baseValue;
            }
        }

        [JsonIgnore]
        public int StavePosition => (Octave * 7) + (int)Value;

        public static MusicalNote FromValue(int absoluteValue)
        {
            int octave = absoluteValue / 12;
            int baseValue = absoluteValue % 12;

            // Ensure the base value is non-negative
            if (baseValue < 0) baseValue += 12;

            // Look up the corresponding note
            var (value, accidental) = baseValues[baseValue];

            // Create and return the musical note
            return new MusicalNote
            {
                Value = value,
                Octave = octave,
                Accidental = accidental
            };
        }

        public override bool Equals(object? obj) => obj is MusicalNote other && Equals(other);

        public override int GetHashCode() => AbsoluteValue.GetHashCode();

        public static MusicalNote operator +(MusicalNote a, int b)
            => FromValue(a.AbsoluteValue + b);
        public static MusicalNote operator -(MusicalNote a, int b)
            => FromValue(a.AbsoluteValue - b);
        public static MusicalNote operator ++(MusicalNote a)
            => FromValue(a.AbsoluteValue + 1);
        public static MusicalNote operator --(MusicalNote a)
            => FromValue(a.AbsoluteValue - 1);
        public static bool operator ==(MusicalNote a, MusicalNote b)
            => a?.Name == b?.Name && a?.Octave == b?.Octave;
        public static bool operator !=(MusicalNote a, MusicalNote b)
            => a?.Name != b?.Name || a?.Octave != b?.Octave;

        private readonly decimal[] FrequncyList = [
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