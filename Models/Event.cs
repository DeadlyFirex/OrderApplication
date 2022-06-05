using System;
using Newtonsoft.Json;
#pragma warning disable CS8618

namespace OrderApplication.Models;

public class Event
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("uuid")]
    public string Uuid { get; set; }
    

    [JsonProperty("active")]
    public bool Active { get; set; }
    
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("until")]
    public DateTime Until { get; set; }
    
    [JsonProperty("deadline")]
    public DateTime Deadline { get; set; }
    
    
    [JsonProperty("max_order_price")]
    public double MaxOrderPrice { get; set; }
}