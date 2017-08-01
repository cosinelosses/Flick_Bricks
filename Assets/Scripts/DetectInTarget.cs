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
    public void OnTriggerEnter(Collider col)
    {       
        // successfully throught the ring 
        if(col.tag == "target_box")
        {
<<<<<<< HEAD
            print("That's in! Destroying the brick");

            // destroy the current brick
            GameObject brickToDestroy = GameObject.FindGameObjectWithTag("Brick");
            Destroy(brickToDestroy);

            // add to score 
            
        }        
    }
=======
            print("That's in! ");
            Destroy(GameObject.FindWithTag("Brick"));
        }
    }    
>>>>>>> CalculatedFlick
}
