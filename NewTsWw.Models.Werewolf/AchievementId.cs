using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json.Serialization;

namespace NewTsWw.Models.Werewolf;

public class AchievementInfo
{
    [JsonIgnore]
    public AchievementId AchievementId { get; }

    [JsonPropertyName("name")]
    public string Name { get; }

    [JsonPropertyName("desc")]
    public string Description { get; }

    public AchievementInfo(
        AchievementId achievementId, string name, string description)
    {
        AchievementId = achievementId;
        Name = name;
        Description = description;
    }

    [JsonConstructor]
    public AchievementInfo(string name, string description)
    {
        Name = name;
        Description = description;
        AchievementId = Achievements.All.First(x => x.Name == Name).AchievementId;
    }

    public override string ToString()
    {
        return $"{Name}\n- {Description}";
    }
}

public enum AchievementId
{
    [AchievementDetailedInfo(IncludeInSearch = false)]
    [Display(Name = "None"), Description("You haven't played a game yet!")]
    None = 0,

    [AchievementDetailedInfo]
    [Display(Name = "Welcome to Hell"), Description("Play a game")]
    WelcomeToHell = 1,

    [AchievementDetailedInfo]
    [Display(Name = "Welcome to the Asylum"), Description("Play a chaos game")]
    WelcomeToAsylum = 2,

    [AchievementDetailedInfo]
    [Display(Name = "Alzheimer's Patient"), Description("Play a game with an amnesia language pack")]
    AlzheimerPatient = 3,

    [AchievementDetailedInfo]
    [Display(Name = "O HAI DER!"), Description("Play a game with Para's secret account (not @para949)")]
    OHAIDER = 4,

    [AchievementDetailedInfo]
    [Display(Name = "Spy vs Spy"), Description("Play a game in secret mode (no role reveal)")]
    SpyVsSpy = 5,

    [AchievementDetailedInfo(IncludeInSearch = false)]
    [Display(Name = "Explorer"), Description("Play at least 2 games each in 10 different groups")]
    Explorer = 6,

    [AchievementDetailedInfo(IncludeInSearch = false)]
    [Display(Name = "Linguist"), Description("Play at least 2 games each in 10 different language packs")]
    Linguist = 7,

    [AchievementDetailedInfo]
    [Display(Name = "I Have No Idea What I'm Doing"), Description("Play a game in secret amnesia mode")]
    NoIdeaWhat = 8,

    [GameConditions.FixPlayerCount(35)]
    [AchievementDetailedInfo]
    [Display(Name = "Enochlophobia"), Description("Play a 35 player game")]
    Enochlophobia = 9,

    [GameConditions.FixPlayerCount(5)]
    [AchievementDetailedInfo]
    [Display(Name = "Introvert"), Description("Play a 5 player game")]
    Introvert = 10,

    [AchievementDetailedInfo]
    [Display(Name = "Naughty!"), Description("Play a game using any NSFW language pack")]
    Naughty = 11,

    [AchievementDetailedInfo]
    [Display(Name = "Dedicated"), Description("Play 100 games")]
    Dedicated = 12,

    [AchievementDetailedInfo]
    [Display(Name = "Obsessed"), Description("Play 1000 games")]
    Obsessed = 13,

    [AchievementDetailedInfo(IncludeInSearch = false)]
    [Display(Name = "Here's Johnny!"), Description("Get 50 kills as the serial killer")]
    HereJohnny = 14,

