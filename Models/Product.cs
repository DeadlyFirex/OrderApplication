using System.Collections.Generic;
using Newtonsoft.Json;
#pragma warning disable CS8618

namespace OrderApplication.Models;

public class Product
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("uuid")]
    public string Uuid { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("brand")]
    public string Brand { get; set; }
    
    [JsonProperty("price")]
    public double Price { get; set; }
    
    
    [JsonProperty("category")]
    public string Category { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("image")]
    public dynamic? Image { get; set; }
    
    [JsonProperty("image_path")]
    public string ImagePath { get; set; }
    
    [JsonProperty("original_link")]
    public string Link { get; set; }
    
    
    [JsonProperty("nutri_score")]
    public string NutriScore { get; set; }
    
    [JsonProperty("quantity")]
    public string Quantity { get; set; }
    
    [JsonProperty("allergens")]
    public List<string> Allergens { get; set; }
    
    [JsonProperty("ingredients")]
    public List<string> Ingredients { get; set; }
    
    
    [JsonProperty("energy")]
    public double Energy { get; set; }
    
    [JsonProperty("fat")]
    public double Fat { get; set; }
    
    [JsonProperty("saturated_fat")]
    public double SaturatedFat { get; set; }
    
    [JsonProperty("unsaturated_fat")]
    public double UnsaturatedFat { get; set; }
    
    [JsonProperty("carbohydrates")]
    public double Carbohydrates { get; set; }
    
    [JsonProperty("sugars")]
    public double Sugars { get; set; }
    
    [JsonProperty("fiber")]
    public double Fiber { get; set; }
    
    [JsonProperty("proteins")]
    public double Proteins { get; set; }
    
    [JsonProperty("salt")]
    public double Salt { get; set; }

    [JsonProperty("extra")]
    public List<Dictionary<string, double>> Extra { get; set; }
}