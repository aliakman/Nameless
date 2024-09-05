using UnityEngine;

namespace Weapons
{
    public class Pistol : WeaponBase
    {
        [Space(15)]
        [Header("Variables")]
        [SerializeField] private PoolItem basicBullet;
        [SerializeField] private PoolItem advancedBullet;
        [SerializeField] private PoolItem specialBullet;

        [SerializeField] private float basicBulletSpeed;
        [SerializeField] private float advancedBulletSpeed;
        [SerializeField] private float specialBulletSpeed;


        public override void Init(ReferenceHolder _refHolder)
        {
            base.Init(_refHolder);
        }

        public override void DoBasicAttack()
        {
            base.DoBasicAttack();
            refHolder.poolManager.GetPoolItem(basicBullet).Init(refHolder.transform.position, refHolder.transform.forward, basicBulletSpeed);
        }

        public override void DoAdvancedAttack()
        {
            base.DoAdvancedAttack();
            refHolder.poolManager.GetPoolItem(advancedBullet).Init(refHolder.transform.position, refHolder.transform.forward, advancedBulletSpeed);
        }

        public override void DoSpecialAttack()
        {
            base.DoSpecialAttack();
            refHolder.poolManager.GetPoolItem(specialBullet).Init(refHolder.transform.position, refHolder.transform.forward, specialBulletSpeed);
        }
    }

}