using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInTarget : MonoBehaviour {

    // use the platform to reference its script
    private GameObject ref_platform;

    private int score_increment; 

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
            print("That's in! Destroying the brick");

            // destroy the current brick
            GameObject brickToDestroy = GameObject.FindGameObjectWithTag("Brick");
            Destroy(brickToDestroy);

            ref_platform = GameObject.FindWithTag("platform");
            ref_platform.GetComponent<BrickExistenceManager>().score += score_increment;

            print("score is: " + ref_platform.GetComponent<BrickExistenceManager>().score); 

            // add to score 
            
        }        
    }     
}
