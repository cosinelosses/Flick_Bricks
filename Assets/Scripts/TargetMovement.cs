using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour {

    // multipliers on vectors 
    public float rotationSpeed;
    public float forwardSpeed;

    public float sideSideSpeed;

    private double time;
    private double goTime; 

	// Use this for initialization
	void Start () {
        time = 0; 	
	}
	
	// Update is called once per frame
	void Update () {
        
        // forward motion
        //this.transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

        // rotate motion 
        //this.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
        
        // side-to-side speed switches direction on every other second
        if (Math.Round(time, 0) % 2 == 0)
        {
            this.transform.Translate(Vector3.right * sideSideSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            this.transform.Translate(Vector3.left * sideSideSpeed * Time.deltaTime, Space.World);
        }

    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        
        //print(time);
    }

    private bool intervalHasPassed(float timeInterval)
    {
        bool passed = false;
      
        return passed; 
    }
}
