using UnityEngine;

public class EnemyAttackPoints : MonoBehaviour
{
    [SerializeField] private Transform[] points;

    public Transform[] nearPoints { get { return points; } private set { points = value; } }


    private void OnEnable() => EventManager.Scripts.EnemyAttackPoints += () => this;
    private void OnDisable() => EventManager.Scripts.EnemyAttackPoints -= () => this;

}
