using System.Text.Json.Serialization;

namespace TriviaGame.Models
{
    public class TokenResponse
    {
        [JsonPropertyName("response_code")]
        public int ResponseCode { get; set; }

        [JsonPropertyName("response_message")]
        public string ResponseMessage { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}