using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class CursusUser
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("begin_at")]
    public DateTime? BeginAt { get; set; }
    [JsonPropertyName("end_at")]
    public DateTime? EndAt { get; set; }
    [JsonPropertyName("grade")]
    public string Grade { get; set; } = "";
    [JsonPropertyName("level")]
    public double Level { get; set; } = 0;
    [JsonPropertyName("skills")]
    public List<object> Skills { get; set; } = [];
    [JsonPropertyName("cursus_id")]
    public int CursusId { get; set; } = 0;
    [JsonPropertyName("has_coalition")]
    public bool HasCoalition { get; set; } = false;
    [JsonPropertyName("user")]
    public User User { get; set; } = new();
    [JsonPropertyName("cursus")]
    public Cursus Cursus { get; set; } = new();
}