using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ElectricFox.ViolinTutor.Code
{
    public class Melody
    {
        public Melody(string name, int tempo)
        {
            Name = name;
            Tempo = tempo;
        }

        public string Name { get; set; }

        public int Tempo { get; set; }

        public List<NotationItem> Items { get; set; } = [];

        public KeySignature KeySignature { get; set; } = KeySignature.C;

        public TimeSignature TimeSignature { get; set; } = new TimeSignature(4, 4);

        [JsonIgnore]
        public Dictionary<NotationItem, Rectangle> Bounds { get; set; } = [];

        public void Save(string filename)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };

            string json = JsonSerializer.Serialize(this, options);

            File.WriteAllText(filename, json, Encoding.UTF8);
        }

        public static Melody Load(string filename)
        {
            var content = File.ReadAllText(filename);
            var result = JsonSerializer.Deserialize<Melody>(content);
            if (result is null)
            {
                return new Melody("New Melody", 100);
            }

            return result;
        }
    }
}
