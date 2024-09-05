using Helpers;

namespace State
{
    public class SpawnState : BaseState<Enums.BehaviourStates>
    {
        public SpawnState(Enums.BehaviourStates _key, StateHandler<Enums.BehaviourStates> _stateHandler) : base(_key, _stateHandler) { }

        private Skills.SkillBase skill;


        public override void EnterState()
        {
            skill = refHolder.skillHandler.GetSkill(Enums.Skills.Spawn);
            skill.Init(refHolder);
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