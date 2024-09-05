using UnityEngine;
using Helpers;

namespace State
{
    public class AdvancedAttackState : BaseState<Enums.BehaviourStates>
    {
        public AdvancedAttackState(Enums.BehaviourStates _stateKey, StateHandler<Enums.BehaviourStates> _stateHandler) : base(_stateKey, _stateHandler) { }


        public override void EnterState()
        {
            stateHandler.subState = Enums.BehaviourStates.AdvancedAttack;

            if (!refHolder.weaponHandler.AdvancedWeaponCheck())
                stateHandler.SetSubStateNone();
            else
                refHolder.weaponHandler.DoAdvancedAttack();
        }

        public override void UpdateState()
        {

        }

        public override void FixedUpdateState()
        {

        }

        public override void ExitState()
        {

        }
    }
}
