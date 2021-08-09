using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoidance : MonoBehaviour
{
    [SerializeField] private float avoidanceRange;
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * avoidanceRange);
        Gizmos.DrawRay(transform.position, (transform.forward + transform.right).normalized * avoidanceRange);
        Gizmos.DrawRay(transform.position, (transform.forward - transform.right).normalized * avoidanceRange);
        Gizmos.DrawRay(transform.position, ((transform.forward * 2) + transform.right).normalized * avoidanceRange);
        Gizmos.DrawRay(transform.position, ((transform.forward * 2) - transform.right).normalized * avoidanceRange);
    }
}
