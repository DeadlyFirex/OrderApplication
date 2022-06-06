using System.Text.Json.Serialization;

namespace OrderApplication.Models.Static.Responses;

internal abstract class BaseResponse
{
    [JsonPropertyName("status")] public int Status { get; set; }
    [JsonPropertyName("message")] public string Message { get; set; }
}