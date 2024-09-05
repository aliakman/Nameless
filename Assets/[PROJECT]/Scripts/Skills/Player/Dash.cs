using UnityEngine;
using Helpers;
using Cysharp.Threading.Tasks;

namespace Skills
{
    public class Dash : SkillBase
    {
        [Header("Dash Stats")]
        [Space(10)]
        [Header("Level One")]
        public float dashSpeedMultiplier;
        public int dashDelay;
        public float lookAtSpeed;

        public bool isInTask;


        public override void Init(ReferenceHolder _refHolder)
        {
            if (refHolder == null)
                isInTask = false;
            base.Init(_refHolder);
        }

        public async void AsyncDelayer()
        {
            if (isInTask) return;
            isInTask = true;
            await UniTask.Delay(dashDelay);
            refHolder.charBehaviourStateHandler.ChangeMainState(Enums.BehaviourStates.Move);
            isInTask = false;
            await UniTask.CompletedTask;
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
            if (!isInTask) 
                AsyncDelayer();

            //LookAt(_charTransform, _inputPool.movement);
            refHolder.charController.Move(refHolder.transform.forward * refHolder.infoHolder.characterStat.moveSpeed * dashSpeedMultiplier * Time.fixedDeltaTime);
        }
    }

}