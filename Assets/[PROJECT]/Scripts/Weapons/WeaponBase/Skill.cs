using Skills;

namespace Weapons
{
    public abstract partial class WeaponBase : ReferenceHolder //SKILL
    {
        public virtual void InitSkills(SkillBase[] _skills, int _skillType)
        {
            for (int i = 0; i < basicSkills.Length; i++)
            {
                if (_skills[i] != null)
                {
                    _skills[i].Init(refHolder);

                    switch (_skillType)
                    {
                        case 0:
                            _skills[i].DoBasicSkill();
                            break;
                        case 1:
                            _skills[i].DoAdvancedSkill();
                            break;
                        case 2:
                            _skills[i].DoSpecialSkill();
                            break;
                    }
                }
            }
        }
    }
}