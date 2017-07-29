using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickManager : MonoBehaviour {

    public float thrust_up;
    public float thrust_forward; 
    public Rigidbody rb; 

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>(); 	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            rb.AddForce(transform.up * thrust_up);
            rb.AddForce(transform.forward * thrust_forward);
        }
    }

    void ApplyForce(Rigidbody body)
    {
        Vector3 direction = body.transform.position - transform.position;
        body.AddForceAtPosition(direction.normalized, transform.position);       
        
    }
}
