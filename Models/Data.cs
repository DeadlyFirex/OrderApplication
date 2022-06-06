using System;
using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace OrderApplication.Models;

public class Data
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("uuid")] public string Uuid { get; set; }

    [JsonPropertyName("events_hash")] public string EventsHash { get; set; }

    [JsonPropertyName("products_hash")] public string ProductsHash { get; set; }

    [JsonPropertyName("users_hash")] public string UsersHash { get; set; }

    [JsonPropertyName("orders_hash")] public string OrdersHash { get; set; }

    [JsonPropertyName("events_last_changed")]
    public DateTime EventsLastChangedAt { get; set; }

    [JsonPropertyName("products_last_changed")]
    public DateTime ProductsLastChangedAt { get; set; }

    [JsonPropertyName("users_last_changed")]
    public DateTime UsersLastChangedAt { get; set; }

    [JsonPropertyName("orders_last_changed")]
    public DateTime OrdersLastChangedAt { get; set; }
}