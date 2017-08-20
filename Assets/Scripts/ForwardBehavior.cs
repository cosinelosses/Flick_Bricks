using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBehavior : MonoBehaviour {

    /*
     * Apply this script on a gameobject to make it go forward! Using translate
     * 
     */

    public float ForwardSpeed;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        this.transform.Translate(new Vector3(ForwardSpeed, 0, 0) * Time.deltaTime, Space.World);
    }
}