    [AchievementDetailedInfo(IncludeInSearch = false)]
    [Display(Name = "I've Got Your Back"), Description("Save 50 people as the Guardian Angel")]
    GotYourBack = 15,

    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Tanner)]
    [AchievementDetailedInfo]
    [Display(Name = "Masochist"), Description("Win a game as the Tanner")]
    Masochist = 16,

    [GameConditions.LeastPlayerCount(10)]
    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Drunk)]
    [AchievementDetailedInfo]
    [Display(Name = "Wobble Wobble"), Description("Survive a game as the drunk (at least 10 players)")]
    Wobble = 17,

    [GameConditions.LeastPlayerCount(20)]
    [AchievementDetailedInfo]
    [Display(Name = "Inconspicuous"), Description("In a game of 20 or more people, do not get a single lynch vote against you (and survive)")]
    Inconspicuous = 18,

    [AchievementDetailedInfo]
    [Display(Name = "Survivalist"), Description("Survive 100 games")]
    Survivalist = 19,

    [AchievementDetailedInfo(IncludeInSearch = false)]
    [Display(Name = "Black Sheep"), Description("Get lynched first 3 games in a row")]
    BlackSheep = 20,

    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Harlot)]
    [AchievementDetailedInfo]
    [Display(Name = "Promiscuous"), Description("As the harlot, survive a 5+ night game without staying home or visiting the same person more than once")]
    Promiscuous = 21,

    [GameConditions.MustHaveRole(WerewolfRole.Mason)]
    [GameConditions.LeastRoleCount(2, WerewolfRole.Mason)]
    [AchievementDetailedInfo]
    [Display(Name = "Mason Brother"), Description("Be one of at least two surviving masons in a game")]
    MasonBrother = 22,

    [GameConditions.LeastRoleCount(
        2,
        WerewolfRole.Doppelgänger,
        WerewolfRole.Cursed,
        WerewolfRole.Thief,
        WerewolfRole.WildChild,
        WerewolfRole.WiseElder,
        WerewolfRole.AlphaWolf,
        WerewolfRole.Tanner,
        WerewolfRole.Apperinace)]
    [AchievementDetailedInfo]
    [Display(Name = "Double Shifter"), Description("Change roles twice in one game (cult conversion does not count)")]
    DoubleShifter = 23,

    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Hunter)]
    [AchievementDetailedInfo]
    [Display(Name = "Hey Man, Nice Shot"), Description("As the hunter, use your dying shot to kill a wolf or serial killer")]
    HeyManNiceShot = 24,

    // TODO: Test |
    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Cultist | WerewolfRole.Werewolf)] // TODO: People can become cultists
    [AchievementDetailedInfo]
    [Display(Name = "That's Why You Don't Stay Home"), Description("As a wolf or cultist, kill or convert a harlot that stayed home")]
    DontStayHome = 25,

    [GameConditions.MustHaveRole(WerewolfRole.Seer)]
    [GameConditions.LeastRoleCount(2, WerewolfRole.Seer)]
    [AchievementDetailedInfo]
    [Display(Name = "Double Vision"), Description("Be one of two seers at the same time")]
    DoubleVision = 26,

    [AchievementDetailedInfo]
    [Display(Name = "Double Kill"), Description("Be part of the Serial Killer / Hunter ending")]
    DoubleKill = 27,

    [GameConditions.RoleMustExists(WerewolfRole.Beholder)]
    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Seer)]
    [AchievementDetailedInfo]
    [Display(Name = "Should Have Known"), Description("As the Seer, reveal the Beholder")]
    ShouldHaveKnown = 28,

    [GameConditions.BeforeDay(1)]
    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Seer)]
    [AchievementDetailedInfo]
    [Display(Name = "I See a Lack of Trust"), Description("As the Seer, get lynched on the first day")]
    LackOfTrust = 29,

    [AchievementDetailedInfo]
    [Display(Name = "Sunday Bloody Sunday"), Description("Be one of at least 4 victims to die in a single night")]
    BloodyNight = 30,

    [AchievementDetailedInfo]
    [Display(Name = "Change Sides Works"), Description("Change roles in a game, and win")]
    ChangingSides = 31,

    [GameConditions.HaveAnyRole(WerewolfRole.Wolves, Priority = 1)]
    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Villager, Combination = GameConditionCombination.Or, Priority = 2)]
    [GameConditions.AnyRoleExists(WerewolfRole.Wolves, WerewolfRole.Villager, Priority = 1)]
    [GameConditions.RoleMustExists(WerewolfRole.Cupid)]
    [AchievementDetailedInfo]
    [Display(Name = "Forbidden Love"), Description("Win as a wolf / villager couple (villager, not village team)")]
    ForbiddenLove = 32,

    [AchievementDetailedInfo(IncludeInSearch = false)]
    [Display(Name = "Developer"), Description("Have a pull request merged into the repo")]
    Developer = 33,

    [AchievementDetailedInfo]
    [Display(Name = "The First Stone"), Description("Be the first to cast a lynch vote 5 times in a single game")]
    FirstStone = 34,

    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Gunner)]
    [AchievementDetailedInfo]
    [Display(Name = "Smart Gunner"), Description("As the Gunner, both of your bullets hit a wolf, serial killer, or cultist")]
    SmartGunner = 35,

    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Detective)]
    [AchievementDetailedInfo]
    [Display(Name = "Streetwise"), Description("Find a different wolf, serial killer, arsonist, or cultist 4 nights in a row as the detective")]
    Streetwise = 36,

    [GameConditions.BeforeDay(1)]
    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Cupid)]
    [AchievementDetailedInfo]
    [Display(Name = "Speed Dating"), Description("Have the bot select you as a lover (cupid failed to choose)")]
    OnlineDating = 37,

    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Fool)]
    [AchievementDetailedInfo]
    [Display(Name = "Even a Stopped Clock is Right Twice a Day"), Description("As the Fool, have at least two of your visions be correct by the end of the game")]
    BrokenClock = 38,

    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Tanner)]
    [AchievementDetailedInfo]
    [Display(Name = "So Close!"), Description("As the Tanner, be tied for the most lynch votes")]
    SoClose = 39,

    [GameConditions.LeastPlayerCount(10)]
    [GameConditions.RoleMustExists(WerewolfRole.Cultist)]
    [AchievementDetailedInfo]
    [Display(Name = "Cultist Convention"), Description("Be one of 10 or more cultists alive at the end of a game")]
    CultCon = 40,

    [GameConditions.BeforeDay(1)]
    [GameConditions.MustHaveRole(WerewolfRole.Cupid)]
    [AchievementDetailedInfo]
    [Display(Name = "Self Loving"), Description("As cupid, pick yourself as one of the lovers")]
    SelfLoving = 41,

    //[GameConditions.AfterDay(1)]
    [GameConditions.HaveAnyRole(WerewolfRole.Wolves)]
    [AchievementDetailedInfo]
    [Display(Name = "Should've Said Something"), Description("As a wolf, your pack eats your lover (first night does not count)")]
    ShouldveMentioned = 42,

    [GameConditions.HasOrCanAcquireRole(WerewolfRole.Tanner)]
    [AchievementDetailedInfo]
    [Display(Name = "Tanner Overkill"), Description("As the Tanner, have everyone (but yourself) vote to lynch you")]
    TannerOverkill = 43,

    [GameConditions.MustHaveRole(WerewolfRole.SerialKiller)] // Consider DG
    [AchievementDetailedInfo]
    [Display(Name = "Serial Samaritan"), Description("As the Serial Killer, kill at least 3 wolves in single game")]
    SerialSamaritan = 44,

    [AchievementDetailedInfo]
    [Display(Name = "Cultist Fodder"), Description("Be the cultist that is sent to attempt to convert the Cult Hunter")]
    CultFodder = 45,

    [AchievementDetailedInfo]
    [Display(Name = "Lone Wolf"), Description("In a chaos game of 10 or more people, be the only wolf - and win")]
    LoneWolf = 46,

    [AchievementDetailedInfo]
    [Display(Name = "Pack Hunter"), Description("Be one of 7 living wolves at one time")]
    PackHunter = 47,

    [AchievementDetailedInfo]
    [Display(Name = "Saved by the Bull(et)"), Description("As a villager, the wolves match the number of villagers, but the game does not end because the gunner has a bullet")]
    GunnerSaves = 48,

    [AchievementDetailedInfo]
    [Display(Name = "In for the Long Haul"), Description("Survive for at least an hour in a single game")]
    LongHaul = 49,

    [AchievementDetailedInfo]
    [Display(Name = "OH SHI-"), Description("Kill your lover on the first night")]
    OhShi = 50,

    [AchievementDetailedInfo]
    [Display(Name = "Veteran"), Description("Play 500 games.  You can now join @werewolfvets")]
    Veteran = 51,

    [AchievementDetailedInfo]
    [Display(Name = "No Sorcery!"), Description("As a wolf, kill your sorcerer")]
    NoSorcery = 52,

    [AchievementDetailedInfo]
    [Display(Name = "Cultist Tracker"), Description("As the cultist hunter, kill at least 3 cultists in one game")]
    CultistTracker = 53,

    [AchievementDetailedInfo]
    [Display(Name = "I'M NOT DRUN-- *BURPPP*"), Description("As the clumsy guy, have at least 3 correct lynches by the end of the game")]
    ImNotDrunk = 54,

    [AchievementDetailedInfo]
    [Display(Name = "Wuffie-Cult"), Description("As the alpha wolf, successfully convert at least 3 victims into wolves")]
    WuffieCult = 55,

    [AchievementDetailedInfo]
    [Display(Name = "Did you guard yourself?"), Description("As the guardian angel, survive after 3 tries guarding an unattacked wolf")]
    DidYouGuardYourself = 56,

    [AchievementDetailedInfo]
    [Display(Name = "Spoiled Rich Brat"), Description("As the prince, still gets lynched even after revealing your identity")]
    SpoiledRichBrat = 57,

    [AchievementDetailedInfo]
    [Display(Name = "Three Little Wolves and a Big Bad Pig"), Description("As the sorcerer, survive a game with three or more alive wolves")]
    ThreeLittleWolves = 58,

    [AchievementDetailedInfo]
    [Display(Name = "President"), Description("As the mayor, successfully cast 3 lynch votes after revealing")]
    President = 59,

    [AchievementDetailedInfo]
    [Display(Name = "I Helped!"), Description("As a wolf cub, the alive pack has 2 successful eat attempts after you die")]
    IHelped = 60,

    [AchievementDetailedInfo]
    [Display(Name = "It Was a Busy Night!"), Description("During the same night, got visited by 3 or more different visiting roles")]
    ItWasABusyNight = 61,

    [AchievementDetailedInfo]
    [Display(Name = "Strongest Alpha"), Description("As the alpha wolf, successfully infect the serial killer!")]
    StrongestAlpha = 62,

    [AchievementDetailedInfo]
    [Display(Name = "Am I Your Seer?"), Description("As the fool, correctly spot the beholder")]
    AmIYourSeer = 63,

    [AchievementDetailedInfo]
    [Display(Name = "Demoted by the Death"), Description("As the hunter, shoot the wise elder with your final shot and die as lowly villager")]
    DemotedByTheDeath = 64,

    [AchievementDetailedInfo]
    [Display(Name = "Wasted Silver"), Description("As the blacksmith, spread your silver dust the same day that the sandman sings")]
    WastedSilver = 65,

    [AchievementDetailedInfo]
    [Display(Name = "Trustworthy!"), Description("As the wolf man, survive and win the game after being checked by seer")]
    Trustworthy = 66,

    [AchievementDetailedInfo]
    [Display(Name = "Deep Love"), Description("As the doppelgänger, choose your lover as role model. What a deep love &lt;3")]
    DeepLove = 67,
    [AchievementDetailedInfo]
    [Display(Name = "Time to retire..."), Description("As the sorcerer, be the last person alive in the village and lose the game")]
    TimeToRetire = 68,

    [AchievementDetailedInfo]
    [Display(Name = "Seeing between Teams"), Description("Be in a seer/sorcerer couple")]
    SeeingBetweenTeams = 69,

    [AchievementDetailedInfo]
    [Display(Name = "Just a Beardy Guy..?"), Description("As the wolf man, be infected by the alpha wolf and become a real werewolf. AWOOOOOOO!")]
    JustABeardyGuy = 70,

    [AchievementDetailedInfo]
    [Display(Name = "That Came Unexpected!"), Description("As tanner, be lynched and win the game when there are only 3 persons left")]
    ThatCameUnexpected = 71,

    [AchievementDetailedInfo]
    [Display(Name = "Now I'm Blind"), Description("As the oracle, fail to get a vision because everyone else has the same role.")]
    NowImBlind = 72,

    [AchievementDetailedInfo]
    [Display(Name = "Every Man for Himself!"), Description("As the pacifist, save yourself from being lynched (at least 50% of votes have been cast for you already)")]
    EveryManForHimself = 73,

    [AchievementDetailedInfo]
    [Display(Name = "My Sweetie so Strong!"), Description("Be in love with the pacifist, and get saved from being lynched by them (at least 50% of votes have been cast for you already)")]
    MySweetieSoStrong = 74,

    [AchievementDetailedInfo]
    [Display(Name = "Cult Leader"), Description("Be a cultist from the beginning of the game, survive and win.")]
    CultLeader = 75,

    [AchievementDetailedInfo]
    [Display(Name = "Thanks, Junior!"), Description("After the wolf pack ate the Drunk, you turn into a wolf and can try to eat someone while the rest of the wolf pack is drunk!")]
    ThanksJunior = 76,

    [AchievementDetailedInfo]
    [Display(Name = "Death Village"), Description("Participate in a game that has no winner.")]
    DeathVillage = 77,

    [AchievementDetailedInfo]
    [Display(Name = "I Lost my Wisdom"), Description("As the wise elder, change your role! Suddenly you're not that wise anymore...")]
    ILostMyWisdom = 78,

    [AchievementDetailedInfo]
    [Display(Name = "Affectionate"), Description("As the harlot, visit your lover!")]
    Affectionate = 79,

    [AchievementDetailedInfo]
    [Display(Name = "Lucky Day"), Description("As the Alpha Wolf, infect the drunk and stay sober! Phew...")]
    LuckyDay = 80,

    [AchievementDetailedInfo]
    [Display(Name = "Condition Red!"), Description("As the last wolf alive, eat the traitor. Oh no!")]
    ConditionRed = 81,

    [AchievementDetailedInfo]
    [Display(Name = "Indestructible"), Description("Become Doppelgänger or Wild Child with your role model being yourself!")]
    Indestructible = 82,

    [AchievementDetailedInfo]
    [Display(Name = "Psychopath Killer"), Description("As the serial killer, win a game with 35 players!")]
    PsychopathKiller = 83,

    [AchievementDetailedInfo]
    [Display(Name = "Today's Special!"), Description("Take part in a special werewolf event! Currently: Be fooled on April Fool's 2020!")]
    TodaysSpecial = 84,

    [AchievementDetailedInfo]
    [Display(Name = "Romeo and Juliet"), Description("Be in love with the tanner, and win by lynching your lover!")]
    RomeoAndJuliet = 85,

    [AchievementDetailedInfo]
    [Display(Name = "Really bad luck"), Description("As a serial killer, stumble in a grave, then kill someone randomly and get fought off by the guardian angel.")]
    ReallyBadLuck = 86,

    [AchievementDetailedInfo]
    [Display(Name = "Domino"), Description("As a hunter, shoot another hunter causing them to shoot as well.")]
    Domino = 87,

    [AchievementDetailedInfo]
    [Display(Name = "Double Shot"), Description("As the hunter or the gunner, shoot a bad role who is in love with another bad role!")]
    DoubleShot = 88,

    [AchievementDetailedInfo]
    [Display(Name = "Playing with the Fire"), Description("As the arsonist, burn 5 or more houses in one night.")]
    PlayingWithTheFire = 89,

    [AchievementDetailedInfo]
    [Display(Name = "Firework"), Description("As the arsonist, burn 10 or more houses in one night! What a nice firework :)")]
    Firework = 90,

    [AchievementDetailedInfo]
    [Display(Name = "Cold as Ice"), Description("As the Snow Wolf, freeze the harlot. Their love is cold as ice.")]
    ColdAsIce = 91,

    [AchievementDetailedInfo]
    [Display(Name = "Good Choice... For You"), Description("As the chemist, visit a player and survive 3 times in a single game.")]
    GoodChoiceForYou = 92,

    [AchievementDetailedInfo]
    [Display(Name = "Increase the Pack!"), Description("After the wolf cub died, infect 2 players as the alpha wolf!")]
    IncreaseThePack = 93,

    [AchievementDetailedInfo]
    [Display(Name = "Firefighter"), Description("As the guardian angel, clean three houses of kerosene.")]
    Firefighter = 94,

    [AchievementDetailedInfo]
    [Display(Name = "Helpful Paranoia"), Description("As the hunter, shoot two attackers!")]
    HelpfulParanoia = 95,

    [AchievementDetailedInfo]
    [Display(Name = "S-Tier Hunter"), Description("As the hunter, take down a wolf and a cultist in the same night!")]
    STierHunter = 96,

    [AchievementDetailedInfo]
    [Display(Name = "Triple Kill"), Description("As a serial killer or wolf, have at least three people die by your hand in the same night!")]
    TripleKill = 97,

    [AchievementDetailedInfo]
    [Display(Name = "Resist the Beast"), Description("As a trio of wild child, traitor, and cursed, all remain human and win the game with the village.")]
    ResistTheBeast = 98,

    [AchievementDetailedInfo]
    [Display(Name = "At least you tried..."), Description("As the guardian angel, save someone at night only to watch them die to the chemist's poison.")]
    AtLeastYouTried = 99,

    [AchievementDetailedInfo]
    [Display(Name = "Lucky Night"), Description("Survive the chemist's visit and enjoy the harlot's visit in the same night!")]
    LuckyNight = 100,

    [AchievementDetailedInfo]
    [Display(Name = "In the Middle of the Trouble"), Description("As the guardian angel, save a werewolf from an attack and survive!")]
    InTheMiddleOfTheTrouble = 101,

    [AchievementDetailedInfo]
    [Display(Name = "Am I hallucinating?!"), Description("As the fool, see a role which the seer can never see")]
    AmIHallucinating = 102,
}

