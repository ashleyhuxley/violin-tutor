using ElectricFox.ViolinTutor.Code;

namespace ElectricFox.ViolinTutor.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("C", 0, 0)]
        [TestCase("D", 0, 1)]
        [TestCase("E", 0, 2)]
        [TestCase("F", 0, 3)]
        [TestCase("G", 0, 4)]
        [TestCase("A", 0, 5)]
        [TestCase("B", 0, 6)]
        [TestCase("C", 1, 7)]
        [TestCase("D", 4, 29)]
        [TestCase("E", 4, 30)]
        [TestCase("F", 4, 31)]
        [TestCase("G", 4, 32)]
        [TestCase("A", 4, 33)]
        [TestCase("B", 4, 34)]
        [TestCase("C", 5, 35)]
        [TestCase("D", 5, 36)]
        public void MusicalNote_StaveValue_IsCorrect(string name, int octave, int expected)
        {
            var note = new MusicalNote(name, octave);
            Assert.That(note.StavePosition, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("C", 0, 0)]
        [TestCase("C#", 0, 1)]
        [TestCase("D", 0, 2)]
        [TestCase("D#", 0, 3)]
        [TestCase("E", 0, 4)]
        [TestCase("F", 0, 5)]
        [TestCase("F#", 0, 6)]
        [TestCase("G", 0, 7)]
        [TestCase("G#", 0, 8)]
        [TestCase("A", 0, 9)]
        [TestCase("A#", 0, 10)]
        [TestCase("B", 0, 11)]
        [TestCase("C", 1, 12)]
        public void MusicalNote_AbsoluteValue_IsCorrect(string name, int octave, int expected)
        {
            var note = new MusicalNote(name, octave);
            Assert.That(note.AbsoluteValue, Is.EqualTo(expected));
        }

        [Test]
        public void MusicalNote_FromValue_IsSequential()
        {
            var abs = 0;
            var note = MusicalNote.FromValue(abs);

            while (note.AbsoluteValue < 108)
            {
                note++;
                Assert.That(note.AbsoluteValue, Is.EqualTo(abs + 1));
                abs++;
            }
        }
    }
}