using UnityEngine;
using Helpers;

namespace Skills
{
    public abstract class SkillBase : MonoBehaviour
    {
        public Enums.Skills skill;

        protected ReferenceHolder refHolder;

        #region Inits
        public virtual void Init(ReferenceHolder _refHolder) { refHolder = _refHolder; }
        #endregion

        #region Skills For Weapon
        public virtual void DoBasicSkill() 
        {
            Debug.Log("Skillbase DoBasicSkill");
            //PlayClip(basicAttackClips);

        }
        
        public virtual void DoAdvancedSkill() 
        {
            //PlayClip(advancedAttackClips);

        }

        public virtual void DoSpecialSkill() 
        {
            //PlayClip(specialAttackClips);

        }
        #endregion

        #region Skills
        public virtual void DoSkill() { }
        #endregion

        public virtual void Exit() { }

    }

}