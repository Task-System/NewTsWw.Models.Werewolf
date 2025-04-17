// Ignore Spelling: Unstealable

namespace NewTsWw.Models.Werewolf;

[Flags]
public enum WerewolfTeam
{
    None = 0,

    [WerewolfTeamInfo(Name = "روستایی", Emoji = "👨")]
    Villagers = 2,

    [WerewolfTeamInfo(Name = "گرگینه", Emoji = "🐺")]
    Wolves = 4,

    [WerewolfTeamInfo(Name = "فرقه گرا", Emoji = "👤")]
    Cultists = 8,

    [WerewolfTeamInfo(Name = "همزاد", Emoji = "🎭")]
    Doppelgänger = 16,

    [WerewolfTeamInfo(Name = "قاتل سریالی", Emoji = "🔪")]
    SerialKiller = 32,

    [WerewolfTeamInfo(Name = "منافق", Emoji = "👺")]
    Tanner = 64,

    [WerewolfTeamInfo(Name = "آتش زن", Emoji = "🔥")]
    Arsonist = 128,

    [WerewolfTeamInfo(Name = "دزد", Emoji = "😈")]
    Thief = 256,

    [WerewolfTeamInfo(Name = "عاشق", Emoji = "❤")]
    Lovers = 512,

    [WerewolfTeamInfo(Name = "همه")]
    Everyone = Villagers
        | Wolves | Cultists | Doppelgänger | SerialKiller
        | Tanner | Arsonist | Thief | Lovers,

    [WerewolfTeamInfo(Name = "کشنده")]
    Killers = Wolves | SerialKiller | Arsonist,
}

[Flags]
public enum WerewolfRole : ulong
{
    None = 0,

    [CultistConvertChance(Chance = 100)]
    [WerewolfRoleInfo(
        ShortName = "vg",
        FullName = "روستایی ساده",
        Emoji = "👨",
        Alias = ["ros", "sade", "روس", "روستایی", "ساده", "vlg", "vg", "سادم"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.ForbiddenLove]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو یه روستایی ساده ای🙂"],
        "vg"
    )]
    Villager = 2,

    [Unstealable]
    [CultistConvertChance(Chance = 0)]
    [WerewolfRoleInfo(
        ShortName = "ww",
        FullName = "گرگینه",
        Emoji = "🐺",
        Alias = ["gorg", "grg", "اقا گرگع", "آقا گرگه", "گرگ", "گرگینه", "اقا گولگع", "ww", "گرگم"],
        Team = WerewolfTeam.Wolves,
        Achievements =
        [
            AchievementId.OhShi,
            AchievementId.NoSorcery,
            AchievementId.PackHunter,
            AchievementId.LoneWolf,
            AchievementId.ShouldveMentioned,
            AchievementId.ConditionRed,
            AchievementId.DontStayHome
        ]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو الان آقا گرگه ای"],
        "ww",
        limited: false,
        name: "eat",
        atDay: false,
        actionTexts: ["کیو میخوای بخوری؟"]
    )]
    Werewolf = 4,

    [Unstealable]
    [CultistConvertChance(Chance = 0)]
    [WerewolfRoleInfo(
        ShortName = "aw",
        FullName = "گرگ آلفا",
        Emoji = "⚡️",
        Alias = ["آرش", "ارش", "alpha", "نازا", "الفام", "گرگ الفا", "آلفا", "الفا", "alfa", "aw"],
        Team = WerewolfTeam.Wolves,
        Achievements =
        [
            AchievementId.OhShi,
            AchievementId.StrongestAlpha,
            AchievementId.WuffieCult,
            AchievementId.LuckyDay,
            AchievementId.IncreaseThePack,
            AchievementId.NoSorcery,
            AchievementId.PackHunter,
            AchievementId.LoneWolf,
            AchievementId.ShouldveMentioned,
            AchievementId.ConditionRed,
            AchievementId.DontStayHome
        ]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو گرگ آلفا ⚡️ هستی"],
        "آرش",
        limited: false,
        name: "eat",
        atDay: false,
        actionTexts: ["کیو میخوای بخوری؟"]
    )]
    AlphaWolf = 8,

    [CultistConvertChance(Chance = 100)]
    [WerewolfRoleInfo(
        ShortName = "app",
        FullName = "پیشگوی رزرو",
        Emoji = "🙇",
        Alias = ["رزرو", "پیشگوی رزرو", "رزروم,", "رزروام", "app", "rezrv", "rzrv"],
        Team = WerewolfTeam.Villagers
    )]
    [DetailedWerewolfRoleInfo(
        ["تو پیشگوی رزرو هستی"],
        "app"
    )]
    Apperinace = 16,

