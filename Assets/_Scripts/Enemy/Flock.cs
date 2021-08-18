using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [SerializeField] private FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    [SerializeField] private FlockBehaviour behavior;

    [Range(10, 500)]
    [SerializeField] private int startingCount = 250;
    const float AgentDensity = 0.08f;

    [Range(1f, 100f)]
    [SerializeField] private float driveFactor = 10f;
    [Range(1f, 100f)]
    [SerializeField] private float maxSpeed = 5f;

    [Range(1f, 10f)]
    [SerializeField] private float neighborRadius = 1.5f;

    [Range(0f, 1f)]
    [SerializeField] private float avoidanceRadiusMultiplier = 0.5f;


    private float _squareMaxSpeed;
    private float _squareNeighborRadius;
    private float _squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return _squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        _squareMaxSpeed = maxSpeed * maxSpeed;
        _squareNeighborRadius = neighborRadius * neighborRadius;
        _squareAvoidanceRadius = _squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(agentPrefab, Random.insideUnitCircle * startingCount * AgentDensity, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);
            newAgent.name = "Agent " + i;
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
