using System.Text.Json.Serialization;

namespace Core
{
    public class Character
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("wikiUrl")]
        public string? WikiUrl { get; set; }

        [JsonPropertyName("race")]
        public string? Race { get; set; }

        [JsonPropertyName("birth")]
        public string? Birth { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("death")]
        public string? Death { get; set; }

        [JsonPropertyName("hair")]
        public string? Hair { get; set; }

        [JsonPropertyName("height")]
        public string? Height { get; set; }

        [JsonPropertyName("realm")]
        public string? Realm { get; set; }

        [JsonPropertyName("spouse")]
        public string? Spouse { get; set; }

        public override string ToString()
        {
            return $"Character: {Name}, Race: {Race ?? "null"}, Gender: {Gender ?? "null"}";
        }   
    }
}
