using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using OrderApplication.Models.Static;
using OrderApplication.Models.Static.Responses;
using RestSharp;
using RestSharp.Authenticators;
#pragma warning disable CS8603
#pragma warning disable CS8619
#pragma warning disable CS8602

namespace OrderApplication.Services;

internal sealed class Client
{
    private float _lifetime;
    private readonly string _token;
    private RestClient _client;

    internal Client(string url, int port, string username, string password)
    {
        // Define the cancellation token.
        var source = new CancellationTokenSource();
        var token = source.Token;

        var address = $"{url}:{port}";
        var options = new RestClientOptions(address) 
        {
            ThrowOnAnyError = false,
            ThrowOnDeserializationError = false,
            FollowRedirects = true,
            MaxRedirects = 3,
            Timeout = 1000
        };
        _client = new RestClient(options);

        var request = new RestRequest("auth/login")
            .AddHeader("Connection", "Close")
            .AddJsonBody(new Auth
            {
                username = username,
                password = password
            });

        var response = _client.ExecutePostAsync<AuthResponse>(request, token).GetAwaiter().GetResult();

        if (response.ErrorException is {InnerException: SocketException})
        {
            throw new ApplicationException($"No connection could be established to {address}");
        }

        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                break;
            case HttpStatusCode.TooManyRequests:
                break;
            case HttpStatusCode.Unauthorized:
                throw new UnauthorizedAccessException("Incorrect username/password");
            default:
                throw new ApplicationException($"Unexpected code {response.StatusCode} with {response.Content}");
        }

        _token = response
            .Data
            .Login
            .Token;
        _lifetime = response
            .Data
            .Login
            .Lifetime;
        _client.Authenticator = new JwtAuthenticator(_token);
        }

    internal string GetVersion() =>
        _client.ExecuteGetAsync<VersionResponse>(new RestRequest("/version"))
            .Result
            .Data
            .Details
            .Link;
    
    internal int GetHealth() =>
        _client.ExecuteGetAsync<VersionResponse>(new RestRequest("/health"))
            .Result
            .Data
            .Status;

    internal LastChangedResponse GetLastChanges() =>
        _client.ExecuteGetAsync<LastChangedResponse>(new RestRequest("/last_changed"))
            .Result
            .Data;
}

public class Main
{
    public static void main()
    {
        var client = new Client("http://localhost", 5000, "admin", "admin");
        Console.WriteLine(client.GetHealth());
        Console.WriteLine(client.GetVersion());
        var result = client.GetLastChanges();
        Console.WriteLine(result.Message);
        Console.WriteLine(result.result.First().EventsLastChangedAt.Year);
        Console.WriteLine(result.result.First().EventsHash ?? "null");
    }
}