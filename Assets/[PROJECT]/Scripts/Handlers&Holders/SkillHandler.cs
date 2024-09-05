using Helpers;
using Skills;
using System.Collections.Generic;
using UnityEngine;

public class SkillHandler : ReferenceHolder
{
    private List<SkillBase> skills = new();
    private SkillBase currentSkill;

    public SkillBase GetSkill(Enums.Skills _skill)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            if(skills[i].skill == _skill)
                return currentSkill = skills[i];
        }

        SkillBase _skillBase;

        for (int i = 0; i < infoHolder.characterStat.skills.Length; i++)
        {
            if(infoHolder.characterStat.skills[i].skill == _skill)
            {
                _skillBase = Instantiate(infoHolder.characterStat.skills[i], transform);
                skills.Add(_skillBase);
                return currentSkill = _skillBase;
            }
        }

        return currentSkill = null;
    }

    public void ExitSkill()
    {
        if (currentSkill != null)
            currentSkill.Exit();
    }


}