    [CultistConvertChance(Chance = 100)]
    [WerewolfRoleInfo(
        ShortName = "bh",
        FullName = "ناظر",
        Emoji = "👁",
        Alias = ["شاهد", "ناظر", "bh", "nazer"],
        Team = WerewolfTeam.Villagers
    )]
    [DetailedWerewolfRoleInfo(
        ["تو ناظر هستی"],
        "bh"
    )]
    Beholder = 32,

    [CultistConvertChance(Chance = 100)]
    [WerewolfRoleInfo(
        ShortName = "cg",
        FullName = "پسر گیج",
        Emoji = "🤕",
        Alias = ["gijam", "پسرگیجم", "پسرگیج", "گیجم", "گیج", "gij", "cg"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.ImNotDrunk]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو پسر گیجی 🤕"],
        "cg"
    )]
    ClumsyGuy = 64,

    [CultistConvertChance(Chance = 75)]
    [WerewolfRoleInfo(
        ShortName = "bs",
        FullName = "آهنگر",
        Emoji = "⚒",
        Alias = ["آهنگر", "اهنگر", "اهنگرم", "آهنگرم", "ahangar", "ahan", "ah", "bs"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.WastedSilver]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو آهنگری ⚒"],
        "bs",
        limited: true,
        count: 1,
        name: "spare",
        atDay: true,
        actionTexts: ["میخوای امشب همه رو به خواب ببری؟"]
    )]
    BlackSmite = 128,

    [Unstealable]
    [CultistConvertChance(Chance = 100)]
    [WerewolfRoleInfo(
        ShortName = "cu",
        FullName = "فرقه گرا",
        Emoji = "👤",
        Alias = ["فرقه گرا", "فرقه", "فرقم", "ferqe", "ferghe", "cult"],
        Team = WerewolfTeam.Cultists,
        Achievements =
        [
            AchievementId.CultFodder,
            AchievementId.CultCon,
            AchievementId.CultLeader,
            AchievementId.DontStayHome
        ]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو فرقه گرا  هستی"],
        "cu",
        limited: false,
        name: "invite",
        atDay: false,
        actionTexts: ["کیو میخوای عضو انجمنت کنی؟"]
    )]
    Cultist = 256,

    [CultistConvertChance(Chance = 0)]
    [WerewolfRoleInfo(
        ShortName = "ch",
        FullName = "شکارچی",
        Emoji = "💂",
        Alias = ["شکار", "شکارچیم", "شکارچی ام", "شکارم", "shekarchiam", "shekaram", "ch"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.CultistTracker]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو شکارچی هستی‌"],
        "ch",
        limited: false,
        name: "search",
        atDay: false,
        actionTexts: ["کیو میخوای شکار کنی؟"]
    )]
    CultistHunter = 512,

    [CultistConvertChance(Chance = 100)]
    [WerewolfRoleInfo(
        ShortName = "cp",
        FullName = "الهه عشق",
        Emoji = "🏹",
        Alias = ["الهه ام", "elahe eshgh", "الهه عشق", "الاهه", "الهه", "elahe", "cp"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.SelfLoving]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو الهه عشقی"],
        "cp",
        limited: true,
        count: 2,
        name: "mirage",
        atDay: false,
        actionTexts: ["کیا رو میخوای عاشق همدیگه بکنی؟ نفر اول رو انتخاب کن", "کیا رو میخوای عاشق همدیگه بکنی؟ نفر دوم رو انتخاب کن"]
    )]
    Cupid = 1024,

    [CultistConvertChance(Chance = 60)]
    [WerewolfRoleInfo(
        ShortName = "cr",
        FullName = "نفرین شده",
        Emoji = "😾",
        Alias = ["نفرین ام", "nefrin", "نفرین شده", "نفرینم", "نفرین", "cr", "nfrin"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.ResistTheBeast]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو نفرین شده ای"],
        "cr"
    )]
    Cursed = 2048,

    [CultistConvertChance(Chance = 70)]
    [WerewolfRoleInfo(
        ShortName = "de",
        FullName = "کاراگاه",
        Emoji = "🕵️",
        Alias = ["کارگاهم", "کارام", "kara", "کارگاه", "کارا", "کاراگاه", "karagah", "de"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.Streetwise]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو کاراگاهی"],
        "de",
        limited: false,
        name: "detect",
        atDay: true,
        actionTexts: ["کیو میخوای استعلام کنی؟"]
    )]
    Detective = 4096,

    [CultistConvertChance(Chance = 0)]
    [WerewolfRoleInfo(
        ShortName = "dg",
        FullName = "همزاد",
        Emoji = "🎭",
        Alias = ["همزاد", "همزادم", "dg", "hamzad"],
        Team = WerewolfTeam.Doppelgänger,
        Achievements = [AchievementId.Indestructible, AchievementId.DeepLove]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو همزادی"],
        "dg",
        limited: true,
        count: 1,
        name: "choose",
        atDay: false,
        actionTexts: ["میخوای همزاد کی بشی؟ اگه بمیره تو نقششو بر عهده میگیری"]
    )]
    Doppelgänger = 8192,

