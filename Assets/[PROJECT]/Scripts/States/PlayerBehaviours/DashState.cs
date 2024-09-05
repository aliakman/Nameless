using UnityEngine;
using Helpers;

namespace State
{
    public class DashState : BaseState<Enums.BehaviourStates> //V-Mouse[Look]
    {
        public DashState(Enums.BehaviourStates _stateKey, StateHandler<Enums.BehaviourStates> _stateHandler) : base(_stateKey, _stateHandler) { }


        public override void EnterState()
        {
            stateHandler.mainState = Enums.BehaviourStates.Dash;
            Utilities.PlayAnimationClip(refHolder.animator, "Dash");
            refHolder.infoHolder.characterStat.GetSkill(refHolder.infoHolder.characterStat.dashSkill).Init(refHolder);
        }

        public override void UpdateState()
        {

        }

        public override void FixedUpdateState()
        {
            refHolder.infoHolder.characterStat.GetSkill(refHolder.infoHolder.characterStat.dashSkill).DoSkill();
        }

        public override void ExitState()
        {
            refHolder.infoHolder.characterStat.GetSkill(refHolder.infoHolder.characterStat.dashSkill).Exit();
        }

    }
}
