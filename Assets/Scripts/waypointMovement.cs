using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace PillarmanNamespace {
  public class waypointMovement : MonoBehaviour {
    public SceneScript CurrentPoint;
    [SerializeField] private List<SceneScript> _wayPoints = new List<SceneScript>();
    [SerializeField] private NavMeshAgent _player;
    [SerializeField] private Queue<SceneScript> _levelPath;
    [SerializeField] private Animator _animator;

    private void Awake() {
      CreatePath();
    }
    private void Start() {
      CurrentPoint = _levelPath.Dequeue();
      _player.transform.position = CurrentPoint.WayPoint.position;
      EnemyScript.EnemyDied += CheckForMove;
    }
    private void Update() {
      if (_player.remainingDistance == 0) {
        _animator.SetBool("start_walking", false);
        if (_levelPath.Count == 0) {
          SceneManager.LoadScene("Location");
        }         
      } else {
        _animator.SetBool("start_walking", true);
      }       
    }
    public void CheckForMove() {
      if (CurrentPoint.IsEmpty) {
        MoveToNextPoint();
      }
    }
    private void CreatePath() {
      _levelPath = new Queue<SceneScript>();
      foreach (SceneScript elem in _wayPoints) {
        _levelPath.Enqueue(elem);
      }        
    }   
    private void MoveToNextPoint() {
      if (_levelPath.Count != 0) {
        CurrentPoint = _levelPath.Dequeue();
        _player.SetDestination(CurrentPoint.WayPoint.position);
        _animator.SetBool("start_walking", true);
        CheckForMove();
      }
    }
  }
}
  
