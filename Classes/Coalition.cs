using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class Coalition
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("slug")]
    public string Slug { get; set; } = "";
    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; } = "";
    [JsonPropertyName("color")]
    public string Color { get; set; } = "";
    [JsonPropertyName("score")]
    public int Score { get; set; }
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
}