    [WerewolfRoleInfo(
        ShortName = "dr",
        FullName = "مست",
        Emoji = "🍻",
        Alias = ["مست", "مستم", "الکلی", "mast", "mastam", "dr"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.Wobble]
    )]
    [DetailedWerewolfRoleInfo(
        ["واااااااااای چقد مستی تو", "الکلی بدبخت"],
        "dr"
    )]
    Drunk = 16384,

    [WerewolfRoleInfo(
        ShortName = "fo",
        FullName = "احمق",
        Emoji = "🃏",
        Alias = ["احمق", "احمقم", "ahmagh", "fo"],
        Team = WerewolfTeam.Villagers,
        Achievements =
        [
            AchievementId.AmIYourSeer,
            AchievementId.BrokenClock,
            AchievementId.AmIHallucinating
        ]
    )]
    Fool = 32768,

    [WerewolfRoleInfo(
        ShortName = "ga",
        FullName = "فرشته نگهبان",
        Emoji = "👼",
        Alias = ["فرشته ام", "فرشتتون", "fereshtam", "fereshte", "فرشته نگهبان", "فرشتم", "فرشته", "ga", "فری"],
        Team = WerewolfTeam.Villagers,
        Achievements =
        [
            AchievementId.DidYouGuardYourself,
            AchievementId.InTheMiddleOfTheTrouble,
            AchievementId.AtLeastYouTried,
            AchievementId.Firefighter
        ]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو فرشته نگهبانی"],
        "ga",
        limited: false,
        name: "guard",
        atDay: false,
        actionTexts: ["از کی میخوای نگهبانی کنی؟"]
    )]
    GaurdinaAngle = 65536,

    [WerewolfRoleInfo(
        ShortName = "gu",
        FullName = "تفنگدار",
        Emoji = "🔫",
        Alias = ["tofangam", "tofangdar", "tof", "tofang", "تفنگدارم", "تفنگم", "تفنگدار", "تفنگ", "gu"],
        Team = WerewolfTeam.Villagers,
        Achievements =
        [
            AchievementId.GunnerSaves,
            AchievementId.SmartGunner,
            AchievementId.DoubleShot
        ]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو تفنگدار هستی"],
        "gu",
        limited: true,
        count: 2,
        name: "shoot",
        atDay: true,
        actionTexts: ["به کی میخوای تیر بزنی؟ (.*) گلوله داری"]
    )]
    Gunner = 131072,

    [WerewolfRoleInfo(
        ShortName = "ha",
        FullName = "فاحشه",
        Emoji = "💋",
        Alias = ["natasha", "خراب", "فاحشم", "فاحشه ام", "ناتاشا", "فاحشه", "faheshe", "ha"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.Promiscuous, AchievementId.Affectionate]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو فاحشه ای 💋"],
        "ha",
        limited: false,
        name: "sex",
        atDay: false,
        actionTexts: ["ای شیطون! میخوای بری خونه کی؟"]
    )]
    Harlot = 262144,

    [WerewolfRoleInfo(
        ShortName = "hu",
        FullName = "کلانتر",
        Emoji = "🎯",
        Alias = ["kalantaram", "kalantar", "کلانم", "کلانترم", "kalanm", "kalan", "کلان", "کلانتر", "hu"],
        Team = WerewolfTeam.Villagers,
        Achievements =
        [
            AchievementId.DemotedByTheDeath,
            AchievementId.DoubleKill,
            AchievementId.HeyManNiceShot,
            AchievementId.Domino,
            AchievementId.DoubleShot,
            AchievementId.STierHunter,
            AchievementId.HelpfulParanoia
        ]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو کلانتر روستا هستی"],
        "kalan",
        limited: true,
        count: 1,
        name: "shoot",
        atDay: false,
        actionTexts: ["حاجی کشتنت ولی هنوز جون داری قبل از اینکه بمیری یه تیر بزن یه نفرو بکش"]
    )]
    Hunter = 524288,

    [WerewolfRoleInfo(
        ShortName = "ma",
        FullName = "فراماسون",
        Emoji = "👷",
        Alias = ["فرا", "فراماسون", "ماسون", "فرام", "فراماسونم", "fra", "fera", "بنا", "ma"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.MasonBrother]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو فراماسونی"],
        "ma"
    )]
    Mason = 1048576,

