using System.Text.Json.Serialization;

namespace DBSQLite.Models
{
    public class APIResponse
    {
        [JsonPropertyName("numFound")]
        public int NumFound { get; set; }

        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("maxScore")]
        public double MaxScore { get; set; }

        [JsonPropertyName("docs")]
        public List<Doc> Docs { get; set; }
    }

    public class RawResponse
    {
        [JsonPropertyName("response")]
        public APIResponse Response { get; set; }    
    }
}
