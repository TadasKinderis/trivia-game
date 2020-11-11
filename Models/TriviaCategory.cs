using System.Text.Json.Serialization;

namespace TriviaGame.Models
{
    public class TriviaCategory
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}