    [WerewolfRoleInfo(
        ShortName = "mj",
        FullName = "کدخدا",
        Emoji = "🎖",
        Alias = ["کدخدا", "کدی", "کد", "کدخدام", "کدی ام", "kadkhoda", "mj"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.President]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو کدخدا🎖😨"],
        "mj",
        limited: true,
        count: 1,
        name: "sign",
        atDay: true,
        actionTexts: ["اگه برای اعلام کردن نقشت آماده هستی روی \"اعلام کردم\" کلیک کن تا بتونی از این به بعد 2 تا رای بدی😁"]
    )]
    Major = 2097152,

    [WerewolfRoleInfo(
        ShortName = "pr",
        FullName = "شاهزاده",
        Emoji = "👑",
        Alias = ["shahzade", "shah", "پرنسسم", "پرنسس", "شاهزادم", "شاهم", "شاهزاده", "pr", "شاه"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.SpoiledRichBrat]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو شاهزاده ای👑"],
        "pr"
    )]
    Prince = 4194304,

    [WerewolfRoleInfo(
        ShortName = "se",
        FullName = "پیشگو",
        Emoji = "👳",
        Alias = ["پیشگو", "پیشگوام", "pish", "pishgo", "پیش", "se"],
        Team = WerewolfTeam.Villagers,
        Achievements =
        [
            AchievementId.SeeingBetweenTeams,
            AchievementId.DoubleVision,
            AchievementId.ShouldHaveKnown,
            AchievementId.LackOfTrust
        ]
    )]
    Seer = 8388608,

    [Unstealable]
    [CultistConvertChance(Chance = 0)]
    [WerewolfRoleInfo(
        ShortName = "sk",
        FullName = "قاتل زنجیره ای",
        Emoji = "🔪",
        Alias = ["قاتل زنجیره ای", "qatel", "قاتل", "ghatel", "قاتلم", "sk", "بکن"],
        Team = WerewolfTeam.SerialKiller,
        Achievements =
        [
            AchievementId.SerialSamaritan,
            AchievementId.PsychopathKiller,
            AchievementId.ReallyBadLuck,
            AchievementId.DoubleKill
        ]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو قاتل زنجیره ای هستی"],
        "sk",
        limited: false,
        name: "kill",
        atDay: false,
        actionTexts: ["کیو میخوای امشب بکشی؟"]
    )]
    SerialKiller = 16777216,

    [WerewolfRoleInfo(
        ShortName = "sc",
        FullName = "جادوگر",
        Emoji = "🔮",
        Alias = ["جادو", "جادوام", "جادوگر", "jado", "jadogar", "jadoam", "sc"],
        Team = WerewolfTeam.Wolves,
        Achievements =
        [
            AchievementId.SeeingBetweenTeams,
            AchievementId.TimeToRetire,
            AchievementId.ThreeLittleWolves
        ]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو جادوگری🔮"],
        "sc",
        limited: false,
        name: "see",
        atDay: false,
        actionTexts: ["کیو میخوای ببینی؟"]
    )]
    Sorcerer = 33554432,

    [WerewolfRoleInfo(
        ShortName = "ta",
        FullName = "منافق",
        Emoji = "👺",
        Alias = ["منافقم", "منافق", "لواشک", "لواشکم", "monafeq", "monafegh", "ta"],
        Team = WerewolfTeam.Tanner,
        Achievements =
        [
            AchievementId.ThatCameUnexpected,
            AchievementId.TannerOverkill,
            AchievementId.SoClose,
            AchievementId.Masochist
        ]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو منافقی"],
        "ta"
    )]
    Tanner = 67108864,

    [WerewolfRoleInfo(
        ShortName = "tr",
        FullName = "خائن",
        Emoji = "🖕",
        Alias = ["خائن", "خائنم", "خاعن", "خاعنم", "khaen", "tr"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.ResistTheBeast]
    )]
    [DetailedWerewolfRoleInfo(
        ["خائن کثیف"],
        "tr"
    )]
    Traitor = 134217728,

    [WerewolfRoleInfo(
        ShortName = "wc",
        FullName = "بچه وحشی",
        Emoji = "👶",
        Alias = ["wc", "vahshiam", "vahshi", "وحشیم", "بچه وحشی", "وحشی"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.ThanksJunior, AchievementId.ResistTheBeast]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو بچه وحشی هستی"],
        "wc"
    )]
    WildChild = 268435456,

    [Unstealable]
    [CultistConvertChance(Chance = 0)]
    [WerewolfRoleInfo(
        ShortName = "cb",
        FullName = "توله گرگ",
        Emoji = "🐶",
        Alias = ["شرناس", "توله گرگ", "تولم", "توله", "tule", "tole", "توله ام", "cub"],
        Team = WerewolfTeam.Wolves,
        Achievements =
        [
            AchievementId.OhShi,
            AchievementId.IHelped,
            AchievementId.NoSorcery,
            AchievementId.PackHunter,
            AchievementId.LoneWolf,
            AchievementId.ShouldveMentioned,
            AchievementId.ConditionRed,
            AchievementId.DontStayHome
        ]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو توله گرگ 🐶هستی"],
        "شرناس",
        limited: false,
        name: "eat",
        atDay: false,
        actionTexts: ["کیو میخوای بخوری؟"]
    )]
    Club = 536870912,

