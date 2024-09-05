using Helpers;

namespace State
{
    public class AttackState : BaseState<Enums.BehaviourStates>
    {
        public AttackState(Enums.BehaviourStates _stateKey, StateHandler<Enums.BehaviourStates> _stateHandler) : base(_stateKey, _stateHandler) { }


        public override void EnterState()
        {
            if(stateHandler.subState == Enums.BehaviourStates.None)
            {
                if (Utilities.Distance(refHolder.transform.position, Utilities.playerTransform.position) > refHolder.weaponHandler.currentWeapon.attackDistance - .3f)
                    refHolder.charBehaviourStateHandler.ChangeSubState(Enums.BehaviourStates.Move);
                else
                    refHolder.weaponHandler.currentWeapon.DoBasicAttack();
            }
        }

        public override void UpdateState()
        {
            if (stateHandler.subState != Enums.BehaviourStates.None)
                return;

            Wait();
        }

        private void Wait()
        {
            if (!refHolder.weaponHandler.currentWeapon.isAttacking)
            {
                stateHandler.ChangeSubState(Enums.BehaviourStates.Idle);
            }
        }

        public override void FixedUpdateState()
        {

        }

        public override void ExitState()
        {

        }
    }
}