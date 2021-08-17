using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoidance : MonoBehaviour
{
    [SerializeField] private float avoidanceRange;

    [SerializeField] private float targetVelocity = 10.0f;
    [SerializeField] private int numberOfRays = 17;
    [SerializeField] private float angle = 90;


    private void Update()
    {
        var _moveDir = Vector3.zero;
        for (int i = 0; i < numberOfRays; i++)
        {

            var rotation = this.transform.rotation;
            var rotationMod = Quaternion.AngleAxis(i / ((float)numberOfRays - 1) * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationMod * Vector3.forward;

            var ray = new Ray(this.transform.position, direction);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, avoidanceRange))
            {
                Debug.Log("true");
                _moveDir -= (1.0f / numberOfRays) * targetVelocity * direction;
            }
            else
            {
                Debug.Log("false");
                _moveDir += (1.0f / numberOfRays) * targetVelocity * direction;
            }
        }
        this.transform.position += _moveDir * Time.deltaTime;
        Debug.Log(_moveDir);

    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < numberOfRays; i++)
        {

            var rotation = this.transform.rotation;
            var rotationMod = Quaternion.AngleAxis(i / ((float)numberOfRays-1 ) * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationMod * Vector3.forward;
            Gizmos.DrawRay(this.transform.position, direction);
        }
    }
}
