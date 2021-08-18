using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockAgent : MonoBehaviour
{
    private CapsuleCollider _agentCollider;

    public CapsuleCollider AgentCollider { get { return _agentCollider; } }
    void Start()
    {
        _agentCollider = GetComponent<CapsuleCollider>();
    }

    public void Move(Vector3 velocity)
    {
        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;
    }
}
