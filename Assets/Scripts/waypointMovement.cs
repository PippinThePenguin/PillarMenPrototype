using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class waypointMovement : MonoBehaviour
{
    [SerializeField] private List<SceneScript> wayPoints = new List<SceneScript>();
    [SerializeField] public SceneScript currentPoint;
    [SerializeField] private NavMeshAgent player;
    private Queue<SceneScript> levelPath;
    [SerializeField] private Animator animator;
    void Start()
    {
        levelPath = new Queue<SceneScript>();
        CreatePath();
        currentPoint = levelPath.Dequeue();
        EnemyScript.EnemyDied += CheckForMove;

    }
    void Update()
    {
        if (player.remainingDistance == 0)
            animator.SetBool("start_walking", false);
    }

    private void CreatePath()
    {
        foreach (SceneScript elem in wayPoints)
        {
            levelPath.Enqueue(elem);
        }
    }
    public void CheckForMove(GameObject obj)
    {
        if (currentPoint.IsEmpty)
        {
            MoveToNextPoint();
        }
    }

    private void MoveToNextPoint()
    {
        if (levelPath.Count == 0)
        {
            SceneManager.LoadScene("1Prototype");
        }
        else
        {
            currentPoint = levelPath.Dequeue();
            player.SetDestination(currentPoint.WayPoint.position);
            animator.SetBool("start_walking", true);
            CheckForMove(gameObject);
        }
    }


    private void HandleTap()
    {
        if ((Input.touchCount > 0) && (player.remainingDistance == 0))
        {
            MoveToNextPoint();
        }
    }
}
