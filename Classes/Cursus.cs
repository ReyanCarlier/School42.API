using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class Cursus
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("slug")]
    public string Slug { get; set; } = "";
}