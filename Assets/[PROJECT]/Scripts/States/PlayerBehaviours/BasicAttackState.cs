using UnityEngine;
using Helpers;

namespace State
{
    public class BasicAttackState : BaseState<Enums.BehaviourStates>
    {
        public BasicAttackState(Enums.BehaviourStates _stateKey, StateHandler<Enums.BehaviourStates> _stateHandler) : base(_stateKey, _stateHandler) { }


        public override void EnterState()
        {
            //stateHandler.subState = Enums.BehaviourStates.BasicAttack;
            stateHandler.mainState = Enums.BehaviourStates.BasicAttack;


            if (!refHolder.weaponHandler.BasicWeaponCheck())
                stateHandler.SetSubStateNone();
            else
            {
                refHolder.animator.SetLayerWeight(2, 1);
                refHolder.weaponHandler.DoBasicAttack();
            }

        }

        public override void UpdateState()
        {
            if (!refHolder.weaponHandler.currentWeapon.isBasicReady) return;

            if (!refHolder.weaponHandler.currentWeapon.isAttacking && !refHolder.weaponHandler.currentWeapon.gameObject.activeSelf)
                stateHandler.ChangeMainState(Enums.BehaviourStates.Move);

        }

        public override void FixedUpdateState()
        {
            //if(refHolder.weaponHandler.currentWeapon.weaponType == Enums.WeaponTypes.Melee)
                //refHolder.charController.Move(refHolder.transform.forward * refHolder.infoHolder.characterStat.attackDashSpeed * Time.fixedDeltaTime);
        }

        public override void ExitState()
        {
            refHolder.animator.SetLayerWeight(2, 0);
        }
    }
}
