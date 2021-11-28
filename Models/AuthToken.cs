using System.Text.Json.Serialization;

namespace HomeWork.Models
{
    public class AuthToken
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}