using UnityEngine;

namespace Weapons
{
    public abstract partial class WeaponBase : ReferenceHolder //ATTACK
    {
        public virtual void DoBasicAttack()
        {
            if (!InitCheck(isBasicReady))
                return;
            else
            {
                //if (tmpComboCount <= comboCount)
                //{
                    AttackCooldown(basicCooldown, 0);
                //}
            }

            Debug.Log($"{weaponID}   Basic Attack");

            SetWeaponAnimation();
            InitSkills(basicSkills, 0);
        } //Basic

        public virtual void DoAdvancedAttack()
        {
            if (!InitCheck(isAdvancedReady))
                return;
            
            AttackCooldown(advancedCooldown, 1);

            //advancedSkill.DoAdvancedSkill();

        } //Advanced

        public virtual void DoSpecialAttack()
        {
            if (!InitCheck(isSpecialReady))
                return;
            
            AttackCooldown(specialCooldown, 2);

            //specialSkill.DoSpecialSkill();

        } //Special

    }
}