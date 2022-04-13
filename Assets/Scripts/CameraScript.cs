using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private waypointMovement pathFinder;
    [SerializeField] private Vector3 viewPoint;
    void Start()
    {
        EnemyScript.EnemyDied += CameraCheck;
    }
    void Update()
    {
        CameraCheck();
    }
    private void CameraCheck()
    {
        if (pathFinder.currentPoint.MiddlePoint != Vector3.zero)
            viewPoint = pathFinder.currentPoint.MiddlePoint;
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, (viewPoint - transform.position).normalized, 0.01f, 0f));
    }

}
