using UnityEngine;

namespace Interfaces
{
    public abstract class Collideable : MonoBehaviour
    {
        public virtual void TriggerEnter() { }
        public virtual void TriggerStay() { }
        public virtual void TriggerExit() { }

        public virtual void CollisionEnter() { }
        public virtual void CollisionStay() { }
        public virtual void CollisionExit() { }

    }
}