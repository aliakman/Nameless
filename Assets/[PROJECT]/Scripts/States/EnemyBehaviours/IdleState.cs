using Helpers;

namespace State
{
    public class IdleState : BaseState<Enums.BehaviourStates>
    {
        public IdleState(Enums.BehaviourStates _stateKey, StateHandler<Enums.BehaviourStates> _stateHandler) : base(_stateKey, _stateHandler) { }

        private Skills.SkillBase skill;


        public override void EnterState()
        {
            skill = refHolder.skillHandler.GetSkill(Enums.Skills.Idle);
            skill.Init(refHolder);
        }

        public override void UpdateState()
        {
            skill.DoSkill();
        }

        public override void FixedUpdateState()
        {

        }

        public override void ExitState()
        {
            skill.Exit();
        }
    }
}
