using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
#pragma warning disable CS8618

namespace OrderApplication.Models;

public class User
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }
    
    [JsonPropertyName("username")]
    public string Username { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
    
    [JsonPropertyName("address")]
    public string Address { get; set; }
    
    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonPropertyName("country")]
    public string Country { get; set; }
    
    
    [JsonPropertyName("flags")]
    public List<string> Flags { get; set; }
    
    [JsonPropertyName("admin")]
    public bool Admin { get; set; }
    
    [JsonPropertyName("password")]
    public string Password { get; set; }
    
    [JsonPropertyName("secret")]
    public string Secret { get; set; }
    
    [JsonPropertyName("token")]
    public string Token { get; set; }
    
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }
    
    
    [JsonPropertyName("active")]
    public bool Active { get; set; }
    
    [JsonPropertyName("last_action_at")]
    public DateTime LastActionAt { get; set; }
    
    [JsonPropertyName("last_action_ip")]
    public string LastActionIp { get; set; }
    
    [JsonPropertyName("last_action")]
    public string LastAction { get; set; }
    
    [JsonPropertyName("last_login_at")]
    public DateTime LastLoginAt { get; set; }
    
    [JsonPropertyName("last_login_ip")]
    public string LastLoginIp { get; set; }
    
    [JsonPropertyName("login_count")]
    public int LoginCount { get; set; }
}