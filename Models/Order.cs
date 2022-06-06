using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
#pragma warning disable CS8618

namespace OrderApplication.Models;

internal class Order
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }
    
    
    [JsonPropertyName("products")]
    public List<string> Products { get; set; }
    
    [JsonPropertyName("total_price")]
    public double TotalPrice { get; set; }
    
    [JsonPropertyName("notes")]
    public string Notes { get; set; }
    
    [JsonPropertyName("employee_notes")]
    public string EmployeeNotes { get; set; }
    
    
    [JsonPropertyName("event")]
    public string Event { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonPropertyName("last_changed_at")]
    public DateTime LastChangedAt { get; set; }
    
    [JsonPropertyName("expired")]
    public bool Expired { get; set; }
    
    [JsonPropertyName("completed")]
    public bool Completed { get; set; }
}