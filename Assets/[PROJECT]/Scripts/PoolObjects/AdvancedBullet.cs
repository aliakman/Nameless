using UnityEngine;

public class AdvancedBullet : PoolItem
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Wall")
            Helpers.Scripts.PoolManager().pools["AdvancedBullet"].TToPool(this);
    }
}