    [Unstealable]
    [CultistConvertChance(Chance = 0)]
    [WerewolfRoleInfo(
        ShortName = "ly",
        FullName = "گرگ ایکس",
        Emoji = "🐺🌝",
        Alias = ["لیکان", "گرگ ایکس", "ایکس", "x", "gorgex", "Lycan", "ایکسم"],
        Team = WerewolfTeam.Wolves,
        Achievements =
        [
            AchievementId.OhShi,
            AchievementId.NoSorcery,
            AchievementId.PackHunter,
            AchievementId.LoneWolf,
            AchievementId.ShouldveMentioned,
            AchievementId.ConditionRed,
            AchievementId.DontStayHome
        ]
    )]
    [DetailedWerewolfRoleInfo(
    ["تو گرگ ایکس هستی🐺🌝"],
        "ly",
        limited: false,
        name: "eat",
        atDay: false,
        actionTexts: ["کیو میخوای بخوری؟"]
    )]
    Lycan = 1073741824,

    [WerewolfRoleInfo(
        ShortName = "wm",
        FullName = "گرگ نما",
        Emoji = "👱🌚",
        Alias = ["nama", "gorgnama", "نمام", "گرگنمام", "نما", "گرگنما", "wm"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.JustABeardyGuy, AchievementId.Trustworthy]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو گرگ نمایی👱🌚!"],
        "wm"
    )]
    WolfMan = 2147483648,

    [WerewolfRoleInfo(
        ShortName = "sm",
        FullName = "خواب گذار",
        Emoji = "💤",
        Alias = ["خوابم", "خواب گذار", "خواب", "khabam", "khabgozar", "khab", "sm"],
        Team = WerewolfTeam.Villagers
    )]
    [DetailedWerewolfRoleInfo(
        ["تو خواب گذار هستی💤"],
        "sm",
        limited: true,
        count: 1,
        name: "throw",
        atDay: true,
        actionTexts: ["میخوای امشب همه رو به خواب ببری؟"]
    )]
    SandMan = 4294967296,

    [WerewolfRoleInfo(
        ShortName = "or",
        FullName = "پیشگوی نگاتیو",
        Emoji = "🌀",
        Alias = ["نگاتیوم", "نگا", "negative", "پیشگوی نگاتیو", "نگاتیو", "نگاتیوی", "or"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.NowImBlind]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو پیشگوی نگاتیوی هستی 🌀"],
        "or",
        limited: false,
        name: "look",
        atDay: false,
        actionTexts: ["کیو میخوای ببینی؟"]
    )]
    Oracle = 8589934592,

    [WerewolfRoleInfo(
        ShortName = "pc",
        FullName = "صلح گرا",
        Emoji = "☮️",
        Alias = ["solham", "solhgara", "solh", "صلح گرا", "صلحم", "صلح", "pc"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.EveryManForHimself, AchievementId.MySweetieSoStrong]
    )]
    [DetailedWerewolfRoleInfo(
    ["تو صلح گرا هستی☮️"],
        "pc",
        limited: true,
        count: 1,
        name: "peace",
        atDay: false,
        actionTexts: ["این دکمه رو فشار بده ویه سخنرانی در مورد حقوق بشر بکن، یادت باشه وقتی این کار رو بکنی جلوی رای دادن روستایی ها رو میگیری"]
    )]
    Pacifist = 17179869184,

    [WerewolfRoleInfo(
        ShortName = "we",
        FullName = "ریش سفید",
        Emoji = "📚",
        Alias = ["we", "risham", "rish", "ریشم", "ریش سفید", "ریش"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.ILostMyWisdom]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو ریش سفیدی📚"],
        "we"
    )]
    WiseElder = 34359738368,

    [WerewolfRoleInfo(
        ShortName = "cm",
        FullName = "شیمیدان",
        Emoji = "👨‍🔬",
        Alias = ["شیمی", "شیمیدان", "شیمیم", "shimi", "chem", "shimidan", "cm"],
        Team = WerewolfTeam.Villagers,
        Achievements = [AchievementId.GoodChoiceForYou]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو یه شیمیدان هستی 👨‍🔬"],
        "cm",
        limited: false,
        name: "bet",
        atDay: true,
        actionTexts: ["امشب کی میتونه یه میزبان و شریک خوب توی شرط بندی باشه؟"]
    )]
    Chemists = 68719476736,

