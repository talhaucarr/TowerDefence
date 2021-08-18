using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoidance : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float avoidanceRange;

    [SerializeField] private float targetVelocity = 10.0f;
    [SerializeField] private int numberOfRays = 17;
    [SerializeField] private float angle = 90;

    private Vector3 _moveDir;

    private bool _isMoving = false;
    private bool IsMoving { get => _isMoving; }

    private void Update()
    {
        _moveDir = Vector3.zero;

        CheckDistanceFromPoint();

        if (!_isMoving)
        {
            return;
        }

        LookAtTarget();
        Sensors();
    }

    private void CheckDistanceFromPoint()
    {
        if (Vector3.Distance(transform.position, target.position) < .1f)
            _isMoving = false;
        else
            _isMoving = true;
    }

    private void Sensors()
    {
        for (int i = 0; i < numberOfRays; i++)
        {

            Quaternion rotation = transform.rotation;
            Quaternion rotationMod = Quaternion.AngleAxis(i / ((float)numberOfRays - 1) * angle * 2 - angle, this.transform.up);
            Vector3 direction = rotation * rotationMod * Vector3.forward;

            Ray ray = new Ray(transform.position, direction);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo, avoidanceRange))
            {
                AvoidTheObject(direction);
            }
            else
            {
                WalkTheObject();
            }

        }
        transform.position += _moveDir * Time.deltaTime;
    }

    private void AvoidTheObject(Vector3 direction)
    {
        _moveDir -= (1.0f / numberOfRays) * targetVelocity * direction;
    }

    private void WalkTheObject()
    {
        _moveDir += (1.0f / numberOfRays) * targetVelocity * (target.position - transform.position).normalized;
    }

    private void LookAtTarget()
    {
        Vector3 lookDir = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDir);
        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
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
