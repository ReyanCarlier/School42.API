using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class Language
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; } = "";
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.MinValue;
}