using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class CampusUser
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("user_id")]
    public int UserId { get; set; } = 0;
    [JsonPropertyName("campus_id")]
    public int CampusId { get; set; } = 0;
    [JsonPropertyName("is_primary")]
    public bool IsPrimary { get; set; } = false;
}