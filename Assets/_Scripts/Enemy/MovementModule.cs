using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementModule : MonoBehaviour, IMovementModule
{
    [SerializeField] private APointProvider pointProvider;
    [SerializeField] private float moveSpeed;

    
    private List<Transform> _points;
    private NavMeshAgent _navMeshAgent;

    private int _curPointIndex = 0;
    private bool _isTheLastPoint = false; 

    private void Start()
    {
        _points = pointProvider.GetPointList();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        MoveToPoint((_points[_curPointIndex].position));
        CheckTargetReached();
    }

    private void CheckTargetReached()
    {
        if (!_isTheLastPoint && Vector3.Distance(transform.position, _points[_curPointIndex].position) < 0.1f)
        {
            _curPointIndex++;
            if (_curPointIndex == _points.Count) { _isTheLastPoint = true; }
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        _navMeshAgent.destination = point * moveSpeed * Time.deltaTime;
    }
}
