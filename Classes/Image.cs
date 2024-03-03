using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class Image
{
    [JsonPropertyName("link")]
    public string Link { get; set; } = "";
    [JsonPropertyName("versions")]
    public Versions Versions { get; set; } = new();
}

public class Versions
{
    [JsonPropertyName("large")]
    public string Large { get; set; } = "";
    [JsonPropertyName("medium")]
    public string Medium { get; set; } = "";
    [JsonPropertyName("small")]
    public string Small { get; set; } = "";
    [JsonPropertyName("micro")]
    public string Micro { get; set; } = "";
}