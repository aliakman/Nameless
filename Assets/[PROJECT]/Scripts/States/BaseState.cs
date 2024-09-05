using System;

namespace State
{
    public abstract class BaseState<T> where T : Enum
    {
        public BaseState(T _key ,StateHandler<T> _stateHandler)
        {
            stateKey = _key;
            refHolder = _stateHandler;
            stateHandler = _stateHandler;
        }

        public T stateKey;
        protected ReferenceHolder refHolder;
        protected StateHandler<T> stateHandler;

        public virtual void EnterState() { }
        public virtual void UpdateState() { }
        public virtual void FixedUpdateState() { }
        public virtual void ExitState() { }
    }

}