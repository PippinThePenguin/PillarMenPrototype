using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private waypointMovement pathFinder;
    [SerializeField] private Vector3 viewPoint;
    void Start()
    {
        EnemyScript.EnemyDied += CameraCheck;
    }

    private void CameraCheck(GameObject obj)
    {
        if (pathFinder.currentPoint.MiddlePoint != Vector3.zero)
            viewPoint = pathFinder.currentPoint.MiddlePoint;
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, (viewPoint - transform.position).normalized, 0.01f, 0f));
    }
    void Update()
    {
        CameraCheck(gameObject);
    }
}
