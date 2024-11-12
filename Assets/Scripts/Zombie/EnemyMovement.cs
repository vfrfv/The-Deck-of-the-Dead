using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _navMesh;
    private Enemy _enemy;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        MoveToPoint();
    }

    public void MoveToPoint()
    {
        _navMesh.SetDestination(_enemy.Target.transform.position);
    }
}
