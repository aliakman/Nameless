using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;


    private void OnEnable() => EventManager.Scripts.PatrolPoint += () => this;
    private void OnDisable() => EventManager.Scripts.PatrolPoint -= () => this;


    public Transform GetAppripriatePoint()
    {
        int _index = Random.Range(0, patrolPoints.Length);

        return patrolPoints[_index];

    }

}