    [Unstealable]
    [CultistConvertChance(Chance = 0)]
    [WerewolfRoleInfo(
        ShortName = "sw",
        FullName = "گرگ برفی",
        Emoji = "🐺☃️",
        Alias = ["gorgbarfi", "barfi", "sw", "یخی", "برفی", "گرگ برفی", "sw"],
        Team = WerewolfTeam.Wolves,
        Achievements = [AchievementId.ColdAsIce]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو گرگ برفی هستی 🐺☃️"],
        "sw",
        limited: false,
        name: "freeze",
        atDay: false,
        actionTexts: ["میخوای امشب کی رو منجمد کنی؟"]
    )]
    SnowWolf = 137438953472,

    [WerewolfRoleInfo(
        ShortName = "gd",
        FullName = "گورکن",
        Emoji = "☠️",
        Alias = ["goram", "گورکنم", "گورم", "gor", "گورکن", "گور", "gd"],
        Team = WerewolfTeam.Villagers
    )]
    [DetailedWerewolfRoleInfo(
        ["تو گورکن هستی ☠️"],
        "gd"
    )]
    GraveDigger = 274877906944,

    [Unstealable]
    [CultistConvertChance(Chance = 0)]
    [WerewolfRoleInfo(
        ShortName = "ar",
        FullName = "آتش زن",
        Emoji = "🔥",
        Alias = ["atish", "arr", "آتیش", "آتش", "اتیش", "اتش زن", "atisham", "ar"],
        Team = WerewolfTeam.Arsonist,
        Achievements = [AchievementId.PlayingWithTheFire, AchievementId.Firework]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو آتش زن هستی 🔥"],
        "ar",
        limited: false,
        name: "burn",
        atDay: false,
        actionTexts: ["میخوای یه خونه دیگه رو هم آغشته کنی یا میخوای با یه جرقه همشون رو بسوزونی؟"]
    )]
    Arsonist = 549755813888,

    [WerewolfRoleInfo(
        ShortName = "ag",
        FullName = "رمال",
        Emoji = "🦅",
        Alias = ["رمالم", "رمال", "غیبگو", "حمال", "ramalam", "ramal", "ag"],
        Team = WerewolfTeam.Villagers
    )]
    [DetailedWerewolfRoleInfo(
        ["تو رمال هستی 🦅"],
        "au"
    )]
    Agur = 1099511627776,

    [WerewolfRoleInfo(
        ShortName = "tm",
        FullName = "دردسرساز",
        Emoji = "🤯",
        Alias = ["دردسرم", "دردسر", "دردسرساز", "tm", "dardesar", "dardsar", "dardsr", "drdsr"],
        Team = WerewolfTeam.Villagers
    )]
    [DetailedWerewolfRoleInfo(
        ["تو دردسرسازی 🤯"],
        "tm",
        limited: true,
        count: 1,
        name: "trouble",
        atDay: true,
        actionTexts: ["میخوای امروز دردسری ایجاد کنی؟"]
    )]
    TroubleMaker = 2199023255552,

    [CultistConvertChance(Chance = 0)]
    [WerewolfRoleInfo(
        ShortName = "th",
        FullName = "دزد",
        Emoji = "😈",
        Alias = ["dozdam", "dozd", "dzd", "kosar", "ساریق", "سارق", "دزدم", "دزد", "کوثر", "th"],
        Team = WerewolfTeam.Thief
    )]
    [DetailedWerewolfRoleInfo(
        ["تو دزدی😈", "😑متاسفانه نقش شما دزدیده شده."],
        "کوثر",
        limited: false,
        name: "steal",
        atDay: false,
        actionTexts: ["نقش کیو میخوای بدزدی؟😈"]
    )]
    Thief = 4398046511104,

    // Indefinite roles
    [WerewolfRoleInfo(
        ShortName = "pa",
        FullName = "پیشگو یا احمق",
        Emoji = "👳🃏",
        Alias = ["پا", "pa", "پیشی"],
        Team = WerewolfTeam.Villagers,
        Achievements =
        [
            AchievementId.SeeingBetweenTeams,
            AchievementId.DoubleVision,
            AchievementId.ShouldHaveKnown,
            AchievementId.LackOfTrust,
            AchievementId.BrokenClock,
            AchievementId.AmIYourSeer,
            AchievementId.AmIHallucinating
        ]
    )]
    [DetailedWerewolfRoleInfo(
        ["تو پیشگو هستی"],
        "pa",
        limited: false,
        name: "see",
        atDay: false,
        actionTexts: ["کیو میخوای ببینی؟"]
    )]
    SeerOrFool = Seer | Fool,

    [Unstealable]
    [CultistConvertChance(Chance = 0)]
    Wolves = Werewolf | AlphaWolf | Lycan | SnowWolf | Club,
}

