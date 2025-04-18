using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;
using System.Reflection;
using System.Net;

namespace NewTsWw.Models.Werewolf;

public enum WerewolfRequestEndpoint
{
    [Display(Name = "Stats"), Description("Overall player stats.")]
    PlayerStats,

    [Display(Name = "Achievements"), Description("Player earned achievements so far.")]
    PlayerAchievements,

    [Display(Name = "Most kills"), Description("The people you killed the most.")]
    PlayerKills,

    [Display(Name = "Deaths methods"), Description("Player's most common death methods.")]
    PlayerDeaths,

    [Display(Name = "Most killed by"), Description("The people who killed you the most.")]
    PlayerKilledby
}

public class WerewolfRequest : IDisposable
{
    private readonly HttpClient _httpClient;

    public Uri? BaseAddress { get; }

    public WerewolfRequest(Uri? baseAddress = default)
    {
        BaseAddress = baseAddress;
        _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(5),
            BaseAddress = BaseAddress?? new Uri("https://www.tgwerewolf.com/Stats")
        };
    }

    public Task<TValue?> GetEndpoint<TValue>(
        WerewolfRequestEndpoint endpoint, long userId)
            => _httpClient.GetFromJsonAsync<TValue>(_httpClient.BaseAddress + WebUtility.UrlEncode($"/{endpoint}/?pid={userId}&json=true"));

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

public static partial class Extensions
{
    public static string GetDescription(this WerewolfRequestEndpoint value)
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[]? attributes =
            (DescriptionAttribute[]?)fi?.GetCustomAttributes(
            typeof(DescriptionAttribute),
            false);

        if (attributes != null &&
            attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }

    public static string GetName(this WerewolfRequestEndpoint value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());

        if (fieldInfo?.GetCustomAttributes(
            typeof(DisplayAttribute), false) is not DisplayAttribute[] descriptionAttributes) return string.Empty;
        return (descriptionAttributes.Length > 0 ? descriptionAttributes[0].Name : value.ToString())!;
    }
}