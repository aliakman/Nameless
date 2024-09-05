using Helpers;
using Skills;
using UnityEngine;

public class SkillHolder : MonoBehaviour
{
    [SerializeField] private SkillBase[] skills;


    private void OnEnable()
    {
        EventManager.EquipSkill += Equip;
    }

    private void OnDisable()
    {
        EventManager.EquipSkill -= Equip;
    }


    private void Equip(/*SkillHandler _skillHandler, */Enums.Skills _skill)
    {
        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i].skill == _skill)
            {
                //_skillHandler.EquipSkill(skills[i]);
                return;
            }
        }
    }
}
