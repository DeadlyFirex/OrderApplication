using System;
using System.Collections.Generic;
using Newtonsoft.Json;
#pragma warning disable CS8618

namespace OrderApplication.Models;

public class User
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("uuid")]
    public string Uuid { get; set; }
    
    [JsonProperty("username")]
    public string Username { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("email")]
    public string Email { get; set; }
    
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }
    
    [JsonProperty("address")]
    public string Address { get; set; }
    
    [JsonProperty("postal_code")]
    public string PostalCode { get; set; }
    
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("country")]
    public string Country { get; set; }
    
    
    [JsonProperty("flags")]
    public List<string> Flags { get; set; }
    
    [JsonProperty("admin")]
    public bool Admin { get; set; }
    
    [JsonProperty("password")]
    public string Password { get; set; }
    
    [JsonProperty("secret")]
    public string Secret { get; set; }
    
    [JsonProperty("token")]
    public string Token { get; set; }
    
    [JsonProperty("tags")]
    public List<string> Tags { get; set; }
    
    
    [JsonProperty("active")]
    public bool Active { get; set; }
    
    [JsonProperty("last_action_at")]
    public DateTime LastActionAt { get; set; }
    
    [JsonProperty("last_action_ip")]
    public string LastActionIp { get; set; }
    
    [JsonProperty("last_action")]
    public string LastAction { get; set; }
    
    [JsonProperty("last_login_at")]
    public DateTime LastLoginAt { get; set; }
    
    [JsonProperty("last_login_ip")]
    public string LastLoginIp { get; set; }
    
    [JsonProperty("login_count")]
    public int LoginCount { get; set; }
}