using System.Collections.Generic;
using System.Text.Json.Serialization;
#pragma warning disable CS8618

namespace OrderApplication.Models;

public class Product
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("brand")]
    public string Brand { get; set; }
    
    [JsonPropertyName("price")]
    public double Price { get; set; }
    
    
    [JsonPropertyName("category")]
    public string Category { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    [JsonPropertyName("image")]
    public dynamic? Image { get; set; }
    
    [JsonPropertyName("image_path")]
    public string ImagePath { get; set; }
    
    [JsonPropertyName("original_link")]
    public string Link { get; set; }
    
    
    [JsonPropertyName("nutri_score")]
    public string NutriScore { get; set; }
    
    [JsonPropertyName("quantity")]
    public string Quantity { get; set; }
    
    [JsonPropertyName("allergens")]
    public List<string> Allergens { get; set; }
    
    [JsonPropertyName("ingredients")]
    public List<string> Ingredients { get; set; }
    
    
    [JsonPropertyName("energy")]
    public double Energy { get; set; }
    
    [JsonPropertyName("fat")]
    public double Fat { get; set; }
    
    [JsonPropertyName("saturated_fat")]
    public double SaturatedFat { get; set; }
    
    [JsonPropertyName("unsaturated_fat")]
    public double UnsaturatedFat { get; set; }
    
    [JsonPropertyName("carbohydrates")]
    public double Carbohydrates { get; set; }
    
    [JsonPropertyName("sugars")]
    public double Sugars { get; set; }
    
    [JsonPropertyName("fiber")]
    public double Fiber { get; set; }
    
    [JsonPropertyName("proteins")]
    public double Proteins { get; set; }
    
    [JsonPropertyName("salt")]
    public double Salt { get; set; }

    [JsonPropertyName("extra")]
    public List<Dictionary<string, double>> Extra { get; set; }
}