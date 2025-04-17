namespace NewTsWw.Models.Werewolf;

public enum WerewolfDayTime
{
    None = 0,

    [WerewolfDayTimeInfo(Name = "شب", Sign = "شب شد و ستاره تو آسمون نشسته!")]
    Night,

    [WerewolfDayTimeInfo(Name = "روز", Sign = "خب روز شد.")]
    Day,

    [WerewolfDayTimeInfo(Name = "اعدام", Sign = "خب دیگه شب شده و همه جمع میشن که رای بدن")]
    Lynch
}

[AttributeUsage(AttributeTargets.Field, Inherited = false)]
public class WerewolfDayTimeInfoAttribute : Attribute
{
    public required string Name { get; set; }

    public required string Sign { get; set; }
}

public static class WerewolfDayTimes
{
    public static readonly Dictionary<WerewolfDayTime, WerewolfDayTimeInfoAttribute> DayTimes;

    static WerewolfDayTimes()
    {
        DayTimes = Enum.GetValues<WerewolfDayTime>()
            .Select(x => (x, x.GetDaytimeInfo()!))
            .Where(x => x.Item2 is not null)
            .ToDictionary(x => x.x, x => x.Item2);
    }

    public static WerewolfDayTime? GetDayTime(this string text)
    {
        var dayTime = DayTimes
            .FirstOrDefault(x => text.Contains(x.Value.Sign))
            .Key;

        return dayTime == WerewolfDayTime.None ? null : dayTime;
    }

    public static WerewolfDayTimeInfoAttribute? GetDaytimeInfo(this WerewolfDayTime dayTime)
    {
        if (dayTime.GetType()
            .GetField(dayTime.ToString())?
            .GetCustomAttributes(typeof(WerewolfDayTimeInfoAttribute), false)
            .FirstOrDefault() is not WerewolfDayTimeInfoAttribute attr) return null;

        return attr;
    }
}