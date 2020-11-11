using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TriviaGame.Models
{
    public class TriviaCategoryCollection
    {
        [JsonPropertyName("trivia_categories")]
        public IEnumerable<TriviaCategory> TriviaCategories { get; set; }
    }
}