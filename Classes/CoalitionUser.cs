using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class CoalitionsUser
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("coalition_id")]
    public int CoalitionId { get; set; }
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
