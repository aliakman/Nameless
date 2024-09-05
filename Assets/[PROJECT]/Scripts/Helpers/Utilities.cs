using System.Threading.Tasks;
using UnityEngine;

namespace Helpers
{
    public static class Utilities
    {
        private static Transform _playerTransform;
        public static Transform playerTransform { get { return _playerTransform ? _playerTransform : _playerTransform = EventManager.Scripts.PlayerBehaviourStateHandler?.Invoke().transform; } }

        public static Transform GetPatrolPoint() { return EventManager.Scripts.PatrolPoint?.Invoke().GetAppripriatePoint(); }

        public static Vector3 LookAtPos(Camera _cam, Vector3 _currentPos, Vector3 _lookPos)
        {
            Ray _ray = _cam.ScreenPointToRay(_lookPos);
            Plane _plane = new Plane(Vector3.up, Vector3.up * 1.5f);
            float _rayLength;

            if (_plane.Raycast(_ray, out _rayLength))
            {
                Vector3 _pointToLook = new Vector3(_ray.GetPoint(_rayLength).x, _currentPos.y, _ray.GetPoint(_rayLength).z);
                return _pointToLook;
            }

            return Vector3.zero;
        
        }

        public static async Task WaitFrame()
        {
            var currnet = Time.frameCount;

            while (currnet == Time.frameCount)
            {
                await Task.Yield();
            }
        }

        public static void PlayAnimationClip(this Animator _animator, string _clipName)
        {
            _animator.Play(_clipName);
        }

        public static void PlayAnimationClip(this Animator _animator, string[] _clipNames)
        {
            _animator.Play(_clipNames[Random.Range(0, _clipNames.Length)]);
        }

        public static void SetAnimationTrigger(this Animator _animator, string _triggerValue)
        {
            _animator.SetTrigger(_triggerValue);
        }

        public static float GetCosAngle(Vector3 _a, Vector3 _b, Vector3 _c)
        {
            Vector3 _ba = _b - _a;
            float _cos = Vector3.Dot(_ba, _c) / Vector3.Magnitude(_ba);
            return _cos;
        }

        public static float Distance(Vector3 _a, Vector3 _b)
        {
            float _cX = _a.x - _b.x;
            float _cY = _a.y - _b.y;
            float _cZ = _a.z - _b.z;

            float _distance = Mathf.Sqrt(_cX * _cX + _cY * _cY + _cZ * _cZ);

            return _distance;
        }

        public static Vector3 GetRandomPosition(Vector3 _originPos, float _yValue, float _range)
        {
            float _xValue = Random.Range(-_range + .3f, _range - .3f) + _originPos.x;
            float _zValue = Random.Range(-_range + .3f, _range - .3f) + _originPos.z;

            if (_xValue > 20)
                _xValue = 20;
            else if(_xValue < -20)
                _xValue = -20;

            if (_zValue > 20)
                _zValue = 20;
            else if (_zValue < -20)
                _zValue = -20;

            return new Vector3(_xValue, _yValue, _zValue);
        }

    }
}
