using UnityEngine;
using Helpers;

namespace Skills
{
    public class Patrol : SkillBase
    {
        [Space(15)]
        [SerializeField] private LayerMask checkLayer;
        
        [SerializeField] private float checkRadius;
        

        public override void Init(ReferenceHolder _refHolder)
        {
            base.Init(_refHolder);
            refHolder.charBehaviourStateHandler.patrolState.isSafe = true;
        }

        public override void DoSkill()
        {
            if (!IsPlayerAround(refHolder.transform.position))
            {
                refHolder.charBehaviourStateHandler.patrolState.isSafe = false;
                refHolder.charBehaviourStateHandler.ChangeMainState(Enums.BehaviourStates.Attack);
            }
            //else
                //refHolder.stateHandler.patrolState.isSafe = true;
        }

        private bool IsPlayerAround(Vector3 _checkCenterPos)
        {
            Collider[] _hitColliders = Physics.OverlapSphere(_checkCenterPos, checkRadius, checkLayer);

            if (_hitColliders.Length > 0)
                return false;

            return true;
        }

    }

}