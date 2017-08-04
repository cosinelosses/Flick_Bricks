using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPopupManager : MonoBehaviour {

    // target prefab to use 
    public GameObject target_prefab;

    // platform for reference
    public GameObject ref_platform;
    public Vector3 platform_position; 

    // forward speed of the ring can also be rand set (low variance) 
    public float target_forward_speed; 
    
    // positions set by randoms     
    private float distance_z;
    private float distance_x;
    private float distance_y;

    // range values for axes
    public int xrange_min;
    public int xrange_max;
    public int yrange_min;
    public int yrange_max;
    public int zrange_min;
    public int zrange_max;

    public float res_scale_min;
    public float res_scale_max; 

    // size set by random    
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
        setRandValues(); 

        // spawn initial ring
        targ_ring = (GameObject)Instantiate(target_prefab, new Vector3() + new Vector3(0,
                distance_y, distance_z), transform.rotation);        
    }
	
	// Update is called once per frame
	void Update () {
        // move the ring at same (will be less) rate as platform
        //targ_ring.transform.Translate(Vector3.forward * target_forward_speed * Time.deltaTime, Space.World);
        targ_ring.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -2));

        if(Input.GetKeyDown(KeyCode.P))
        {
            System.Random rand = new System.Random();

            print(randomFloat(0.0, 4.0));
        }
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        //if()

        if(Math.Round(time, 0) >= visible_duration)
        {
            // destroy existing 
            Destroy(targ_ring);

            setRandValues();

            platform_position = new Vector3(ref_platform.transform.position.x, ref_platform.transform.position.y,
            ref_platform.transform.position.z);

            // create new (adds to the current platform position)
            targ_ring = (GameObject)Instantiate(target_prefab, platform_position + new Vector3(distance_x, distance_y, distance_z),
            transform.rotation); 

            // set scale 
            targ_ring.transform.localScale = new Vector3(res_scale_value, res_scale_value, res_scale_value);

            // print("current res_scale_value is: " + res_scale_value); 

            time = 0; 
        }        
    }   

    private int genRandNum(int min, int max)
    {        
        System.Random randNumGen = new System.Random();
        int rand = randNumGen.Next(min, max);

        // print("Random number is: " + rand);
        return rand; 
    }  

    private void setRandValues()
    {               
        distance_x = randomFloat(xrange_min, xrange_max);
        distance_y = randomFloat(yrange_min, yrange_max);
        distance_z = randomFloat(zrange_min, zrange_max);

        res_scale_value = randomFloat(res_scale_min, res_scale_max); 
    }

    private float randomFloat(double start, double end)
    {
        System.Random rand = new System.Random(); 

        // gen rand dec (double) 
        double randomDec = (rand.NextDouble() * Math.Abs(end - start)) + start;

        // round to tenths
        randomDec = Math.Round(randomDec, 1); 
        float returnFloat = (float)randomDec;

        return returnFloat;
    }
}
