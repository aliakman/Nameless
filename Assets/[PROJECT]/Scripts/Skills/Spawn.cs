using UnityEngine;
using Helpers;

namespace Skills
{
    public class Spawn : SkillBase
    {
        public override void Init(ReferenceHolder _refHolder)
        {
            base.Init(_refHolder);
            Utilities.PlayAnimationClip(refHolder.animator, "Spawn");
        }

        public override void Exit()
        {
            base.Exit();
            if (refHolder.infoHolder.characterStat.characterType == Enums.CharacterTypes.Player)
                refHolder.charBehaviourStateHandler.ChangeMainState(Enums.BehaviourStates.Move);
            else if (refHolder.infoHolder.characterStat.characterType == Enums.CharacterTypes.Enemy)
                refHolder.charBehaviourStateHandler.ChangeMainState(Enums.BehaviourStates.Idle);
        }

    }
}