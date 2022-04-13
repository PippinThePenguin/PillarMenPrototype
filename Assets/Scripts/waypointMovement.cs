using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class waypointMovement : MonoBehaviour
{
    public SceneScript currentPoint;
    [SerializeField] private List<SceneScript> wayPoints = new List<SceneScript>();    
    [SerializeField] private NavMeshAgent player;
    [SerializeField] private Queue<SceneScript> levelPath;
    [SerializeField] private Animator animator;
    void Awake()
    { 
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
        levelPath = new Queue<SceneScript>();
        foreach (SceneScript elem in wayPoints)
        {
            levelPath.Enqueue(elem);
        }
    }
    public void CheckForMove()
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
            CheckForMove();
        }
    }
}
