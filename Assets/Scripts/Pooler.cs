using System.Collections.Generic;
using UnityEngine;

namespace PillarmanNamespace {
  public class Pooler : MonoBehaviour {
    public class Projectile {
      public GameObject Obj;
      public Rigidbody Rb;
      public Transform Transform;
      public Projectile(GameObject o, Rigidbody r, Transform t) {
        Obj = o;
        Rb = r;
        Transform = t;
        Obj.SetActive(false);
      }
      public void Throw(Vector3 start, Vector3 finish, float velocity) {
        Vector3 direction = (finish - start).normalized;
        Obj.SetActive(false);
        Transform.position = start;
        Transform.LookAt(finish);
        Obj.SetActive(true);
        Rb.velocity = direction * velocity;
      }
    }
    [System.Serializable]
    public class Pool {
      public GameObject Prefab;
      public int Size;
    }
    public Queue<Projectile> BulletQueue;
    [SerializeField] private Pool _bulletPool;
    [SerializeField] private float _speed;

    private void Awake() {
      BulletQueue = new Queue<Projectile>();
      for (int i = 0; i < _bulletPool.Size; i++) {
        GameObject obj = Instantiate(_bulletPool.Prefab);
        obj.transform.SetParent(transform);
        Projectile proj = new Projectile(obj, obj.GetComponent<Rigidbody>(), obj.transform);
        BulletQueue.Enqueue(proj);
      }
    }
    public void GetNextBullet(Vector3 point, Vector3 positon) {
      Projectile currentProj = BulletQueue.Dequeue();
      currentProj.Throw(positon, point, _speed);
      BulletQueue.Enqueue(currentProj);
    }
  }

}
