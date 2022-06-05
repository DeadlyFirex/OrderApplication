using Newtonsoft.Json;
#pragma warning disable CS8618

namespace OrderApplication.Models;

public class Data
{
    [JsonProperty("id")] 
    public int Id { get; set; }

    [JsonProperty("uuid")] 
    public string Uuid { get; set; }


    [JsonProperty("events_hash")] 
    public string EventsHash { get; set; }

    [JsonProperty("products_hash")] 
    public string ProductsHash { get; set; }

    [JsonProperty("users_hash")] 
    public string UsersHash { get; set; }

    [JsonProperty("orders_hash")] 
    public string OrdersHash { get; set; }


    [JsonProperty("events_last_changed")] 
    public string EventsLastChangedAt { get; set; }

    [JsonProperty("products_last_changed")]
    public string ProductsLastChangedAt { get; set; }

    [JsonProperty("users_last_changed")] 
    public string UsersLastChangedAt { get; set; }

    [JsonProperty("orders_last_changed")] 
    public string OrdersLastChangedAt { get; set; }
}