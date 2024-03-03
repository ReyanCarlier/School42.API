using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class ExpertiseUser
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("expertise_id")]
    public int ExpertiseId { get; set; } = 0;
    [JsonPropertyName("interested")]
    public bool Interested { get; set; } = false;
    [JsonPropertyName("value")]
    public int Value { get; set; } = 0;
    [JsonPropertyName("contact_me")]
    public bool ContactMe { get; set; } = false;
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
    [JsonPropertyName("user_id")]
    public int UserId { get; set; } = 0;
}