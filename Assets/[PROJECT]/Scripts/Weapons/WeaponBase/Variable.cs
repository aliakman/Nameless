using Helpers;
using Skills;
using UnityEngine;

namespace Weapons
{
    public abstract partial class WeaponBase : ReferenceHolder //VARIABLE
    {
        public Enums.Weapons weaponID;

        [SerializeField] private AnimatorOverrideController[] overridedAnimators;
        private RuntimeAnimatorController baseRuntimeAnimatorController;

        protected ReferenceHolder refHolder;
        public virtual void Init(ReferenceHolder _refHolder) { refHolder = _refHolder; }

        [SerializeField] private string[] basicAttackClips;
        [SerializeField] private string[] advancedAttackClips;
        [SerializeField] private string[] specialAttackClips;

        [Header("Skills")]
        [SerializeField] private SkillBase[] basicSkills;
        [SerializeField] private SkillBase[] advancedSkills;
        [SerializeField] private SkillBase[] specialSkills;

        [Header("Cooldowns")]
        [SerializeField] private int comboCooldown;
        [SerializeField] private int basicCooldown;
        [SerializeField] private int advancedCooldown;
        [SerializeField] private int specialCooldown;
        private int animatorIndex;

        [Header("Booleans")]
        public bool isInCombo = false;
        public bool isAttacking = false;
        public bool isBasicReady = true;
        public bool isAdvancedReady = true;
        public bool isSpecialReady = true;

        public float attackDistance;
    }
}