using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class Patroned
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("user_id")]
    public int UserId { get; set; } = 0;
    [JsonPropertyName("godfather_id")]
    public int GodfatherId { get; set; } = 0;
    [JsonPropertyName("ongoing")]
    public bool Ongoing { get; set; } = false;
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.MinValue;
}