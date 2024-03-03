using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class Campus
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("time_zone")]
    public string TimeZone { get; set; } = "";
    [JsonPropertyName("language")]
    public Language Language { get; set; } = new();
    [JsonPropertyName("users_count")]
    public int UsersCount { get; set; } = 0;
    [JsonPropertyName("vogsphere_id")]
    public int VogsphereId { get; set; } = 0;
}
