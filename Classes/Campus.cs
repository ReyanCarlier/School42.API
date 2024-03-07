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
    [JsonPropertyName("country")]
    public string Country { get; set; } = "";
    [JsonPropertyName("address")]
    public string Address { get; set; } = "";
    [JsonPropertyName("zip")]
    public string Zip { get; set; } = "";
    [JsonPropertyName("city")]
    public string City { get; set; } = "";
    [JsonPropertyName("website")]
    public string Website { get; set; } = "";
    [JsonPropertyName("facebook")]
    public string Facebook { get; set; } = "";
    [JsonPropertyName("twitter")]
    public string Twitter { get; set; } = "";
    [JsonPropertyName("active")]
    public bool Active { get; set; }
    [JsonPropertyName("public")]
    public bool Public { get; set; }
    [JsonPropertyName("email_extension")]
    public string EmailExtension { get; set; } = "";
    [JsonPropertyName("default_hidden_phone")]
    public bool DefaultHiddenPhone { get; set; }
    [JsonPropertyName("endpoint")]
    public Endpoint Endpoint { get; set; } = new();
}
