using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistanceCalculator : MonoBehaviour
{
    [SerializeField] private APointProvider pointProvider;
    [SerializeField] private int randomPointRadius;

    private List<Transform> _points;
    

    private void Awake()
    {
        _points = pointProvider.GetPointList();   
    }
    
    public List<Vector3> GetRandomPath()
    {
        List<Vector3> _randomPoints = new List<Vector3>();

        foreach (Transform points in _points)
        {          
            _randomPoints.Add(RandomPointInsideSphere(points.position));
        }
        CalculateTotalDistance(_randomPoints);
        return new List<Vector3>(_randomPoints);
    }

    private Vector3 RandomPointInsideSphere(Vector3 point)
    {
        Vector2 randomPointTemp = Random.insideUnitCircle;
        return point + new Vector3(randomPointTemp.x, 0f, randomPointTemp.y) * randomPointRadius;
    }

    private void CalculateTotalDistance(List<Vector3> randomPoints)
    {
        float totalDistance = 0f;
        for (int i = 0; i < randomPoints.Count - 1; i++)
        {
            
            totalDistance += Vector3.Distance(randomPoints[i], randomPoints[i + 1]);
        }
    }

    private void PercentDistanceCompleted()
    {

    }
}
