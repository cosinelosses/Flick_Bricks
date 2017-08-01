using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // sends trigger events 
    private void OnTriggerEnter(Collider col)
    {
        // successfully throught the ring 
        if(col.tag == "target_box")
        {
            print("That's in! ");
            Destroy(GameObject.FindWithTag("Brick"));
        }
    }    
}
