using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputEvents : MonoBehaviour
{
    public static event Action<Touch> OnClickEvent;
    private delegate void UpdateDelegate();
    private UpdateDelegate updateDelegate;
    private bool newTap = true;

    private void Awake()
    {
        OnClickEvent = null;
        updateDelegate = StartGame;
    }

    private void StartGame()
    {
        if (Input.touchCount > 0)
        {            
            GetComponent<waypointMovement>().CheckForMove(gameObject);
            newTap = false;
            updateDelegate = HandleTap;
        }           
    }
    void Update()
    {
        updateDelegate();
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
