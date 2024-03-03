using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class AchievementUser
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    [JsonPropertyName("login")]
    public string Login { get; set; } = "";
    [JsonPropertyName("url")]
    public string Url { get; set; } = "";
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}
