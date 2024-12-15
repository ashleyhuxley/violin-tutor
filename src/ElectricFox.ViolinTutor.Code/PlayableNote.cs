using System.Text.Json.Serialization;

namespace ElectricFox.ViolinTutor.Code
{
    public sealed class PlayableNote : NotationItem, IPlayable
    {
        public PlayableNote(MusicalNote note, decimal length)
        {
            Note = note;
            Length = length;
        }

        public MusicalNote Note { get; set; }

        public decimal Length { get; set; }

        public int Dots { get; set; }

        [JsonIgnore]
        public decimal FinalLength
        {
            get
            {
                switch (Dots)
                {
                    case 0: return Length;
                    case 1: return Length * 1.5m;
                    case 2: return Length * 1.75m;
                }
                return Length;
            }
        }
    }
}
