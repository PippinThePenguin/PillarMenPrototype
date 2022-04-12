using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool canShoot = true;
    public Transform start;
    //public GameObject bullet;
    public Pooler pool;
    public InputEvents Controller;
    //[SerializeField] float speed = 60;
    // Start is called before the first frame update
    void Start()
    {
        InputEvents.OnClickEvent += TapHandler;
    }

    // Update is called once per frame
    void Update()
    {
        //WhereToShoot();
    }

    public void WhereToShoot()
    {
        if ((Input.touchCount > 0) && canShoot)
        {
            canShoot = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.point);
                Shoot(hit.point);
            }
        }
        else if (Input.touchCount == 0)
        {
            canShoot = true;
        }
    }

    private void Shoot(Vector3 point)
    {
        GameObject newbullet = pool.GetNextBullet(point, start.position);
        //GameObject newbullet = Instantiate(bullet);
        //newbullet.transform.position = start.position;
        //newbullet.transform.LookAt(point);
        //newbullet.SetActive(true);
        //Vector3 direction = (point - start.position).normalized;
        //newbullet.GetComponent<Rigidbody>().AddForce(direction*speed);
        
    }

    private void TapHandler(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Shoot(hit.point);
        }
    }
}
