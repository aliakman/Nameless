using UnityEngine;
using Helpers;

namespace State
{
    public class PatrolState : BaseState<Enums.BehaviourStates>
    {
        public PatrolState(Enums.BehaviourStates _stateKey, StateHandler<Enums.BehaviourStates> _stateHandler) : base(_stateKey, _stateHandler) { }


        public Transform[] patrolPoints;

        public bool isSafe;

        public override void EnterState()
        {
            refHolder.infoHolder.characterStat.GetSkill(Enums.Skills.Patrol).Init(refHolder);
            stateHandler.mainState = Enums.BehaviourStates.Patrol;

        }

        public override void UpdateState()
        {
            refHolder.infoHolder.characterStat.GetSkill(Enums.Skills.Patrol).DoSkill();
        }

        public override void FixedUpdateState()
        {

        }

        public override void ExitState()
        {
            refHolder.infoHolder.characterStat.GetSkill(Enums.Skills.Patrol).Exit();
        }
    }
}
