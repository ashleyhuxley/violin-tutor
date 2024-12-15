namespace ElectricFox.ViolinTutor.Code
{
    public class TimeSignature : NotationItem
    {
        /// <summary>
        /// The number of beats in a measure (top number of the time signature).
        /// </summary>
        public int BeatsPerMeasure { get; set; }

        /// <summary>
        /// The note value that represents one beat (bottom number of the time signature).
        /// </summary>
        public int BeatNoteValue { get; set; }

        public TimeSignature()
        {  }

        /// <summary>
        /// Initializes a new instance of the TimeSignature class.
        /// </summary>
        /// <param name="beatsPerMeasure">The number of beats in a measure.</param>
        /// <param name="beatNoteValue">The note value that represents one beat.</param>
        public TimeSignature(int beatsPerMeasure, int beatNoteValue)
        {
            if (beatsPerMeasure <= 0)
                throw new ArgumentException("Beats per measure must be greater than zero.");

            if (!IsValidBeatNoteValue(beatNoteValue))
                throw new ArgumentException("Invalid beat note value. Must be 1, 2, 4, 8, 16, 32, etc.");

            BeatsPerMeasure = beatsPerMeasure;
            BeatNoteValue = beatNoteValue;
        }

        /// <summary>
        /// Validates that the beat note value is a power of 2 (e.g., 1, 2, 4, 8, 16).
        /// </summary>
        private bool IsValidBeatNoteValue(int value)
        {
            return (value > 0) && ((value & (value - 1)) == 0);
        }

        public override string ToString()
        {
            return $"{BeatsPerMeasure}/{BeatNoteValue}";
        }
    }
}
