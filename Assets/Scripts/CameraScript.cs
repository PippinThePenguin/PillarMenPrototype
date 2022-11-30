using UnityEngine;

namespace PillarmanNamespace {
  public class CameraScript : MonoBehaviour {
    [SerializeField] private waypointMovement _pathFinder;
    [SerializeField] private Vector3 _viewPoint;

    private void Start() {
      EnemyScript.EnemyDied += CameraCheck;
    }
    private void Update() {
      CameraCheck();
    }
    private void CameraCheck() {
      if (_pathFinder.CurrentPoint.MiddlePoint != Vector3.zero) {
        _viewPoint = _pathFinder.CurrentPoint.MiddlePoint;
      }        
      transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,
        (_viewPoint - transform.position).normalized, 0.01f, 0f));
    }
  }
}
