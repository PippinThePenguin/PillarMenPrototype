using UnityEngine;

namespace PillarmanNamespace {
  public class Shooting : MonoBehaviour {
    [SerializeField] private Transform _start;
    [SerializeField] private Pooler _pool;
    [SerializeField] private LayerMask _layers;
    void Start() {
      InputEvents.OnClickEvent += TapHandler;
    }
    private void Shoot(Vector3 point) {
      _pool.GetNextBullet(point, _start.position);
    }

    private void TapHandler(Touch touch) {
      Ray ray = Camera.main.ScreenPointToRay(touch.position);
      RaycastHit hit;
      if (Physics.Raycast(ray, out hit, _layers)) {
        Shoot(hit.point);
      }        
    }
  }
}

