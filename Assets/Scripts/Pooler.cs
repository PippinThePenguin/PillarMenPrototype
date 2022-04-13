using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public class Projectile
    {
        public GameObject obj;
        public Rigidbody rb;
        public Transform transform; 
        public Projectile(GameObject o, Rigidbody r, Transform t)
        {
            obj = o;
            rb = r;
            transform = t;
            obj.SetActive(false);
        }
        public void Throw(Vector3 start, Vector3 finish, float velocity)
        {
            Vector3 direction = (finish - start).normalized;
            obj.SetActive(false);
            transform.position = start;
            transform.LookAt(finish);
            obj.SetActive(true);
            rb.velocity = direction * velocity;
        }
    }
    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int size;
    }   
    public Queue<Projectile> BulletQueue;
    [SerializeField] private Pool BulletPool;
    [SerializeField] private float speed;

    private void Awake()
    {
        BulletQueue = new Queue<Projectile>();
        for (int i = 0; i < BulletPool.size; i++)
        {
            GameObject obj = Instantiate(BulletPool.prefab);
            obj.transform.SetParent(transform);            
            Projectile proj = new Projectile(obj, obj.GetComponent<Rigidbody>(), obj.transform);
            BulletQueue.Enqueue(proj);
        }
    }
    public void GetNextBullet(Vector3 point, Vector3 positon)
    {
        Projectile currentProj = BulletQueue.Dequeue();
        currentProj.Throw(positon, point, speed);
        BulletQueue.Enqueue(currentProj);
    }
}
