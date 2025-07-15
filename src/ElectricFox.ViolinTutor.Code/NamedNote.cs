using System.Text.Json.Serialization;

namespace ElectricFox.ViolinTutor.Code
{
    public class NamedNote
    {
        public MusicalNote Note { get; private set; }

        public NoteValue Value { get; set; }
        public Accidental Accidental { get; set; }
        public int Octave { get; set; }

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

        public NamedNote(NoteValue value, Accidental accidental, int octave)
        {
            this.Value = value;
            this.Accidental = accidental;
            this.Octave = octave;

            Note = new MusicalNote(value, accidental, octave);
        }

        public NamedNote(string name, int octave)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Value = name.ToUpperInvariant()[0] switch
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

            this.Accidental = Accidental.Neutral;

            if (name.Length > 1)
            {
                this.Accidental = name[1] switch
                {
                    '#' => Accidental.Sharp,
                    'b' => Accidental.Flat,
                    _ => Accidental.Neutral
                };
            }

            this.Octave = octave;
            Note = new MusicalNote(Value, Accidental, Octave);
        }

        [JsonIgnore]
        public int StavePosition => (Octave * 7) + (int)Value;
    }
}
