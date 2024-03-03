using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class User
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; } = "";
    [JsonPropertyName("login")]
    public string Login { get; set; } = "";
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = "";
    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = "";
    [JsonPropertyName("usual_full_name")]
    public string UsualFullName { get; set; } = "";
    [JsonPropertyName("usual_first_name")]
    public string UsualFirstName { get; set; } = "";
    [JsonPropertyName("url")]
    public string Url { get; set; } = "";
    [JsonPropertyName("phone")]
    public string Phone { get; set; } = "";
    [JsonPropertyName("displayname")]
    public string Displayname { get; set; } = "";
    [JsonPropertyName("kind")]
    public string Kind { get; set; } = "user";
    [JsonPropertyName("image")]
    public Image Image { get; set; } = new();
    [JsonPropertyName("staff?")]
    public bool IsStaff { get; set; } = false;
    [JsonPropertyName("correction_point")]
    public int CorrectionPoint { get; set; } = 0;
    [JsonPropertyName("pool_month")]
    public string PoolMonth { get; set; } = "";
    [JsonPropertyName("pool_year")]
    public string PoolYear { get; set; } = "";
    [JsonPropertyName("location")]
    public string Location { get; set; } = "";
    [JsonPropertyName("wallet")]
    public int Wallet { get; set; } = 0;
    [JsonPropertyName("anonymize_date")]
    public DateTime? AnonymizeDate { get; set; } = null;
    [JsonPropertyName("data_erasure_date")]
    public DateTime? DataErasureDate { get; set; } = null;
    [JsonPropertyName("alumni?")]
    public bool IsAlumni { get; set; } = false;
    [JsonPropertyName("active?")]
    public bool IsActive { get; set; } = true;
    [JsonPropertyName("groups")]
    public List<object> Groups { get; set; } = [];
    [JsonPropertyName("cursus_users")]
    public List<CursusUser> CursusUsers { get; set; } = [];
    [JsonPropertyName("projects_users")]
    public List<object> ProjectsUsers { get; set; } = [];
    [JsonPropertyName("languages_users")]
    public List<LanguageUser> LanguagesUsers { get; set; } = [];
    [JsonPropertyName("achievements")]
    public List<object> Achievements { get; set; } = [];
    [JsonPropertyName("titles")]
    public List<object> Titles { get; set; } = [];
    [JsonPropertyName("titles_users")]
    public List<object> TitlesUsers { get; set; } = [];
    [JsonPropertyName("partnerships")]
    public List<object> Partnerships { get; set; } = [];
    [JsonPropertyName("patroned")]
    public List<Patroned> Patroned { get; set; } = [];
    [JsonPropertyName("patroning")]
    public List<object> Patroning { get; set; } = [];
    [JsonPropertyName("expertises_users")]
    public List<ExpertiseUser> ExpertisesUsers { get; set; } = [];
    [JsonPropertyName("roles")]
    public List<object> Roles { get; set; } = [];
    [JsonPropertyName("campus")]
    public List<Campus> Campus { get; set; } = [];
    [JsonPropertyName("campus_users")]
    public List<CampusUser> CampusUsers { get; set; } = [];
}