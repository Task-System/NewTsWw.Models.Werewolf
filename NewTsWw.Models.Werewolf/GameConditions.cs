namespace NewTsWw.Models.Werewolf;

[Flags]
public enum ConditionFlag
{
    None = 0,

    NeedStealing = 1,
    DgRoleModel = 2,
    DgRoleModelMissing = 4
}

public class GameContext
{
    public required int DayNumber { get; set; }

    public required int PlayersCount { get; set; }

    public required int[]? Lovers { get; set; }

    public required IReadOnlyDictionary<int, WerewolfRole> AliveRoles { get; set; }

    public required IReadOnlyDictionary<WerewolfRole, int> RoleModels { get; set; }

    public bool PlayerHasRole(int playerId, WerewolfRole role)
        => AliveRoles.TryGetValue(playerId, out var got) && role.HasFlag(got);

    public WerewolfRole? PlayerRole(int playerId)
    {
        if (AliveRoles.TryGetValue(playerId, out var got))
            return got;
        return null;
    }

    public bool RoleExists(WerewolfRole role)
        => AliveRoles.Any(x => x.Value == role);

    bool IsDgRoleModel(WerewolfRole model, bool strict = false)
    {
        return IsDgRoleModel(model, out var _, strict);
    }

    bool IsDgRoleModel(WerewolfRole model, out ConditionFlag flag, bool strict = false)
    {
        if (RoleModels.TryGetValue(WerewolfRole.Doppelgänger, out var otherPlayerId))
        {
            flag = ConditionFlag.None;
            var actualModel = PlayerRole(otherPlayerId);
            return actualModel is not null && actualModel.Value.HasFlag(model);
        }
        else
        {
            // Role exists, but role model data not!
            flag = ConditionFlag.DgRoleModelMissing;
            return !strict;
        }
    }

    public bool IsDgWithRoleModel(int playerId, WerewolfRole model, out ConditionFlag flag, bool strict = false)
    {
        flag = ConditionFlag.None;
        if (PlayerRole(playerId) is WerewolfRole werewolf && werewolf == WerewolfRole.Doppelgänger)
        {
            return IsDgRoleModel(model, out flag, strict);
        }

        return false;
    }


    public (bool, ConditionFlag) IsDgWithRoleModel(int playerId, WerewolfRole model, bool strict = false)
    {
        return (IsDgWithRoleModel(playerId, model, out var flag, strict), flag);
    }

    public bool DgExistsWithRoleModel(WerewolfRole model, out ConditionFlag flag, bool strict = false)
    {
        flag = ConditionFlag.None;
        if (RoleExists(WerewolfRole.Doppelgänger))
        {
            return IsDgRoleModel(model, out flag, strict);
        }

        return false;
    }

    public (bool, ConditionFlag) DgExistsWithRoleModel(WerewolfRole model, bool strict = false)
    {
        return (DgExistsWithRoleModel(model, out var flag, strict), flag);
    }
}

public interface IGameCondition
{
    int Priority { get; }

    ConditionFlag Flags { get; }

    bool Satisfied(int playerId, GameContext context);
}

public class OrCondition(params IGameCondition[] conditions) : IGameCondition
{
    private readonly IGameCondition[] conditions = conditions;

    public int Priority => (int)conditions.Average(x => x.Priority);

    public ConditionFlag Flags => conditions.Aggregate(ConditionFlag.None, (current, condition) => current | condition.Flags);

    public bool Satisfied(int playerId, GameContext context)
    {
        return conditions
            .OrderBy(x => x.Priority)
            .Any(condition => condition.Satisfied(playerId, context));
    }
}

public class AndCondition(params IGameCondition[] conditions) : IGameCondition
{
    private readonly IGameCondition[] conditions = conditions;

    public ConditionFlag Flags => conditions.Aggregate(ConditionFlag.None, (current, condition) => current | condition.Flags);

    public int Priority => (int)conditions.Average(x => x.Priority);

    public bool Satisfied(int playerId, GameContext context)
    {
        return conditions
            .OrderBy(x => x.Priority)
            .All(condition => condition.Satisfied(playerId, context));
    }
}

public class NotCondition(IGameCondition condition) : IGameCondition
{
    private readonly IGameCondition condition = condition;

    public ConditionFlag Flags => condition.Flags;

