using UnityEngine;
using Helpers;

namespace Weapons
{
    public abstract partial class WeaponBase : ReferenceHolder //ANIMATION
    {
        public virtual string GetClipName(string[] _clipTriggerValueNames)
        {
            return _clipTriggerValueNames[Random.Range(0, _clipTriggerValueNames.Length)];
        }

        public virtual void SetWeaponAnimation()
        {
            Utilities.PlayAnimationClip(refHolder.animator, "Idle");

            gameObject.SetActive(true);
            
            baseRuntimeAnimatorController = refHolder.animator.runtimeAnimatorController;
            refHolder.animator.runtimeAnimatorController = overridedAnimators[animatorIndex];
            
            refHolder.animator.SetLayerWeight(2, 1);
            
            Utilities.SetAnimationTrigger(refHolder.animator, GetClipName(basicAttackClips));

            animatorIndex++;
            if (animatorIndex >= overridedAnimators.Length)
                animatorIndex = 0;
        }

        public virtual void SetDefaultAnimation()
        {
            refHolder.animator.SetLayerWeight(2, 0);
            refHolder.animator.runtimeAnimatorController = baseRuntimeAnimatorController;
            gameObject.SetActive(false);
        }
    }
}