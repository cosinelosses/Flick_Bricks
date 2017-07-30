using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPopupManager : MonoBehaviour {

    // target prefab to use 
    public GameObject target_prefab;

    // platform for reference
    public GameObject ref_platform;
    

    // set and make private
    public float distance_ahead;
    public float distance_up;

    public float visible_duration;
    private double time;

    // current target
    private GameObject targ_ring;    

	// Use this for initialization
	void Start () {
        // initialize time
        time = 0;

        // spawn initial ring
        targ_ring = (GameObject)Instantiate(target_prefab, new Vector3() + new Vector3(0,
                distance_up, distance_ahead), transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        // move the ring at same (will be less) rate as platform
        targ_ring.transform.Translate(Vector3.forward * 10 * Time.deltaTime, Space.World);
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if(Math.Round(time, 0) > visible_duration)
        {
            // destroy existing 
            Destroy(targ_ring);

            // create new
            targ_ring = (GameObject)Instantiate(target_prefab, new Vector3(ref_platform.transform.position.x,
                ref_platform.transform.position.y, ref_platform.transform.position.z) +
                new Vector3(0, distance_up, distance_ahead), transform.rotation);

            time = 0; 
        }
    }   

    private int genRandNum(int min, int max)
    {        
        System.Random randNumGen = new System.Random();
        int rand = randNumGen.Next(min, max);

        print("Random number is: " + rand);
        return rand; 
    }  
}