    public int Priority => condition.Priority;

    public bool Satisfied(int playerId, GameContext context)
    {
        return !condition.Satisfied(playerId, context);
    }
}

public enum GameConditionCombination
{
    Or,
    And,
}

[AttributeUsage(AttributeTargets.Field)]
public class GameConditionAttribute : Attribute, IGameCondition
{
    private readonly Func<int, GameContext, bool> func;
    private readonly ConditionFlag? onSuccessFlags;

    public bool Negative { get; set; } = false;
    public GameConditionCombination Combination { get; set; } = GameConditionCombination.And;

    public GameConditionAttribute(
        Func<GameContext, bool> func, ConditionFlag? onSuccessFlags = default)
    {
        this.func = (_, ctx) => func(ctx);
        this.onSuccessFlags = onSuccessFlags;
    }

    public GameConditionAttribute(
        Func<int, bool> func, ConditionFlag? onSuccessFlags = default)
    {
        this.func = (playerId, _) => func(playerId);
        this.onSuccessFlags = onSuccessFlags;
    }

    public GameConditionAttribute(
        Func<int, GameContext, bool> func, ConditionFlag? onSuccessFlags = default)
    {
        this.func = func;
        this.onSuccessFlags = onSuccessFlags;
    }

    public GameConditionAttribute(
        Func<bool> func, ConditionFlag? onSuccessFlags = default)
    {
        this.func = (_, __) => func();
        this.onSuccessFlags = onSuccessFlags;
    }

    public GameConditionAttribute(
        bool func, ConditionFlag? onSuccessFlags = default)
    {
        this.func = (_, __) => func;
        this.onSuccessFlags = onSuccessFlags;
    }

    public GameConditionAttribute(IGameCondition condition)
    {
        func = condition.Satisfied;
        onSuccessFlags = condition.Flags;
    }

    public GameConditionAttribute(IGameCondition condition, ConditionFlag? onSuccessFlags = default)
    {
        func = condition.Satisfied;
        this.onSuccessFlags = condition.Flags | onSuccessFlags;
    }

    public GameConditionAttribute(
        Func<int, GameContext, (bool, ConditionFlag)> func, ConditionFlag? onSuccessFlags = default)
    {
        this.func = (playerId, ctx) =>
        {
            var (result, flag) = func(playerId, ctx);
            Flags |= flag;
            return result;
        };
        this.onSuccessFlags = onSuccessFlags;
    }

    public GameConditionAttribute(
        Func<GameContext, (bool, ConditionFlag)> func, ConditionFlag? onSuccessFlags = default)
    {
        this.func = (_, ctx) =>
        {
            var (result, flag) = func(ctx);
            Flags |= flag;
            return result;
        };
        this.onSuccessFlags = onSuccessFlags;
    }

    public GameConditionAttribute(
        Func<int, (bool, ConditionFlag)> func, ConditionFlag? onSuccessFlags = default)
    {
        this.func = (playerId, __) =>
        {
            var (result, flag) = func(playerId);
            Flags |= flag;
            return result;
        };
        this.onSuccessFlags = onSuccessFlags;
    }

    public GameConditionAttribute(
        Func<(bool, ConditionFlag)> func, ConditionFlag? onSuccessFlags = default)
    {
        this.func = (_, __) =>
        {
            var (result, flag) = func();
            Flags |= flag;
            return result;
        };
        this.onSuccessFlags = onSuccessFlags;
    }

    public ConditionFlag Flags { get; private set; }

    public int Priority { get; set; } = 0;

    public bool Satisfied(int playerId, GameContext context)
    {
        var name = GetType().Name;
        Console.WriteLine(name);
        if (func(playerId, context))
        {
            if (onSuccessFlags != null)
                Flags |= onSuccessFlags.Value;
            return true;
        }

        return false;
    }

    public GameConditionAttribute WithFlag(ConditionFlag flag)
    {
        Flags |= flag;
        return this;
    }
}

public static class GameConditions
{
    public class LeastPlayerCount(int count)
        : GameConditionAttribute(ctx => ctx.PlayersCount >= count);

    public class FixPlayerCount(int count)
        : GameConditionAttribute(ctx => ctx.PlayersCount == count);

