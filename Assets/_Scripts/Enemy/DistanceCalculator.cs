using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistanceCalculator : MonoBehaviour
{
    [SerializeField] private APointProvider pointProvider;
    [SerializeField] private int randomPointRadius;

    private List<Transform> _points;
    private List<Vector3> _randomPoints = new List<Vector3>();

    private void Start()
    {
        _points = pointProvider.GetPointList();
        //_randomPoints.Add(transform.position);      
    }
    
    public List<Vector3> GetRandomPointList()
    {
        CreatePath();
        return _randomPoints;
    }

    private void CreatePath()
    {
        foreach (Transform points in _points)
        {          
            _randomPoints.Add(RandomPointInsideSphere(points.position));
        }
    }

    private Vector3 RandomPointInsideSphere(Vector3 point)
    {
        return point + Random.insideUnitSphere * randomPointRadius;
    }
}
