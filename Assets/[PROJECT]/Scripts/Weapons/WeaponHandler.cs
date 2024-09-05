using UnityEngine;
using Weapons;

public class WeaponHandler : ReferenceHolder
{
    public WeaponBase currentWeapon { get; private set; }

    [SerializeField] private WeaponBase firstWeapon;
    [SerializeField] private WeaponBase secWeapon;

    private void Awake()
    {
        ExitWeapon();
        currentWeapon = firstWeapon;

        if (firstWeapon != null)
            firstWeapon.Init(this);
        if (secWeapon != null)
            secWeapon.Init(this);
    }

    public bool BasicWeaponCheck()
    {
        return currentWeapon.InitCheck(weaponHandler.currentWeapon.isBasicReady);
    }

    public bool AdvancedWeaponCheck()
    {
        return currentWeapon.InitCheck(weaponHandler.currentWeapon.isAdvancedReady);
    }

    public bool SpecialWeaponCheck()
    {
        return currentWeapon.InitCheck(weaponHandler.currentWeapon.isSpecialReady);
    }

    public void DoBasicAttack()
    {
        currentWeapon.DoBasicAttack();
    }

    public void DoAdvancedAttack()
    {
        currentWeapon.DoAdvancedAttack();
    }

    public void DoSpecialAttack()
    {
        currentWeapon.DoSpecialAttack();
    }

    public void EquipWeapon(WeaponBase _newWeapon)
    {
        ExitWeapon();
        currentWeapon = currentWeapon == firstWeapon ? firstWeapon = _newWeapon : secWeapon = _newWeapon;
        if (currentWeapon != null)
            currentWeapon.Init(this);
    }

    public void SwitchWeapon()
    {
        ExitWeapon();
        currentWeapon = currentWeapon == firstWeapon ? secWeapon : firstWeapon;
    }

    public void ExitWeapon()
    {
        if(currentWeapon != null)
            currentWeapon.Exit();
    }

}
