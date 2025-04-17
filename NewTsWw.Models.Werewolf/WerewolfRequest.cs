using System.Net.Http.Json;
using System.Text.Json;

namespace NewTsWw.Models.Werewolf;

public enum WerewolfRequestEndpoint
{
    PlayerStats,
    PlayerAchievements,
    PlayerKills,
    PlayerDeaths,
    PlayerKilledby
}

public class WerewolfRequest : IDisposable
{
    private readonly HttpClient _httpClient;

    public WerewolfRequest()
    {
        _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(5),
            BaseAddress = new Uri("https://www.tgwerewolf.com/Stats")
        };
    }

    public Task<TValue?> GetEndpoint<TValue>(
        WerewolfRequestEndpoint endpoint, long userId)
            => _httpClient.GetFromJsonAsync<TValue>(_httpClient.BaseAddress + $"/{endpoint}/?pid={userId}&json=true");

    public async Task<AchievementInfo[]?> GetAchievements(long userId)
    {
        try
        {
            return await GetEndpoint<AchievementInfo[]>(WerewolfRequestEndpoint.PlayerAchievements, userId);
        }
        catch (HttpRequestException)
        {
            return null;
        }
        catch (JsonException)
        {
            return [];
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _httpClient.Dispose();
    }
}
