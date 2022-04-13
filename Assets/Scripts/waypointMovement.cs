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
    [SerializeField] private Queue<SceneScript> levelPath;
    [SerializeField] private Animator animator;
    void Awake()
    {
        levelPath = new Queue<SceneScript>();
        CreatePath();


    }
    private void Start()
    {
        currentPoint = levelPath.Dequeue();
        player.transform.position = currentPoint.WayPoint.position;
        EnemyScript.EnemyDied += CheckForMove;
    }
    void Update()
    {
        if (player.remainingDistance == 0)
        {
            animator.SetBool("start_walking", false);
            if (levelPath.Count == 0)
                SceneManager.LoadScene("Location");
        }                                    
        else
            animator.SetBool("start_walking", true);
    }

    private void CreatePath()
    {
        foreach (SceneScript elem in wayPoints)
        {
            Debug.Log("pig");
            Debug.Log(levelPath.Count);
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
        if (levelPath.Count != 0)
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
