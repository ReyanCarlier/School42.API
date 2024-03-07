using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class Bloc
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("campus_id")]
    public int CampusId { get; set; }
    [JsonPropertyName("cursus_id")]
    public int CursusId { get; set; }
    [JsonPropertyName("squad_size")]
    public int SquadSize { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    [JsonPropertyName("coalitions")]
    public List<Coalition> Coalitions { get; set; }

    public Bloc()
    {
        Coalitions = new List<Coalition>();
    }
}