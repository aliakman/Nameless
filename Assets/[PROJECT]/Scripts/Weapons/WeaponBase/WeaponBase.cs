using UnityEngine;

namespace Weapons
{
    public abstract partial class WeaponBase : ReferenceHolder //BASE
    {
        public bool InitCheck(bool _skill)
        {
            if (isAttacking && _skill && isInCombo)
                return true;

            if (!isAttacking && _skill)
                return true;

            return false;
        }

        public virtual void Exit()
        {
            Debug.Log("Attack ended.");

            if(refHolder.infoHolder.characterStat.characterType == Helpers.Enums.CharacterTypes.Enemy)
            {
                if (!isInCombo)
                {
                    SetDefaultAnimation();
                    isAttacking = false;
                }
            }
            else
            {
                SetDefaultAnimation();
                isAttacking = false;
            }
        }

    }

}