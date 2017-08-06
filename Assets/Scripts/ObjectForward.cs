using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForward : MonoBehaviour {

    public float ForwardForce; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(ForwardForce, 0, 0));
    }
}
