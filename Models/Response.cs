using System.Text.Json.Serialization;

namespace HomeWork.Models
{
    public class Response<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
        [JsonPropertyName("support")]
        public Support Support { get; set; }
    }
}