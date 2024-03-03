using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using School42.API.Classes;

namespace School42.API.Services
{
    public class UserService
    {
        private static HttpClient _client = new();

        public static async Task<User?> GetUserInfoFromJson(HttpContext httpContext)
        {
            if (httpContext.User.Identity is { IsAuthenticated: false })
            {
                return null;
            }
            var oAuthToken = await GetTokenAsync(httpContext);
            if (oAuthToken == null)
            {
                return null;
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", oAuthToken);
            var response = await _client.GetAsync("https://api.intra.42.fr/v2/me");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine(json);
            var user = JsonSerializer.Deserialize<User>(json);
            return user;
        }

        public static async Task<User?> GetUserFromLoginAsync(HttpContext httpContext, string login)
        {
            if (httpContext.User.Identity is { IsAuthenticated: false })
            {
                return null;
            }
            var oAuthToken = await GetTokenAsync(httpContext);
            if (oAuthToken == null)
            {
                return null;
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", oAuthToken);
            var response = await _client.GetAsync($"https://api.intra.42.fr/v2/users/{login}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var json = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<User>(json);
            return user;
        }

        /// <summary>
        /// Gets the user's 42 School oAuth2 access token
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private static async Task<string?> GetTokenAsync(HttpContext httpContext)
        {
            if (httpContext.User.Identity is { IsAuthenticated: false })
            {
                return null;
            }

            var tk = await httpContext.GetTokenAsync("School42", "access_token");
            return tk;
        }
    }

}

