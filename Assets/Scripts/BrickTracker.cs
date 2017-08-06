using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehavior : MonoBehaviour {

    public float TimeSinceFlicked; 

	// Use this for initialization
	void Start () {
        
	}

    private void Awake()
    {
        TimeSinceFlicked = 0; 
    }

    // Update is called once per frame
    void Update () {
        
    }

    private void FixedUpdate()
    {
        // update time since flicked 
        TimeSinceFlicked += Time.deltaTime; 

        // put brick position here if needed
    }
}
