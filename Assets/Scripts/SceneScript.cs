using UnityEngine;

namespace PillarmanNamespace {
  public class SceneScript : MonoBehaviour {
    public Transform WayPoint;
    public Vector3 MiddlePoint;
    public bool IsEmpty = false;
    [SerializeField] private Transform _enemiesParent;
    [SerializeField] private int _enemiesCount;

    private void Start() {
      CountThem();
    }
    private void CountThem() {
      _enemiesCount = 0;
      if (_enemiesParent != null) {
        _enemiesCount = _enemiesParent.childCount;             
      }       
      CheckForEmpty();
      CalculateMiddle(gameObject);
    }
    private void CalculateMiddle(GameObject obj) {
      if (!IsEmpty) {
        Vector3 sum = new Vector3();
        foreach (Transform enemy in _enemiesParent) {
          if (enemy.GetComponent<EnemyScript>().Alive) {
            sum += enemy.position;
          }           
        }          
        sum = sum / _enemiesCount;
        MiddlePoint = sum;
      } else {
        MiddlePoint = Vector3.zero;
      }      
    }
    public void GotOne(GameObject obj) {
      _enemiesCount--;
      CheckForEmpty();
      CalculateMiddle(obj);
    }
    private void CheckForEmpty() {
      if (_enemiesCount <= 0) {
        IsEmpty = true;
      } else {
        IsEmpty = false;
      }        
    }
  }
}
  
