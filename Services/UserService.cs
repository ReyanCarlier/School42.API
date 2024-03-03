using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;
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
        
        /// <summary>
        /// Gets the location stats of a user between given dates.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="login"></param>
        /// <param name="beginAt"></param>
        /// <param name="endAt"></param>
        /// <param name="timeZone"></param>
        /// <returns></returns>
        public static async Task<Dictionary<string, string>?> GetUserLocationStatsAsync(HttpContext httpContext, string login, string? beginAt = null, string? endAt = null, string? timeZone = null)
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

            var url = $"https://api.intra.42.fr/v2/users/{login}/locations_stats";

            var queryParameters = new List<string>();
            if (!string.IsNullOrEmpty(beginAt)) queryParameters.Add($"begin_at={beginAt}");
            if (!string.IsNullOrEmpty(endAt)) queryParameters.Add($"end_at={endAt}");
            if (!string.IsNullOrEmpty(timeZone)) queryParameters.Add($"time_zone={timeZone}");

            if (queryParameters.Any())
            {
                url += "?" + string.Join("&", queryParameters);
            }

            var response = await _client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            var locationStats = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            return locationStats;
        }
        
        public static async Task<List<User>?> GetEntityUsersAsync(HttpContext httpContext, string entityId, string entityPath)
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

            var response = await _client.GetAsync($"https://api.intra.42.fr/v2/{entityPath}/{entityId}/users");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var json = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(json);
            return users;
        }

        public static async Task<List<User>?> GetDashUsersAsync(HttpContext httpContext, string dashId)
        {
            return await GetEntityUsersAsync(httpContext, dashId, "dashes");
        }

        public static async Task<List<User>?> GetEventUsersAsync(HttpContext httpContext, string eventId)
        {
            return await GetEntityUsersAsync(httpContext, eventId, "events");
        }

        public static async Task<List<User>?> GetAccreditationUsersAsync(HttpContext httpContext, string accreditationId)
        {
            return await GetEntityUsersAsync(httpContext, accreditationId, "accreditations");
        }

        public static async Task<List<User>?> GetTeamUsersAsync(HttpContext httpContext, string teamId)
        {
            return await GetEntityUsersAsync(httpContext, teamId, "teams");
        }

        public static async Task<List<User>?> GetProjectUsersAsync(HttpContext httpContext, string projectId)
        {
            return await GetEntityUsersAsync(httpContext, projectId, "projects");
        }

        public static async Task<List<User>?> GetPartnershipUsersAsync(HttpContext httpContext, string partnershipId)
        {
            return await GetEntityUsersAsync(httpContext, partnershipId, "partnerships");
        }

        public static async Task<List<User>?> GetExpertiseUsersAsync(HttpContext httpContext, string expertiseId)
        {
            return await GetEntityUsersAsync(httpContext, expertiseId, "expertises");
        }
        
        public static async Task<List<User>?> GetCoalitionUsersAsync(HttpContext httpContext, string coalitionId)
        {
            return await GetEntityUsersAsync(httpContext, coalitionId, "coalitions");
        }
        
        public static async Task<List<User>?> GetCursusUsersAsync(HttpContext httpContext, string cursusId)
        {
            return await GetEntityUsersAsync(httpContext, cursusId, "cursus");
        }
        
        public static async Task<List<User>?> GetCampusUsersAsync(HttpContext httpContext, string campusId)
        {
            return await GetEntityUsersAsync(httpContext, campusId, "campus");
        }

        public static async Task<List<User>?> GetAchievementUsersAsync(HttpContext httpContext, string achievementId)
        {
            return await GetEntityUsersAsync(httpContext, achievementId, "achievements");
        }
        
        public static async Task<List<User>?> GetTitleUsersAsync(HttpContext httpContext, string titleId)
        {
            return await GetEntityUsersAsync(httpContext, titleId, "titles");
        }
        
        public static async Task<List<User>?> GetQuestUsersAsync(HttpContext httpContext, string questId)
        {
            return await GetEntityUsersAsync(httpContext, questId, "quests");
        }
        
        public static async Task<List<User>?> GetGroupUsersAsync(HttpContext httpContext, string groupId)
        {
            return await GetEntityUsersAsync(httpContext, groupId, "groups");
        }
        
        public static async Task<bool> AddCorrectionPointsAsync(HttpContext httpContext, string userId, string reason, int amount = 1)
        {
            if (httpContext.User.Identity is { IsAuthenticated: false })
            {
                return false;
            }
            var oAuthToken = await GetTokenAsync(httpContext);
            if (oAuthToken == null)
            {
                return false;
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", oAuthToken);

            var payload = new
            {
                reason = reason,
                amount = amount.ToString()
            };

            var jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"https://api.intra.42.fr/v2/users/{userId}/correction_points/add", content);
            return response.IsSuccessStatusCode;
        }
        
        public static async Task<bool> RemoveCorrectionPointsAsync(HttpContext httpContext, string userId, string reason, int amount = 1)
        {
            if (httpContext.User.Identity is { IsAuthenticated: false })
            {
                return false;
            }
            var oAuthToken = await GetTokenAsync(httpContext);
            if (oAuthToken == null)
            {
                return false;
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", oAuthToken);

            var payload = new
            {
                reason = reason,
                amount = amount.ToString()
            };

            var jsonPayload = JsonSerializer.Serialize(payload);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"https://api.intra.42.fr/v2/users/{userId}/correction_points/remove"),
                Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json")
            };

            var response = await _client.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
        
        // TODO - Implement the rest of the userData object as a Class
        public static async Task<User?> CreateUserAsync(HttpContext httpContext, object userData)
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

            var jsonPayload = JsonSerializer.Serialize(userData);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://api.intra.42.fr/v2/users", content);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<User>(jsonResponse);
            return user;
        }
        
        public static async Task<List<Accreditation>?> GetAccreditationsAsync(HttpContext httpContext, string? sort = null, Dictionary<string, string>? filters = null, int pageNumber = 1, int pageSize = 30)
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

            var queryParams = new List<string>();
            if (!string.IsNullOrEmpty(sort)) queryParams.Add($"sort={sort}");
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    queryParams.Add($"filter[{filter.Key}]={filter.Value}");
                }
            }
            queryParams.Add($"page[number]={pageNumber}");
            queryParams.Add($"page[size]={pageSize}");

            var query = string.Join("&", queryParams);
            var response = await _client.GetAsync($"https://api.intra.42.fr/v2/accreditations?{query}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var json = await response.Content.ReadAsStringAsync();
            var accreditations = JsonSerializer.Deserialize<List<Accreditation>>(json);
            return accreditations;
        }

        public static async Task<Accreditation?> GetAccreditationByIdAsync(HttpContext httpContext, int id)
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

            var response = await _client.GetAsync($"https://api.intra.42.fr/v2/accreditations/{id}");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<Accreditation>(jsonResponse) : null;
        }
        
        public static async Task<List<Achievement>?> GetAllAchievementsAsync(HttpContext httpContext)
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

            var response = await _client.GetAsync("https://api.intra.42.fr/v2/achievements");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<List<Achievement>>(jsonResponse) : null;
        }
        
        public static async Task<List<Achievement>?> GetCursusAchievementsAsync(HttpContext httpContext, int cursusId)
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
            var response = await _client.GetAsync($"https://api.intra.42.fr/v2/cursus/{cursusId}/achievements");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<List<Achievement>>(jsonResponse) : null;
        }

        public static async Task<List<Achievement>?> GetCampusAchievementsAsync(HttpContext httpContext, int campusId)
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
            var response = await _client.GetAsync($"https://api.intra.42.fr/v2/campus/{campusId}/achievements");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<List<Achievement>>(jsonResponse) : null;
        }

        public static async Task<List<Achievement>?> GetTitleAchievementsAsync(HttpContext httpContext, int titleId)
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
            var response = await _client.GetAsync($"https://api.intra.42.fr/v2/titles/{titleId}/achievements");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<List<Achievement>>(jsonResponse) : null;
        }

        public static async Task<Achievement?> GetAchievementByIdAsync(HttpContext httpContext, int achievementId)
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
            var response = await _client.GetAsync($"https://api.intra.42.fr/v2/achievements/{achievementId}");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<Achievement>(jsonResponse) : null;
        }
        
        public static async Task<List<Achievement>?> GetEntityAchievementsAsync(HttpContext httpContext, int entityId, string entityType)
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
            var response = await _client.GetAsync($"https://api.intra.42.fr/v2/{entityType}/{entityId}/achievements");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<List<Achievement>>(jsonResponse) : null;
        }

        public static async Task<List<AchievementUser>?> GetAchievementUsersAsync(HttpContext httpContext, int achievementId)
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
            var response = await _client.GetAsync($"https://api.intra.42.fr/v2/achievements/{achievementId}/achievements_users");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<List<AchievementUser>>(jsonResponse) : null;
        }

        public static async Task<List<AchievementUser>?> GetAllAchievementsUsersAsync(HttpContext httpContext)
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
            var response = await _client.GetAsync("https://api.intra.42.fr/v2/achievements_users");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<List<AchievementUser>>(jsonResponse) : null;
        }
        
        public static async Task<AchievementUser?> GetAchievementsUserByIdAsync(HttpContext httpContext, int id)
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
            var response = await _client.GetAsync($"https://api.intra.42.fr/v2/achievements_users/{id}");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<AchievementUser>(jsonResponse) : null;
        }


    }

    
    
    
}

