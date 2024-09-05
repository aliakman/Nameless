using UnityEngine;
using Helpers;

namespace State
{
    public class DefenceState : BaseState<Enums.BehaviourStates>
    {
        public DefenceState(Enums.BehaviourStates _stateKey, StateHandler<Enums.BehaviourStates> _stateHandler) : base(_stateKey, _stateHandler) { }


        public override void EnterState()
        {
            stateHandler.mainState = Enums.BehaviourStates.Defence;
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
