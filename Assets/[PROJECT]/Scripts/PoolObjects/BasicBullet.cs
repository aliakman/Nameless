using UnityEngine;

public class BasicBullet : PoolItem
{
    private Rigidbody _rb;
    private Rigidbody rb { get{ return _rb ? _rb : _rb = GetComponent<Rigidbody>(); } }


    public override void Init(Vector3 _initPos, Vector3 _lookPos, float _bulletSpeed)
    {
        transform.position = _initPos;
        rb.AddForce(_lookPos.normalized * _bulletSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Wall")
        {
            rb.velocity = Vector3.zero;
            Helpers.Scripts.PoolManager().pools[key].TToPool(this);
        }
    }

}
