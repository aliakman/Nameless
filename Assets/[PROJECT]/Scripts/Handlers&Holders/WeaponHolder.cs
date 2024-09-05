using Helpers;
using UnityEngine;
using Weapons;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private WeaponBase[] weapons;


    private void OnEnable()
    {
        EventManager.EquipWeapon += Equip;
    }

    private void OnDisable()
    {
        EventManager.EquipWeapon -= Equip;
    }

    
    private void Equip(WeaponHandler _wpnHandler, Enums.Weapons _wpnID)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if(weapons[i].weaponID == _wpnID)
            {
                _wpnHandler.EquipWeapon(weapons[i]);
                return;
            }
        }
    }
}
