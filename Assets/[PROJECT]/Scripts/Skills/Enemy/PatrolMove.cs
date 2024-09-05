using UnityEngine;
using Helpers;

namespace Skills
{
    public class PatrolMove : SkillBase
    {
        [Space(15)]
        [SerializeField] private int moveSpeed;
        [SerializeField] private int moveIncreaserMul;
        private bool isReached;
        private Transform patrolPoint;
        
        public override void Init(ReferenceHolder _refHolder)
        {
            base.Init(_refHolder);

            patrolPoint = Utilities.GetPatrolPoint();

            Utilities.PlayAnimationClip(refHolder.animator, "Run");

            refHolder.navMeshAgent.speed = moveSpeed;
            isReached = false;

            refHolder.navMeshAgent.SetDestination(patrolPoint.position);

            if (refHolder.charBehaviourStateHandler.mainState == Enums.BehaviourStates.Attack)
                refHolder.navMeshAgent.speed *= moveIncreaserMul;
        }

        public override void DoSkill()
        {
            if (refHolder.navMeshAgent.remainingDistance < .3f)
            {
                if (!isReached)
                {
                    isReached = true;
                    refHolder.charBehaviourStateHandler.ChangeSubState(Enums.BehaviourStates.Idle);
                }
            }
            else
                refHolder.navMeshAgent.destination = patrolPoint.position;

        }

        public override void Exit()
        {
            refHolder.navMeshAgent.speed = 0;
        }

    }
}
