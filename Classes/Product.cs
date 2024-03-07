using System.Text.Json.Serialization;

namespace School42.API.Classes;

public class Product
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("description")]
    public string Description { get; set; } = "";
    [JsonPropertyName("price")]
    public int Price { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
    [JsonPropertyName("begin_at")]
    public DateTime? BeginAt { get; set; }
    [JsonPropertyName("end_at")]
    public DateTime? EndAt { get; set; }
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    [JsonPropertyName("kind")]
    public string Kind { get; set; } = "";
    [JsonPropertyName("slug")]
    public string Slug { get; set; } = "";
    [JsonPropertyName("image")]
    public ProductImage Image { get; set; } = new("");

    [JsonPropertyName("is_uniq")]
    public bool IsUniq { get; set; }
    [JsonPropertyName("one_time_purchase")]
    public bool OneTimePurchase { get; set; }
}

public class ProductImage(string url)
{
    [JsonPropertyName("url")]
    public string Url { get; set; } = url;
    [JsonPropertyName("thumb")]
    public ProductThumb Thumb { get; set; } = new();
}

public class ProductThumb
{
    [JsonPropertyName("url")]
    public string Url { get; set; } = "";
}