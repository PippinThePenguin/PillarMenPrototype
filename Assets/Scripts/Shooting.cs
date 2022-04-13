using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool canShoot = true;
    public Transform start;
    public Pooler pool;
    public InputEvents Controller;
    void Start()
    {
        InputEvents.OnClickEvent += TapHandler;        
    }
    private void Shoot(Vector3 point)
    {
        pool.GetNextBullet(point, start.position);        
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
