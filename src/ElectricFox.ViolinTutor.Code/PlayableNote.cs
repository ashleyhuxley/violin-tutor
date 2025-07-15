using System.Text.Json.Serialization;

namespace ElectricFox.ViolinTutor.Code
{
    public sealed class PlayableNote : NotationItem, IPlayable
    {
        public PlayableNote(NamedNote note, decimal length)
        {
            NamedNote = note;
            Length = length;
        }

        public NamedNote NamedNote { get; set; }

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
