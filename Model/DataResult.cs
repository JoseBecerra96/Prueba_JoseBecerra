using System.Text.Json.Serialization;

namespace Model
{
    public class DataResult<T>
    {
        [JsonPropertyName("result")]
        public bool Result { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("ex")]
        public Exception Ex { get; set; }
        [JsonPropertyName("value")]
        public T Value { get; set; }
        [JsonPropertyName("values")]
        public List<T> Values { get; set; } 
    }
}
