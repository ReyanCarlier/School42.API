using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class UserTemporalData
{
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

}