    public class CanStealRole(WerewolfRole werewolfRole)
        : GameConditionAttribute((id, ctx) =>
        {
            var thiefExist = ctx.RoleExists(WerewolfRole.Thief);
            var myRole = ctx.PlayerRole(id);

            if (myRole is null) return false;

            bool myRoleCanStolen = myRole == WerewolfRole.Thief || myRole.Value.CanBeStolen();

            var targetCanBeStolen = werewolfRole.CanBeStolen();

            return thiefExist && myRoleCanStolen && targetCanBeStolen;
        },
        ConditionFlag.NeedStealing);

    public class MustHaveRole(WerewolfRole werewolfRole)
        : GameConditionAttribute((id, ctx) => ctx.PlayerHasRole(id, werewolfRole));

    public class HaveAnyRole(WerewolfRole werewolfRole)
        : GameConditionAttribute((id, ctx) => werewolfRole.HasFlag(ctx.PlayerRole(id) ?? WerewolfRole.None));

    /// <summary>
    /// This condition is used to check if any of the given roles has flag in the alive roles foreach items.
    /// </summary>
    /// <param name="werewolfRoles"></param>
    public class AnyRoleExists(params WerewolfRole[] werewolfRoles)
        : GameConditionAttribute((ctx) => werewolfRoles.All(werewolfRole => ctx.AliveRoles.Any(x => werewolfRole.HasFlag(x.Value))));

    public class IsDgWithRoleModel(WerewolfRole werewolfRole)
        : GameConditionAttribute((playerId, ctx) => ctx.IsDgWithRoleModel(playerId, werewolfRole, strict: false));

    public class DgExistsWithRoleModel(WerewolfRole werewolfRole)
        : GameConditionAttribute((ctx) => ctx.DgExistsWithRoleModel(werewolfRole, strict: false));

    /// <summary>
    /// The current role is dg and the role model is <paramref name="werewolfRole"/>,
    /// or the dg can be stolen with role model of <paramref name="werewolfRole"/>.
    /// </summary>
    /// <param name="werewolfRole"></param>
    public class IsDgOrCanStealDgWithRoleModel(WerewolfRole werewolfRole)
        : GameConditionAttribute(new OrCondition(
            new IsDgWithRoleModel(werewolfRole), new AndCondition(
                new DgExistsWithRoleModel(werewolfRole), new CanStealRole(WerewolfRole.Doppelgänger))),
            ConditionFlag.DgRoleModel);

    public class HasOrCanAcquireRole(WerewolfRole werewolfRole)
        : GameConditionAttribute(new OrCondition(
            new MustHaveRole(werewolfRole), new CanStealRole(werewolfRole), new IsDgOrCanStealDgWithRoleModel(werewolfRole)));

    public class RoleMustExists(WerewolfRole werewolfRole)
        : GameConditionAttribute(ctx => ctx.RoleExists(werewolfRole));

    public class LeastRoleCount(int count, params WerewolfRole[] werewolfRoles)
        : GameConditionAttribute((ctx) => ctx.AliveRoles.Count(x => werewolfRoles.Contains(x.Value)) >= count);

    public class BeforeDay(int day)
        : GameConditionAttribute((ctx) => ctx.DayNumber < day);

    public class AfterDay(int day)
        : GameConditionAttribute((ctx) => ctx.DayNumber > day);

    public class AtOrBeforeDay(int day)
        : GameConditionAttribute((ctx) => ctx.DayNumber <= day);

    public static IGameCondition CombineConditionsFromEnumField<T>(this T enumField) where T : Enum
    {
        var fieldInfo = enumField.GetType().GetField(enumField.ToString());

        if (fieldInfo?.GetCustomAttributes(typeof(GameConditionAttribute), false)
            is not GameConditionAttribute[] attributes || attributes.Length == 0)
            return new GameConditionAttribute(true); // Default to always true condition

        IGameCondition combinedCondition = attributes[0];
        for (int i = 1; i < attributes.Length; i++)
        {
            var attribute = attributes[i];
            if (attribute.Negative)
            {
                combinedCondition = new NotCondition(combinedCondition);
            }

            combinedCondition = attribute.Combination switch
            {
                GameConditionCombination.Or => new OrCondition(combinedCondition, attribute),
                GameConditionCombination.And => new AndCondition(combinedCondition, attribute),
                _ => combinedCondition
            };
        }

        return combinedCondition;
    }
}

