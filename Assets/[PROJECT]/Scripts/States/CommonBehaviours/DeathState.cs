using Helpers;

namespace State
{
    public class DeathState : BaseState<Enums.BehaviourStates>
    {
        public DeathState(Enums.BehaviourStates _stateKey, StateHandler<Enums.BehaviourStates> _stateHandler) : base(_stateKey, _stateHandler) { }


        public override void EnterState()
        {
            throw new System.NotImplementedException();
        }
        
        public override void UpdateState()
        {
            throw new System.NotImplementedException();
        }

        public override void FixedUpdateState()
        {
            throw new System.NotImplementedException();
        }

        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }

    }

}