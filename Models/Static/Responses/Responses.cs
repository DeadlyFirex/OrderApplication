using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrderApplication.Models.Static.Responses;

internal sealed class AuthResponse : BaseResponse
{
    [JsonPropertyName("login")] public LoginData Login { get; set; }

    public class LoginData
    {
        [JsonPropertyName("uuid")] public string Uuid { get; set; }
        [JsonPropertyName("token")] public string Token { get; set; }
        [JsonPropertyName("lifetime")] public float Lifetime { get; set; }
    }
}

internal sealed class VersionResponse : BaseResponse
{
    [JsonPropertyName("details")] public DetailsData Details { get; set; }

    public class DetailsData
    {
        [JsonPropertyName("link")] public string Link { get; set; }
    }
}

internal sealed class LastChangedResponse : BaseResponse
{
    [JsonPropertyName("result")] public List<Data> result { get; set; }
}

internal sealed class AuthCheckResponse : BaseResponse
{
    [JsonPropertyName("login")] public LoginCheckData result { get; set; }

    internal sealed class LoginCheckData
    {
        [JsonPropertyName("uuid")] public string Uuid { get; set; }
    }
}

internal sealed class AdminAuthCheckResponse : BaseResponse
{
    [JsonPropertyName("login")] public AdminLoginCheckData result { get; set; }

    internal sealed class AdminLoginCheckData
    {
        [JsonPropertyName("uuid")] public string Uuid { get; set; }
        [JsonPropertyName("admin")] public bool IsAdmin { get; set; }
    }
}