public static class RoleExtension
{
    public static string? RoleTag(this WerewolfRole role)
    {
        return role switch
        {
            WerewolfRole.Villager => "vg",
            WerewolfRole.Werewolf => "ww",
            WerewolfRole.AlphaWolf => "aw",
            WerewolfRole.Apperinace => "app",
            WerewolfRole.Beholder => "bh",
            WerewolfRole.ClumsyGuy => "cg",
            WerewolfRole.BlackSmite => "bs",
            WerewolfRole.Cultist => "cu",
            WerewolfRole.CultistHunter => "ch",
            WerewolfRole.Cupid => "cp",
            WerewolfRole.Cursed => "cr",
            WerewolfRole.Detective => "de",
            WerewolfRole.Doppelgänger => "dg",
            WerewolfRole.Drunk => "dr",
            WerewolfRole.Fool => "fo",
            WerewolfRole.GaurdinaAngle => "ga",
            WerewolfRole.Gunner => "gu",
            WerewolfRole.Harlot => "ha",
            WerewolfRole.Hunter => "hu",
            WerewolfRole.Mason => "ma",
            WerewolfRole.Major => "mj",
            WerewolfRole.Prince => "pr",
            WerewolfRole.Seer => "se",
            WerewolfRole.SerialKiller => "sk",
            WerewolfRole.Sorcerer => "sc",
            WerewolfRole.Tanner => "ta",
            WerewolfRole.Traitor => "tr",
            WerewolfRole.WildChild => "wc",
            WerewolfRole.Club => "cb",
            WerewolfRole.Lycan => "ly",
            WerewolfRole.WolfMan => "wm",
            WerewolfRole.SandMan => "sm",
            WerewolfRole.Oracle => "or",
            WerewolfRole.Pacifist => "pc",
            WerewolfRole.WiseElder => "we",
            WerewolfRole.Chemists => "cm",
            WerewolfRole.SnowWolf => "sw",
            WerewolfRole.GraveDigger => "gd",
            WerewolfRole.Arsonist => "ar",
            WerewolfRole.Agur => "ag",
            WerewolfRole.TroubleMaker => "tm",
            WerewolfRole.Thief => "th",
            WerewolfRole.SeerOrFool => "pa",
            _ => null
        };
    }

    public static WerewolfRole? FromRoleTag(this string roleTag)
    {
        return roleTag switch
        {
            "vg" => WerewolfRole.Villager,
            "ww" => WerewolfRole.Werewolf,
            "aw" => WerewolfRole.AlphaWolf,
            "app" => WerewolfRole.Apperinace,
            "bh" => WerewolfRole.Beholder,
            "cg" => WerewolfRole.ClumsyGuy,
            "bs" => WerewolfRole.BlackSmite,
            "cu" => WerewolfRole.Cultist,
            "ch" => WerewolfRole.CultistHunter,
            "cp" => WerewolfRole.Cupid,
            "cr" => WerewolfRole.Cursed,
            "de" => WerewolfRole.Detective,
            "dg" => WerewolfRole.Doppelgänger,
            "dr" => WerewolfRole.Drunk,
            "fo" => WerewolfRole.Fool,
            "ga" => WerewolfRole.GaurdinaAngle,
            "gu" => WerewolfRole.Gunner,
            "ha" => WerewolfRole.Harlot,
            "hu" => WerewolfRole.Hunter,
            "ma" => WerewolfRole.Mason,
            "mj" => WerewolfRole.Major,
            "pr" => WerewolfRole.Prince,
            "se" => WerewolfRole.Seer,
            "sk" => WerewolfRole.SerialKiller,
            "sc" => WerewolfRole.Sorcerer,
            "ta" => WerewolfRole.Tanner,
            "tr" => WerewolfRole.Traitor,
            "wc" => WerewolfRole.WildChild,
            "cb" => WerewolfRole.Club,
            "ly" => WerewolfRole.Lycan,
            "wm" => WerewolfRole.WolfMan,
            "sm" => WerewolfRole.SandMan,
            "or" => WerewolfRole.Oracle,
            "pc" => WerewolfRole.Pacifist,
            "we" => WerewolfRole.WiseElder,
            "cm" => WerewolfRole.Chemists,
            "sw" => WerewolfRole.SnowWolf,
            "gd" => WerewolfRole.GraveDigger,
            "ar" => WerewolfRole.Arsonist,
            "ag" => WerewolfRole.Agur,
            "tm" => WerewolfRole.TroubleMaker,
            "th" => WerewolfRole.Thief,
            "ps" => WerewolfRole.SeerOrFool,
            _ => null
        };
    }

