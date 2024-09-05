using UnityEngine;
using Helpers;
using Skills;
using Weapons;

namespace Informations
{
    [CreateAssetMenu(fileName = "CharacterStats", menuName = "Informations/Stats", order = 0)]
    public class CharacterStat : ScriptableObject
    {
        [Space(5)]
        public Enums.CharacterTypes characterType;
        public Enums.AttackTypes attackType;

        [Space(5)]
        public string id;
        public string characterName;

        [Space(15)]
        public int level;

        [Space(15)]
        public float rage;
        public float rageReduceMul;

        public float moveSpeed;
        public float lookAtSpeed;

        public float attackDashSpeed;

        [Space(15)]
        public SkillBase[] skills;
        public WeaponBase[] weapons;

        public Enums.Skills moveSkill;
        public Enums.Skills jumpSkill;
        public Enums.Skills dashSkill;


        public SkillBase GetSkill(Enums.Skills _enumValue)
        {
            for (int i = 0; i < skills.Length; i++)
            {
                if (_enumValue == skills[i].skill)
                    return skills[i];
            }

            return null;
        }

    }


}