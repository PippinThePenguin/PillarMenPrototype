using UnityEngine;

namespace PillarmanNamespace {
  public class BulletScript : MonoBehaviour {
    [SerializeField] private float _damage = 5;

    private void OnCollisionEnter(Collision collision) {
      if (collision.gameObject.CompareTag("Enemy")) {
        EnemyScript script = collision.gameObject.GetComponent<EnemyScript>();
        if (script != null) {
          script.Health -= _damage;
        }        
      }
      gameObject.SetActive(false);
    }
  }
}