    public static WerewolfRoleInfo? GetRoleInfo(this WerewolfRole role)
    {
        if (role.GetType()
            .GetField(role.ToString())?
            .GetCustomAttributes(typeof(WerewolfRoleInfoAttribute), false)
            .FirstOrDefault() is not WerewolfRoleInfoAttribute attr) return null;

        return new WerewolfRoleInfo
        {
            FullName = attr.FullName,
            Alias = attr.Alias,
            Emoji = attr.Emoji,
            ShortName = attr.ShortName,
            Role = role,
            Achievements = attr.Achievements,
            Team = attr.Team
        };
    }

    public static DetailedWerewolfRoleInfoAttribute? GetDetailedRoleInfo(this WerewolfRole role)
    {
        if (role.GetType()
            .GetField(role.ToString())?
            .GetCustomAttributes(typeof(DetailedWerewolfRoleInfoAttribute), false)
            .FirstOrDefault() is not DetailedWerewolfRoleInfoAttribute attr) return null;

        return attr;
    }

    public static bool CanBeStolen(this WerewolfRole role)
    {
        return (role.GetType()
            .GetField(role.ToString())?
            .GetCustomAttributes(typeof(UnstealableAttribute), false)
            .FirstOrDefault()) is null;
    }
}

[AttributeUsage(AttributeTargets.Field)]
public class WerewolfRoleInfoAttribute : Attribute
{
    public required string FullName { get; set; }
    public required string[] Alias { get; set; }
    public required string ShortName { get; set; }
    public required string Emoji { get; set; }
    public required WerewolfTeam Team { get; set; }
    public AchievementId[] Achievements { get; set; } = [];
}

public class WerewolfRoleInfo
{
    public required WerewolfRole Role { get; set; }
    public required string FullName { get; set; }
    public required string[] Alias { get; set; }
    public required string ShortName { get; set; }
    public required string Emoji { get; set; }
    public required WerewolfTeam Team { get; set; }
    public AchievementId[] Achievements { get; set; } = [];
}

[AttributeUsage(AttributeTargets.Field, Inherited = false)]
public class DetailedWerewolfRoleInfoAttribute : Attribute
{
    public string[] Text { get; set; }
    public string RoleTag { get; set; }
    public ActionProperties? Action { get; set; }

    public DetailedWerewolfRoleInfoAttribute(string[] text, string roleTag, bool limited = false, string name = null, bool atDay = false, int count = 0, params string[] actionTexts)
    {
        Text = text;
        RoleTag = roleTag;
        Action = new ActionProperties
        {
            Limited = limited,
            Name = name,
            AtDay = atDay,
            Count = count,
            ActionTexts = actionTexts
        };
    }

    public DetailedWerewolfRoleInfoAttribute(string[] text, string roles)
    {
        Text = text;
        RoleTag = roles;
        Action = default;
    }

    public class ActionProperties
    {
        public bool Limited { get; set; } = false;
        public required string Name { get; set; }
        public required bool AtDay { get; set; }
        public int? Count { get; set; } = null;
        public required string[] ActionTexts { get; set; }
    }
}

[AttributeUsage(AttributeTargets.Field, Inherited = false)]
public class WerewolfTeamInfoAttribute : Attribute
{
    public required string Name { get; set; }

    public string? Emoji { get; set; } = default;

    public AchievementId[] Achievements { get; set; } = [];
}

[AttributeUsage(AttributeTargets.Field)]
public class UnstealableAttribute : Attribute;

[AttributeUsage(AttributeTargets.Field)]
public class CultistConvertChanceAttribute : Attribute
{
    public required int Chance { get; set; }
}

public static class WerewolfRoles
{
    public readonly static WerewolfRoleInfo[] All;
    public readonly static Dictionary<WerewolfRole, string[]> AllRoleTexts;

    static WerewolfRoles()
    {
        All = Enum.GetValues<WerewolfRole>().Select(x => x.GetRoleInfo()!)
            .Where(x => x is not null)
            .ToArray();
        AllRoleTexts = Enum.GetValues<WerewolfRole>()
            .Select(x => (x, x.GetDetailedRoleInfo()))
            .Where(x => x.Item2 is not null)
            .ToDictionary(x => x.x, x => x.Item2!.Text);
    }

    public static WerewolfRoleInfo? SearchRole(this string query)
    {
        return All.FirstOrDefault(x => x.Alias.Contains(query.Trim().ToLower()));
    }

    public static WerewolfRoleInfo? GetRole(this WerewolfRole? werewolfRole)
    {
        return All.FirstOrDefault(x => x.Role == werewolfRole);
    }

    public static WerewolfRole? ContainsRoleText(this string text)
    {
        var key = AllRoleTexts
            .Where(x => x.Value.Any(y => text.Contains(y)))
            .FirstOrDefault()
            .Key;
        return key == WerewolfRole.None ? null : key;
    }
}