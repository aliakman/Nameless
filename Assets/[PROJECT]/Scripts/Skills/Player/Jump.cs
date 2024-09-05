using UnityEngine;
using Helpers;

namespace Skills
{
    public class Jump : SkillBase
    {
        [Space(10)]
        [Header("Level One")]
        public float jumpSpeed;
        public float lookAtSpeed;
        public float gravityMultiplier;
        [HideInInspector] public float ySpeed;

        
        public override void Init(ReferenceHolder _refHolder)
        {
            base.Init(_refHolder);
            ySpeed = jumpSpeed;
            Utilities.SetAnimationTrigger(refHolder.animator, "Jump");
        }

        private void LookAt()
        {
            if (refHolder.inputPool.movement == Vector3.zero) return;

            //transform.LookAt(Utilities.LookAtPos(cam, transform.position, inputPool.look));
            Quaternion _targetQuaternion = Quaternion.LookRotation((refHolder.transform.position + refHolder.inputPool.movement - refHolder.transform.position).normalized);
            Quaternion _newRotation = Quaternion.Slerp(refHolder.transform.rotation, _targetQuaternion, lookAtSpeed * Time.fixedDeltaTime);
            refHolder.transform.rotation = _newRotation;
        }

        public override void DoSkill()
        {
            LookAt();

            Vector3 _moveVelocity = refHolder.inputPool.movement.normalized * refHolder.infoHolder.characterStat.moveSpeed;
            _moveVelocity.y = ySpeed;
            ySpeed += Physics.gravity.y * Time.fixedDeltaTime * gravityMultiplier;
            refHolder.charController.Move(_moveVelocity * Time.fixedDeltaTime);

            if (refHolder.charController.isGrounded)
                refHolder.charBehaviourStateHandler.ChangeMainState(Enums.BehaviourStates.Move);

            if (refHolder.charController.velocity.y < 0)
                Utilities.SetAnimationTrigger(refHolder.animator, "Fall");
        }
    }

}
