using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementModule : MonoBehaviour, IMovementModule
{  
    private List<Vector3> _points;
    private DistanceCalculator _distanceCalculator;
    private NavMeshAgent _navMeshAgent;

    private int _curPointIndex = 0;
    private bool _isTheLastPoint = false;
    private bool _isMoving = false;

    private void Start()
    {
        _distanceCalculator = GetComponent<DistanceCalculator>();
        _points = _distanceCalculator.GetRandomPath();
        _navMeshAgent = GetComponent<NavMeshAgent>();
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
        Debug.DrawLine(transform.position, _points[_curPointIndex], Color.green);
        Debug.Log(Vector3.Distance(transform.position, _points[_curPointIndex]));
        //Debug.Log(Random.insideUnitCircle * 3);
        if (!_isTheLastPoint && Vector3.Distance(transform.position, _points[_curPointIndex]) <= .44f)
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
