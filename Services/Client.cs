using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using OrderApplication.Models.Static;
using OrderApplication.Models.Static.Responses;
using RestSharp;
using RestSharp.Authenticators;
#pragma warning disable CS8604
#pragma warning disable CS8603
#pragma warning disable CS8619
#pragma warning disable CS8602

namespace OrderApplication.Services;

internal sealed class Client
{
    private string _username;
    private string _password;
    private string _token;
    private string _uuid;
    private float _lifetime;
    private DateTime _lifetimeNow;
    private RestClient _client;
    private int _sleeping;

    internal Client(string url, int port, string username, string password)
    {
        var address = $"{url}:{port}";
        var options = new RestClientOptions(address) 
        {
            ThrowOnAnyError = false,
            ThrowOnDeserializationError = true,
            FollowRedirects = true,
            Timeout = 1000
        };
        _client = new RestClient(options);
        
        PostLogin(username, password);
        _username = username;
        _password = password;
    }
    
    [Obsolete("Avoid using this constructor as it may lead to issues.", true)]
    internal Client(string url, int port)
    {
        var address = $"{url}:{port}";
        var options = new RestClientOptions(address)
        {
            ThrowOnAnyError = false,
            ThrowOnDeserializationError = true,
            FollowRedirects = true,
            Timeout = 1000
        };
        _client = new RestClient(options);
    
        _lifetime = 0;
    }

    private bool GetLifetimeExpired() =>
        DateTime.Now > _lifetimeNow;
    
    private void CheckStatus(RestResponseBase response, bool isFirstRequest = false)
    {
        if (!isFirstRequest)
        {
            if (_lifetime == 0 || GetLifetimeExpired())
            {
                PostLogin(_username, _password);
            }
        }

        if (response.ErrorException is {InnerException: SocketException})
        {
            throw new ApplicationException($"No connection could be established");
        }
        
        switch (response.StatusCode)
        {
            case HttpStatusCode.BadRequest:
                throw new ArgumentException($"Bad argument received: {response.Content}");
            case HttpStatusCode.Unauthorized:
                throw new UnauthorizedAccessException($"Incorrect username/password: {response.Content}");
            case HttpStatusCode.UnprocessableEntity:
                PostLogin(_username, _password);
                break;
            case HttpStatusCode.Forbidden:
                throw new UnauthorizedAccessException($"Forbidden, no access to requested endpoint: {response.Content}");
            case HttpStatusCode.MethodNotAllowed:
                throw new UnauthorizedAccessException($"Bad method: {response.Content}");
        }
    }

    private static int CalculateSleepTime(RestResponseBase response, bool inMilliseconds = true)
    {
        var result = Convert.ToInt32(
            response.Headers
                .ToList()
                .Find(x => x.Name == "Retry-After")
                .Value
                .ToString());
        if (inMilliseconds) result *= 1000;
        return result + 100;
    }

    internal async Task<string> GetVersion()
    {
        var request = new RestRequest("/version");
        var response = await _client.ExecuteGetAsync<VersionResponse>(request);

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            await Task.Delay(CalculateSleepTime(response));
            response = await _client.ExecuteGetAsync<VersionResponse>(request);

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                await Task.Delay(CalculateSleepTime(response) * 2);
                response = await _client.ExecuteGetAsync<VersionResponse>(request);
            }
        }

        CheckStatus(response);
        
        return response.Data.Details.Link;
    }
    
    internal async Task<int> GetHealth()
    {
        var request = new RestRequest("/version");
        var response = await _client.ExecuteGetAsync<BaseResponse>(request);
        
        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            await Task.Delay(CalculateSleepTime(response));
            response = await _client.ExecuteGetAsync<BaseResponse>(request);

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                await Task.Delay(CalculateSleepTime(response) * 2);
                response = await _client.ExecuteGetAsync<BaseResponse>(request);
            }
        }

        CheckStatus(response);

        return response.Data.Status;
    }

    internal async Task<LastChangedResponse> GetLastChanges()
    {
        var request = new RestRequest("/last_changed");
        var response = await _client.ExecuteGetAsync<LastChangedResponse>(request);
        
        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            await Task.Delay(CalculateSleepTime(response));
            response = await _client.ExecuteGetAsync<LastChangedResponse>(request);

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                await Task.Delay(CalculateSleepTime(response) * 2);
                response = await _client.ExecuteGetAsync<LastChangedResponse>(request);
            }
        }

        CheckStatus(response);

        return response.Data;
    }

    private void PostLogin(string username, string password)
    {
        var request = new RestRequest("auth/login")
            .AddHeader("Connection", "Close")
            .AddJsonBody(new Auth
            {
                username = username,
                password = password
            });
        
        var response = _client.ExecutePostAsync<AuthResponse>(request).GetAwaiter().GetResult();

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            System.Threading.Thread.Sleep(CalculateSleepTime(response) * 1000);
            response = _client.ExecutePostAsync<AuthResponse>(request).Result;
        }

        CheckStatus(response, true);

        _token = response
            .Data
            .Login
            .Token;
        _lifetime = response
            .Data
            .Login
            .Lifetime;
        _lifetimeNow = DateTime.Now.AddSeconds(_lifetime);
        _client.Authenticator = new JwtAuthenticator(_token);
    }
    
    internal async Task<bool> PostAsyncLogin(string username, string password)
    {
        var request = new RestRequest("auth/login")
            .AddHeader("Connection", "Close")
            .AddJsonBody(new Auth
            {
                username = username,
                password = password
            });
        
        var response = await _client.ExecutePostAsync<AuthResponse>(request);

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            await Task.Delay(CalculateSleepTime(response));
            response = await _client.ExecutePostAsync<AuthResponse>(request);

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                await Task.Delay(CalculateSleepTime(response) * 2);
                response = await _client.ExecutePostAsync<AuthResponse>(request);
            }
        }

        CheckStatus(response, true);

        _token = response
            .Data
            .Login
            .Token;
        _lifetime = response
            .Data
            .Login
            .Lifetime;
        _lifetimeNow = DateTime.Now.AddSeconds(_lifetime);
        _client.Authenticator = new JwtAuthenticator(_token);

        return response.IsSuccessful;
    }

    internal async Task<string> GetLogin()
    {
        var request = new RestRequest("auth/test");
        var response = await _client.ExecuteGetAsync<AuthCheckResponse>(request);

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            await Task.Delay(CalculateSleepTime(response));
            response = await _client.ExecuteGetAsync<AuthCheckResponse>(request);

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                await Task.Delay(CalculateSleepTime(response) * 2);
                response = await _client.ExecuteGetAsync<AuthCheckResponse>(request);
            }
        }

        CheckStatus(response);
        
        return response.Data.result.Uuid;
    }
    
    internal async Task<Tuple<string, bool>> GetAdminLogin()
    {
        var request = new RestRequest("auth/admin/test");
        var response = await _client.ExecuteGetAsync<AdminAuthCheckResponse>(request);

        if (response.StatusCode == HttpStatusCode.TooManyRequests)
        {
            await Task.Delay(CalculateSleepTime(response));
            response = await _client.ExecuteGetAsync<AdminAuthCheckResponse>(request);

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                await Task.Delay(CalculateSleepTime(response) * 2);
                response = await _client.ExecuteGetAsync<AdminAuthCheckResponse>(request);
            }
        }

        CheckStatus(response);
        
        return Tuple.Create(response.Data.result.Uuid, response.Data.result.IsAdmin);
    }
}