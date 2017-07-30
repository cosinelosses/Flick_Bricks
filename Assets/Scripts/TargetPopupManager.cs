using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPopupManager : MonoBehaviour {

    // target prefab to use 
    public GameObject target_prefab;

    // platform for reference
    public GameObject ref_platform;

    // forward speed of the ring can also be rand set (low variance) 
    public float target_forward_speed; 
    
    // positions set by randoms     
    private float distance_z;
    private float distance_x;
    private float distance_y;

    // rotation set rand (enum on 90s?) 
    // var

    // size set by random
    private Vector3 res_scale;
    private float res_scale_value; 

    // visible props
    public float visible_duration;
    private double time;
    private double time2; 

    // current target
    private GameObject targ_ring;    

	// Use this for initialization
	void Start () {
        // initialize time
        time = 0;        

        // gen 4 rands for x, y, z, and scale
        setRandInts(); 

        // spawn initial ring
        targ_ring = (GameObject)Instantiate(target_prefab, new Vector3() + new Vector3(0,
                distance_y, distance_z), transform.rotation);        
    }
	
	// Update is called once per frame
	void Update () {
        // move the ring at same (will be less) rate as platform
        targ_ring.transform.Translate(Vector3.forward * target_forward_speed * Time.deltaTime, Space.World);
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if(Math.Round(time, 0) > visible_duration)
        {
            // destroy existing 
            Destroy(targ_ring);

            setRandInts();

            print("distance_z is now: " + distance_z + " distance_x is now: " + distance_x);

            // create new
            targ_ring = (GameObject)Instantiate(target_prefab, new Vector3(ref_platform.transform.position.x,
                ref_platform.transform.position.y, ref_platform.transform.position.z) +
                new Vector3(distance_x, distance_y, distance_z), transform.rotation); 

            // set scale 
            targ_ring.transform.localScale = new Vector3(res_scale_value, res_scale_value, res_scale_value);
            print("current res_scale_value is: " + res_scale_value); 

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

    private void setRandInts()
    {
        distance_z = genRandNum(35, 150);
        distance_y = genRandNum(0, 20);
        distance_x = genRandNum(-15, 15);

        res_scale_value = genRandNum(1, 12); // make this biased towards 2 (original scale) 
    }
}
