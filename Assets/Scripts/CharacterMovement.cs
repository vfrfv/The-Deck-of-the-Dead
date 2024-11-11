using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    private NavMeshAgent _navMesh;
    private int _pointIndex = 0;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToPoint();
        }
    }

    public void MoveToPoint()
    {
        _navMesh.SetDestination(_points[_pointIndex].position);
        _pointIndex++;
    }
}