public static class Achievements
{
    public readonly static AchievementInfo[] All;

    static Achievements()
    {
        All = GetAllAchievementsInfo().ToArray();
    }

    public static IEnumerable<AchievementInfo> GetAllAchievementsInfo()
    {
        foreach (AchievementId achievement in Enum.GetValues<AchievementId>())
        {
            yield return achievement.GetAchievementInfo();
        }
    }

    public static IEnumerable<AchievementInfo> SearchAchievements(string query)
    {
        return All.Where(x =>
        {
            return x.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase);
        });
    }
}

[AttributeUsage(AttributeTargets.Field)]
public class AchievementDetailedInfoAttribute : Attribute
{
    public bool IncludeInSearch { get; set; } = true;
}


public static partial class Extensions
{
    public static string GetDescription(this AchievementId value)
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

    public static string GetName(this AchievementId value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());

        if (fieldInfo?.GetCustomAttributes(
            typeof(DisplayAttribute), false) is not DisplayAttribute[] descriptionAttributes) return string.Empty;
        return (descriptionAttributes.Length > 0 ? descriptionAttributes[0].Name : value.ToString())!;
    }

    public static AchievementInfo GetAchievementInfo(this AchievementId achievement)
    {
        return new AchievementInfo(achievement, achievement.GetName(), achievement.GetDescription());
    }
}