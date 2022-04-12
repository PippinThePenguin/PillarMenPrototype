using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class waypointMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoints = new List<Transform>();
    // Start is called before the first frame update
    [SerializeField] private int currentPoint;
    [SerializeField] private NavMeshAgent player;

    void Start()
    {
        currentPoint = 0;
        EnemyScript.EnemyDied += MoveToNextPoint;
    }

    // Update is called once per frame
    void Update()
    {
        //HandleTap();
    }

    
    private void MoveToNextPoint(GameObject obj)
    {
        if (currentPoint != wayPoints.Count -1)
        {
            currentPoint++;
            player.SetDestination(wayPoints[currentPoint].position);
        }
        else
        {
            currentPoint = 0;
            player.SetDestination(wayPoints[currentPoint].position);
        }
    }

    private void HandleTap()
    {
        if ((Input.touchCount > 0) && (player.remainingDistance == 0))
        {
            MoveToNextPoint(gameObject);
        }
    }
}
