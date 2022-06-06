using System;
using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace OrderApplication.Models;

public class Event
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }
    

    [JsonPropertyName("active")]
    public bool Active { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonPropertyName("until")]
    public DateTime Until { get; set; }
    
    [JsonPropertyName("deadline")]
    public DateTime Deadline { get; set; }
    
    
    [JsonPropertyName("max_order_price")]
    public double MaxOrderPrice { get; set; }
}