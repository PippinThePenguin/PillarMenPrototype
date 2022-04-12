using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class testScript : MonoBehaviour
{
    // Start is called before the first frame update
    Controls pig;
    public NavMeshAgent Agent;
    public Transform Destination;
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
        
        if (Input.touchCount > 0)
        {
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
            Debug.Log(Agent.remainingDistance);
            Agent.SetDestination(Destination.position);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Piggy();
    }
}
