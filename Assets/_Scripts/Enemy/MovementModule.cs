using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementModule : MonoBehaviour, IMovementModule
{  
    private List<Vector3> _points;

    private NavMeshAgent _navMeshAgent;
    private DistanceCalculator _distanceCalculator;

    private int _curPointIndex = 0;
    private bool _isTheLastPoint = false;
    private bool _isMoving = false;

    private void Start()
    {
        _distanceCalculator = GetComponent<DistanceCalculator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _points = _distanceCalculator.GetRandomPointList();
    }


    private void Update()
    {
        CheckTargetReached();
        if (_isMoving)
        {
            return;
        }
        MoveToPoint((_points[_curPointIndex]));
        _isMoving = true;       
    }

    private void CheckTargetReached()
    {
        Debug.Log(_points[_curPointIndex]);
        if (!_isTheLastPoint && Vector3.Distance(transform.position, _points[_curPointIndex]) <= 1.5f)
        {
            _curPointIndex++;
            _isMoving = false;
            if (_curPointIndex == _points.Count) 
            {
                _isTheLastPoint = true; 
            }
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        _navMeshAgent.destination = _points[_curPointIndex];
    }

}
