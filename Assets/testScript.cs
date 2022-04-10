using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testScript : MonoBehaviour
{
    // Start is called before the first frame update
    Controls pig; 
    void Start()
    {
        pig = new Controls();
        pig.MainAM.Tap.performed += _ => Debug.Log("Tap!!");
        pig.MainAM.Enable();
    }
    public void Pig()
    {
        Debug.Log("Another tap");
    }
    public void Piggy()
    {
        
        if (Input.GetTouch(0).position != null)
        {
            Debug.Log(Input.GetTouch(0).position);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Piggy();
    }
}
