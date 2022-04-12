using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;


public class InputEvents : MonoBehaviour
{
    public static event Action<Touch> OnClickEvent;
    public static event Action<GameObject> EnemyDied;
    public bool newTap = true;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleTap();
    }

    private void HandleTap()
    {
        if ((Input.touchCount > 0) && newTap)
        {
            newTap = false;
            OnClickEvent?.Invoke(Input.GetTouch(0));
        }
        else if (Input.touchCount == 0)
        {
            newTap = true;
        }
    }
}
