using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class Accreditation
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("user_id")]
    public int UserId { get; set; } = 0;
    [JsonPropertyName("cursus_id")]
    public int CursusId { get; set; } = 0;
    [JsonPropertyName("validated")]
    public bool Validated { get; set; } = false;
}
