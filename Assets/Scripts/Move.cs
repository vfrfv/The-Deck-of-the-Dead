using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    private void Start()
    {
        SetRandomDestination();
    }

    private void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 2f)
        {
            SetRandomDestination();
        }
    }

    private void SetRandomDestination()
    {
        Vector3 randomPoint = GetRandomPointOnNavMesh();
        _agent.SetDestination(randomPoint);
    }

    private Vector3 GetRandomPointOnNavMesh()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();
        int randomIndex = Random.Range(0, navMeshData.vertices.Length);
        Vector3 randomPoint = navMeshData.vertices[randomIndex];
        return randomPoint;
    }
}
