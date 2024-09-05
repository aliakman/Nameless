using UnityEngine;
using Helpers;

namespace Skills
{
    public class MoveToAttack : SkillBase
    {
        [Space(15)]
        [SerializeField] private int moveSpeed;
        private bool isReached;
        private int meleeAttackPointIndex;

        private Vector3 currentTarget;
        private Vector3 formerTarget;


        public override void Init(ReferenceHolder _refHolder)
        {
            base.Init(_refHolder);

            //formerTarget = currentTarget = GetPlayerNearPoint();
            refHolder.navMeshAgent.SetDestination(GetPlayerNearPoint());
            
            refHolder.navMeshAgent.speed = moveSpeed;
            
            Utilities.PlayAnimationClip(refHolder.animator, "Run");

            meleeAttackPointIndex = Random.Range(0, Scripts.EnemyAttackPoints().nearPoints.Length);
            isReached = false;
        }

        public override void DoSkill()
        {
            if (!isReached)
            {
                if (refHolder.navMeshAgent.remainingDistance > .3f)
                    refHolder.navMeshAgent.destination = currentTarget;
                else
                    isReached = true;
            }
            else
                refHolder.charBehaviourStateHandler.ChangeSubState(Enums.BehaviourStates.Idle);

        }

        private Vector3 GetPlayerNearPoint()
        {
            if(refHolder.infoHolder.characterStat.attackType == Enums.AttackTypes.Melee)
            {
                if (Utilities.Distance(Scripts.EnemyAttackPoints().nearPoints[meleeAttackPointIndex].position, refHolder.transform.position) > refHolder.weaponHandler.currentWeapon.attackDistance - .3f)
                {
                    isReached = false;
                    return currentTarget = Scripts.EnemyAttackPoints().nearPoints[meleeAttackPointIndex].position;
                }
                else
                {
                    isReached = true;
                    return currentTarget = refHolder.transform.position;
                }
            }
            else if (refHolder.infoHolder.characterStat.attackType == Enums.AttackTypes.Ranged)
            {
                isReached = false;
                currentTarget = Utilities.GetRandomPosition(Utilities.playerTransform.position, refHolder.transform.position.y, refHolder.weaponHandler.currentWeapon.attackDistance);
                return currentTarget;

                //if (Utilities.Distance(Utilities.playerTransform.position, refHolder.transform.position) > refHolder.weaponHandler.currentWeapon.attackDistance - .3f)
                //{
                //    currentTarget = Utilities.GetRandomPosition(Utilities.playerTransform.position, refHolder.weaponHandler.currentWeapon.attackDistance * .5f, refHolder.weaponHandler.currentWeapon.attackDistance * .95f);
                //    Debug.Log("IFFFFF   :   " + currentTarget);
                //    isReached = false;
                //    return currentTarget;
                //}
                //else
                //{
                //    Debug.Log("ELSEEE   :   ");
                //    isReached = true;
                //    return currentTarget = refHolder.transform.position;
                //}
            }

            return currentTarget = refHolder.transform.position;
        }

        public override void Exit()
        {
            refHolder.navMeshAgent.speed = 0;
        }

    }
}
