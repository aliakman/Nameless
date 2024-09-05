using UnityEngine;
using Helpers;

namespace Skills
{
    public class InputMove : SkillBase
    {
        [Space(15)]
        [Header("Private Variables")]
        [HideInInspector] public Vector3 moveDir;

        private bool isJumpedDash;

        Skills.Jump jumpSkill;

        public override void Init(ReferenceHolder _refHolder)
        {
            base.Init(_refHolder);

            if (!refHolder.charController.isGrounded)
            {
                if (refHolder.charBehaviourStateHandler.mainState == Enums.BehaviourStates.Dash)
                {
                    isJumpedDash = true;
                    jumpSkill = (Skills.Jump)refHolder.infoHolder.characterStat.GetSkill(Enums.Skills.JumpOne);
                    jumpSkill.ySpeed = 0;
                }
            }

            refHolder.charBehaviourStateHandler.mainState = Enums.BehaviourStates.Move;
        }

        public override void DoSkill()
        {
            if (isJumpedDash)
            {
                if (!refHolder.charController.isGrounded)
                {
                    Utilities.SetAnimationTrigger(refHolder.animator, "Fall");

                    Vector3 _moveVelocity = refHolder.inputPool.movement.normalized * refHolder.infoHolder.characterStat.moveSpeed;
                    _moveVelocity.y = jumpSkill.ySpeed;
                    jumpSkill.ySpeed += Physics.gravity.y * Time.fixedDeltaTime * jumpSkill.gravityMultiplier;
                    refHolder.charController.Move(_moveVelocity * Time.fixedDeltaTime);
                }
                else
                    isJumpedDash = false;

                return;
            }

            moveDir = refHolder.inputPool.movement;

            Vector3 _dir = moveDir.normalized;

            if (_dir.magnitude > .1f)
            {
                Utilities.PlayAnimationClip(refHolder.animator, "Run");
                Move(_dir);
            }
            else if(!refHolder.charController.isGrounded)
                refHolder.charController.Move(Vector3.up * -9.81f);
            else if (refHolder.charController.isGrounded)
                Utilities.PlayAnimationClip(refHolder.animator, "Idle");

            if (moveDir != Vector3.zero && refHolder.charBehaviourStateHandler.subState == Enums.BehaviourStates.None)
                LookAt();

        }

        private void LookAt()
        {
            Quaternion _targetQuaternion = Quaternion.LookRotation((refHolder.charBehaviourStateHandler.transform.position + moveDir - refHolder.charBehaviourStateHandler.transform.position).normalized);
            Quaternion _newRotation = Quaternion.Slerp(refHolder.charBehaviourStateHandler.transform.rotation, _targetQuaternion, refHolder.infoHolder.characterStat.lookAtSpeed * Time.fixedDeltaTime);
            refHolder.charBehaviourStateHandler.transform.rotation = _newRotation;
        }

        private void Move(Vector3 _direction)
        {
            float _targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            Vector3 _moveDir = Quaternion.Euler(0, _targetAngle, 0f) * Vector3.forward;
            _moveDir = _moveDir.normalized * refHolder.infoHolder.characterStat.moveSpeed * Time.fixedDeltaTime;
            _moveDir.y = Physics.gravity.y;
            refHolder.charController.Move(_moveDir + Vector3.up * -9.81f);
        }

        public override void Exit()
        {

        }

    }
}
