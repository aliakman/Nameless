using UnityEngine;

namespace Weapons
{
    public class Sword : WeaponBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.name == "Obstacle")
            {
                MeshRenderer _meshRenderer = other.GetComponent<MeshRenderer>();
                _meshRenderer.material.color = Color.white;

            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == "Obstacle")
            {
                MeshRenderer _meshRenderer = other.GetComponent<MeshRenderer>();
                _meshRenderer.material.color = Color.blue;
            }
        }

    }

}