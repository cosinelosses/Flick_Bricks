using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepBrickOnPlatform : MonoBehaviour {

    public bool on_platform;
    private GameObject platform; 

    private Rigidbody rb;

    private float forward_force; 

	// Use this for initialization
	void Start () {
        platform = GameObject.FindGameObjectWithTag("platform");
        rb = this.GetComponent<Rigidbody>();
        forward_force = platform.GetComponent<MainController>().ForwardForce;
        rb.AddForce(new Vector3(forward_force - 10, 0, 0));
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    // Physics 
    private void FixedUpdate()
    {        
        // keep on platform if on platform
        if (on_platform)
        {
            // lock sideways motion and rotation (unset these on flick) 
            rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;

            //this.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y + 2.0f, 0);  // this line breaks it 
        }


        //rb.AddForce(new Vector3(forward_force, 0, 0)); 
    }
}
