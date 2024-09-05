using UnityEngine;
using Helpers;

namespace Skills
{
    public class Idle : SkillBase
    {
        [Space(15)]
        [SerializeField] private float idleDelay;
        [SerializeField] private float idleReducerMul;
        private float tmpIdleDelay;

        [Space(15)]
        [SerializeField] private LayerMask checkLayer;
        [SerializeField] private float checkRadius;


        public override void Init(ReferenceHolder _refHolder)
        {
            base.Init(_refHolder);

            Utilities.PlayAnimationClip(refHolder.animator, "Idle");


            if (refHolder.charBehaviourStateHandler.mainState == Enums.BehaviourStates.Attack)
                tmpIdleDelay = idleDelay * idleReducerMul;
            else
                tmpIdleDelay = idleDelay;

        }

        public override void DoSkill()
        {
            Wait();
        }

        private void Wait()
        {
            if (refHolder.charBehaviourStateHandler.mainState == Enums.BehaviourStates.Attack)
            {
                refHolder.transform.LookAt(Utilities.playerTransform.position);

                if (Utilities.Distance(Utilities.playerTransform.position, refHolder.transform.position) > refHolder.weaponHandler.currentWeapon.attackDistance - .3f)
                {
                    refHolder.charBehaviourStateHandler.ChangeSubState(Enums.BehaviourStates.Move);
                }
                else
                {
                    if (tmpIdleDelay <= 0)
                    {
                        tmpIdleDelay = idleDelay;
                        if(refHolder.charBehaviourStateHandler.formerSubState == null && refHolder.charBehaviourStateHandler.currentMainState.stateKey == Enums.BehaviourStates.Attack)
                            refHolder.charBehaviourStateHandler.ChangeSubState(Enums.BehaviourStates.Move);
                        else
                            refHolder.charBehaviourStateHandler.SetSubStateNone();

                    }
                    else
                        tmpIdleDelay -= Time.deltaTime;
                }
                return;
            }

            if (IsPlayerAround())
            {
                refHolder.transform.LookAt(Utilities.playerTransform.position);
                //refHolder.charBehaviourStateHandler.ChangeSubState(Enums.BehaviourStates.Move);
                refHolder.charBehaviourStateHandler.ChangeMainState(Enums.BehaviourStates.Attack);
            }
        }

        private bool IsPlayerAround()
        {
            Collider[] _hitColliders = Physics.OverlapSphere(refHolder.transform.position, checkRadius, checkLayer);

            if (_hitColliders.Length > 0)
                return true;

            return false;
        }

    }
}