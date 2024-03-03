using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class Achievement
{
    [JsonPropertyName("id")]
    public int Id { get; set; } = 0;
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("description")]
    public string Description { get; set; } = "";
    [JsonPropertyName("tier")]
    public string Tier { get; set; } = "";
    [JsonPropertyName("kind")]
    public string Kind { get; set; } = "";
    [JsonPropertyName("visible")]
    public bool Visible { get; set; } = false;
    [JsonPropertyName("image")]
    public string Image { get; set; } = "";
    [JsonPropertyName("nbr_of_success")]
    public int NumberOfSuccess { get; set; } = 0;
    [JsonPropertyName("users_url")]
    public string UsersUrl { get; set; } = "";
    [JsonPropertyName("achievements")]
    public List<Achievement>? Achievements { get; set; }
    [JsonPropertyName("parent")]
    public Achievement? Parent { get; set; } = null;
    [JsonPropertyName("title")]
    public string? Title { get; set; }
}