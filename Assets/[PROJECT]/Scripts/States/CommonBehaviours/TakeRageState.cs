using Helpers;

namespace State
{
    public class TakeRageState : BaseState<Enums.BehaviourStates>
    {
        public TakeRageState(Enums.BehaviourStates _stateKey, StateHandler<Enums.BehaviourStates> _stateHandler) : base(_stateKey, _stateHandler) { }


        public override void EnterState()
        {
            refHolder.statHandler.TakeRage(10);
            //refHolder.infoHolder.characterStat.GetSkill("Enums.Skill.TakeRage").Init(refHolder);

        }

        public override void UpdateState()
        {
            //refHolder.infoHolder.characterStat.GetSkill("Enums.Skill.TakeRage").DoSkill();

        }

        public override void FixedUpdateState()
        {

        }
        
        public override void ExitState()
        {
            //refHolder.infoHolder.characterStat.GetSkill("Enums.Skill.TakeRage").Exit();

        }

    }

}