using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Skills
{
    public class BasicAttackDash : SkillBase
    {
        private bool isDashing;

        public override void Init(ReferenceHolder _refHolder)
        {
            base.Init(_refHolder);
            isDashing = true;
        }

        public override void DoBasicSkill()
        {
            if (!isDashing) 
                return;
            Dash();
        }

        private async void Dash()
        {
            while (isDashing)
            {
                refHolder.charController.Move(refHolder.transform.forward * refHolder.infoHolder.characterStat.moveSpeed * Time.deltaTime);
                isDashing = refHolder.weaponHandler.currentWeapon.isAttacking;
                await UniTask.Yield();
            }

            await UniTask.CompletedTask;

        }

    }
}