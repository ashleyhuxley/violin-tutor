using System.Text.Json.Serialization;

namespace ElectricFox.ViolinTutor.Code
{
    [JsonDerivedType(typeof(BarSeparator), typeDiscriminator: "bar")]
    [JsonDerivedType(typeof(KeySignature), typeDiscriminator: "key")]
    [JsonDerivedType(typeof(PlayableNote), typeDiscriminator: "note")]
    [JsonDerivedType(typeof(Rest), typeDiscriminator: "rest")]
    [JsonDerivedType(typeof(TimeSignature), typeDiscriminator: "time")]
    public abstract class NotationItem
    {
        [JsonIgnore]
        public bool IsSelected { get; set; }
        [JsonIgnore]
        public bool IsPlaying { get; set; }
    }
}
