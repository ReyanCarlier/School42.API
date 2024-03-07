using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class Owner
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("login")]
    public string Login { get; set; } = "";
    [JsonPropertyName("url")]
    public string Url { get; set; } = "";
}