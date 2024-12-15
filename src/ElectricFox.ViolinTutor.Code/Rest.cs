namespace ElectricFox.ViolinTutor.Code
{
    public class Rest : NotationItem, IPlayable
    {
        public Rest()
        { }

        public Rest(decimal length)
        {
            Length = length;
        }

        public decimal Length { get; set; }
    }
}
