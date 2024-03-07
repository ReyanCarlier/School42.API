using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class App
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("description")]
    public string Description { get; set; } = "";
    [JsonPropertyName("image")]
    public string Image { get; set; } = "";
    [JsonPropertyName("website")]
    public string Website { get; set; } = "";
    [JsonPropertyName("public")]
    public bool Public { get; set; } = false;
    [JsonPropertyName("scopes")]
    public List<string> Scopes { get; set; } = [];

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    [JsonPropertyName("owner")]
    public Owner Owner { get; set; } = new Owner
    {
        Id = 0,
        Login = "",
        Url = ""
    };
    [JsonPropertyName("rate_limit")]
    public int RateLimit { get; set; }
    [JsonPropertyName("roles")]
    public List<Role> Roles { get; set; } = [];
}