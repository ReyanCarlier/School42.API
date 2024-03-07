using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class Amendment
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("internship_ip")]
    public int? InternshipId { get; set; }
    [JsonPropertyName("end_at")]
    public string EndAt { get; set; }
    [JsonPropertyName("kind")]
    public string Kind { get; set; }
    [JsonPropertyName("origin")]
    public string Origin { get; set; }
    [JsonPropertyName("convention")]
    public string Convention { get; set; }
    [JsonPropertyName("salary")]
    public string Salary { get; set; }
    [JsonPropertyName("currency")]
    public string Currency { get; set; }
    [JsonPropertyName("effective_date")]
    public DateTime? EffectiveDate { get; set; }
}
