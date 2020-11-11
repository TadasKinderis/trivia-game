using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace TriviaGame.Models
{
    public partial class QueryResponse
    {
        [JsonPropertyName("response_code")]
        public int ResponseCode { get; set; }

        [JsonPropertyName("results")]
        public IEnumerable<Result> Results { get; set; }
    }
}