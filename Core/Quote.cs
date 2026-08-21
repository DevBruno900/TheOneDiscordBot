using System.Text.Json.Serialization;

namespace Core
{
    public class Quote
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("dialog")]
        public string Dialog { get; set; } = null!;

        [JsonPropertyName("movie")]
        public string MovieId { get; set; } = null!;

        [JsonPropertyName("character")]
        public string CharacterId { get; set; } = null!;

        public override string ToString()
        {
            return $"{Dialog}";
        }
    }
}
