using UnityEngine;
using Helpers;

namespace State
{
    public class JumpState : BaseState<Enums.BehaviourStates> //Space-Mouse[Look]
    {
        public JumpState(Enums.BehaviourStates _stateKey, StateHandler<Enums.BehaviourStates> _stateHandler) : base(_stateKey, _stateHandler) { }


        public override void EnterState()
        {
            stateHandler.mainState = Enums.BehaviourStates.Jump;
            refHolder.infoHolder.characterStat.GetSkill(refHolder.infoHolder.characterStat.jumpSkill).Init(refHolder);
        }

        public override void UpdateState()
        {

        }

        public override void FixedUpdateState()
        {
            refHolder.infoHolder.characterStat.GetSkill(refHolder.infoHolder.characterStat.jumpSkill).DoSkill();
        }

        public override void ExitState()
        {
            refHolder.infoHolder.characterStat.GetSkill(refHolder.infoHolder.characterStat.jumpSkill).Exit();
        }

    }
}
