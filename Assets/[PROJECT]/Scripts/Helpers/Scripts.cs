using UnityEngine;

namespace Helpers
{
    public static class Scripts
    {
        private static InputPool _inputPool;
        public static InputPool InputPool() { return _inputPool ? _inputPool : _inputPool = EventManager.Scripts.InputPool?.Invoke(); }

        private static PoolManager _poolManager;
        public static PoolManager PoolManager() { return _poolManager ? _poolManager : _poolManager = EventManager.Scripts.PoolManager?.Invoke(); }

        private static PatrolPoint _patrolPoint;
        public static PatrolPoint PatrolPoint() { return _patrolPoint ? _patrolPoint : _patrolPoint = EventManager.Scripts.PatrolPoint?.Invoke(); }

        private static CharacterBehaviourStateHandler _playerBehaviourStateHandler;
        public static CharacterBehaviourStateHandler PlayerBehaviourStateHandler() { return _playerBehaviourStateHandler ? _playerBehaviourStateHandler : _playerBehaviourStateHandler = EventManager.Scripts.PlayerBehaviourStateHandler?.Invoke(); }

        private static EnemyAttackPoints _enemyAttackPoints;
        public static EnemyAttackPoints EnemyAttackPoints() { return _enemyAttackPoints ? _enemyAttackPoints : _enemyAttackPoints = EventManager.Scripts.EnemyAttackPoints?.Invoke(); }

    }

}