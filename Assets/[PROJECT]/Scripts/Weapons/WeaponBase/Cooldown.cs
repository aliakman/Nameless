using Cysharp.Threading.Tasks;
using Helpers;

namespace Weapons
{
    public abstract partial class WeaponBase : ReferenceHolder //COOLDOWN
    {
        private async void ComboCooldown()
        {
            //if (!isInCombo)
                isInCombo = true;

            await UniTask.Delay(comboCooldown);

            //if (isBasicReady) //For basic attack combo
            //{
                isInCombo = false;
                animatorIndex = 0;
                //tmpComboCount = 0;
            //}
            //else
            //    ComboCooldown();

            await UniTask.CompletedTask;
        }

        private async void AttackCooldown(int _cooldown, int _weaponSkillIndex)
        {
            isAttacking = true;

            switch (_weaponSkillIndex)
            {
                case 0:
                    isBasicReady = false;
                    //ComboCooldown();
                    if (comboCooldown != 0 && !isInCombo)
                        ComboCooldown(); //Basic attack combo
                    break;
                case 1:
                    isAdvancedReady = false;
                    break;
                case 2:
                    isSpecialReady = false;
                    break;
            }

            await UniTask.Delay(_cooldown);

            switch (_weaponSkillIndex)
            {
                case 0:
                    isBasicReady = true;
                    if (isInCombo && refHolder.infoHolder.characterStat.characterType == Enums.CharacterTypes.Enemy)
                        DoBasicAttack();
                    break;
                case 1:
                    isAdvancedReady = true;
                    break;
                case 2:
                    isSpecialReady = true;
                    break;
            }

            await UniTask.CompletedTask;
        }
    }
}