using UnityEngine;
using Helpers;

namespace State
{
    public class RepulseState : BaseState<Enums.BehaviourStates> //F-Mouse[Look]
    {
        public RepulseState(Enums.BehaviourStates _stateKey, StateHandler<Enums.BehaviourStates> _stateHandler) : base(_stateKey, _stateHandler) { }


        [Header("Variables")]
        [SerializeField] private float coneAngle = 60;
        [SerializeField] private int numRays = 10;
        [SerializeField] private float maxScanDistance = 8;
        private float tmpMaxScanDistance;
        //[SerializeField] private int repulseDelayer = 2500;
        [SerializeField] private LayerMask repulseLayer /* player */;
        [SerializeField] private Color color = Color.yellow;

        public override void EnterState()
        {
            stateHandler.mainState = Helpers.Enums.BehaviourStates.Repulse;
        }

        public override void UpdateState()
        {
            Draw();
            if (tmpMaxScanDistance <= maxScanDistance)
                tmpMaxScanDistance += Time.deltaTime * 3;
        }

        public override void FixedUpdateState()
        {
            stateHandler.transform.LookAt(Utilities.LookAtPos(refHolder.mainCam, stateHandler.transform.position, refHolder.inputPool.look));
        }

        private void Draw()
        {
            for (int i = 0; i < numRays; i++)
            {
                float angle = coneAngle * i / (numRays - 1) - coneAngle / 2.0f;
                Vector3 direction = Quaternion.Euler(0, angle, 0) * stateHandler.transform.forward;
                Ray scanRay = new Ray(stateHandler.transform.position, direction);

                Debug.DrawRay(scanRay.origin, scanRay.direction * tmpMaxScanDistance, Color.red, 0.1f);
            }
        }

        private void DetectAndRepulse()
        {
            for (int i = 0; i < numRays; i++)
            {
                float angle = coneAngle * i / (numRays - 1) - coneAngle / 2.0f;
                Vector3 direction = Quaternion.Euler(0, angle, 0) * stateHandler.transform.forward;
                Ray scanRay = new Ray(stateHandler.transform.position, direction);

                RaycastHit hit;
                if (Physics.Raycast(scanRay, out hit, tmpMaxScanDistance, repulseLayer))
                {
                    GameObject hitObject = hit.collider.gameObject;
                    if (hitObject != null)
                    {
                        hitObject.GetComponent<MeshRenderer>().material.color = color;
                    }
                }
            }

            tmpMaxScanDistance = 0;

        }

        public override void ExitState()
        {
            DetectAndRepulse();
        }
    }
}
