using System;
using System.Collections.Generic;
using Newtonsoft.Json;
#pragma warning disable CS8618

namespace OrderApplication.Models;

internal class Order
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("uuid")]
    public string Uuid { get; set; }
    
    
    [JsonProperty("products")]
    public List<string> Products { get; set; }
    
    [JsonProperty("total_price")]
    public double TotalPrice { get; set; }
    
    [JsonProperty("notes")]
    public string Notes { get; set; }
    
    [JsonProperty("employee_notes")]
    public string EmployeeNotes { get; set; }
    
    
    [JsonProperty("event")]
    public string Event { get; set; }
    
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("last_changed_at")]
    public DateTime LastChangedAt { get; set; }
    
    [JsonProperty("expired")]
    public bool Expired { get; set; }
    
    [JsonProperty("completed")]
    public bool Completed { get; set; }
}