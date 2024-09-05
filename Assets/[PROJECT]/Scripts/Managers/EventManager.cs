using System;

public static class EventManager
{
    public static ScriptHolder Scripts = new ScriptHolder();

    public static Action<WeaponHandler, Helpers.Enums.Weapons> EquipWeapon;
    public static Action</*SkillHandler, */Helpers.Enums.Skills> EquipSkill;

}

public struct ScriptHolder
{
    public Func<InputPool> InputPool;
    public Func<PoolManager> PoolManager;
    public Func<PatrolPoint> PatrolPoint;

    public Func<CharacterBehaviourStateHandler> PlayerBehaviourStateHandler;
    public Func<CharacterBehaviourStateHandler> EnemyBehaviourStateHandler;

    public Func<EnemyAttackPoints> EnemyAttackPoints;

}
