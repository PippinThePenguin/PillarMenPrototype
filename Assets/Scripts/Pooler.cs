using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public Pool BulletPool;
    public Queue<GameObject> BulletQueue;
    [SerializeField] private float speed;


    private void Awake()
    {
        BulletQueue = new Queue<GameObject>();
        for (int i = 0; i < BulletPool.size; i++)
        {
            GameObject obj = Instantiate(BulletPool.prefab);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            BulletQueue.Enqueue(obj);
        }
    }
    public GameObject GetNextBullet(Vector3 point, Vector3 positon)
    {
        GameObject currentObj = BulletQueue.Dequeue();
        Vector3 direction = (point - positon).normalized;
        currentObj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        currentObj.SetActive(false);
        currentObj.transform.position = positon;
        currentObj.transform.LookAt(point);
        BulletQueue.Enqueue(currentObj);
        currentObj.SetActive(true);
        currentObj.GetComponent<Rigidbody>().AddForce(direction * speed);
        return currentObj;
    }
}
