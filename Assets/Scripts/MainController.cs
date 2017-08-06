using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

    // reference to Platform
    public GameObject Platform;
    private Rigidbody rb_platform; 
    public Vector3 PlatformPosition;
    private Vector3 brick_spawn_position; 
    // forward force
    public float ForwardForce;

    // keep camera moving 
    private GameObject camera;

    // active bricks
    private List<GameObject> bricks = new List<GameObject>();
    public GameObject brick_prefab;

    // active target rings 
    private List<GameObject> rings = new List<GameObject>();
    public GameObject ring_prefab;

    // random ranges for spawning the targets
    public float Xrange;
    public float Yrange;
    public float Zrange;

    // random values for use in script 
    private float Xvalue;
    private float Yvalue;
    private float Zvalue;

    // brick vars   
    public float FlickInterval;  
    private float time_flicked;     
    private bool can_flick;
    private Rigidbody rb_brick; 

    // time since start
    private float time;

    // Use this for initialization
    void Start () {
        
        // initalize WORLD time at zero 
        time = 0;

        // indiv brick time
        time_flicked = 0; 

        // main script is attached to the Platform 
        Platform = this.gameObject;

        // set rigidbody to platform component
        rb_platform = Platform.GetComponent<Rigidbody>();

        // lock vertical and horizontal movement 
        rb_platform.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

        // set platform moving
        GetComponent<Rigidbody>().AddForce(new Vector3(ForwardForce, 0, 0));

        // get platform position for first spawn
        PlatformPosition = new Vector3(Platform.transform.position.x, Platform.transform.position.y,
            Platform.transform.position.z);

        // spawn a brick
        spawnBrick(); 

        // enable brick flick
        can_flick = true; 

        // TimeSinceLaunched = 0; // set this individually for each brick // select from the active bricks array and sort by time launched to restrict stuff, maybe       
        camera = GameObject.FindGameObjectWithTag("MainCamera");        
       // camera.transform.SetPositionAndRotation(new Vector3(PlatformPosition.x - 5, PlatformPosition.y + 4, PlatformPosition.z), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {

        // set camera position
        // Quaternion.Euler(0, 90, 0)
        camera.transform.position = new Vector3(PlatformPosition.x - 5, PlatformPosition.y + 4.4f, PlatformPosition.z);

        // sorts bricks by time 

        if (can_flick)
        {

            
            if (Input.GetMouseButtonDown(0))
            {
                // start recording flick up

            }
            // flick 
            // record when brick was flicked 

            if (Input.GetMouseButtonUp(0))
            {
                time_flicked = time;

            }

            
        }
        
	}

    private void FixedUpdate()
    {
        // update WORLD time 
        time += Time.deltaTime;

        // update platform postion
        PlatformPosition = new Vector3(Platform.transform.position.x, Platform.transform.position.y,
            Platform.transform.position.z);
        
        // update last brick time

        // check if time > flick interval to enable the flickage
        if (time_flicked > FlickInterval)
        {
            // add the flick manager component to the brick 
        }

       // print("Brick Position: x: " + bricks[0].transform.position.x + " y: " + bricks[0].transform.position.y + " z: " + bricks[0].transform.position.z);

        generateRandoms(Xrange, Yrange, Zrange);

        //print(Xvalue + " " + Yvalue + " " + Zvalue);
    }

    // spawn a new brick at the platform 
    private void spawnBrick()
    {
        // set brick spawn position (can resuse after start) 
        brick_spawn_position = new Vector3(PlatformPosition.x, PlatformPosition.y + 3, PlatformPosition.z);

        // brick spawn
        GameObject new_brick = Instantiate(brick_prefab, brick_spawn_position, Quaternion.identity);
        new_brick.AddComponent<BrickTracker>();
        new_brick.GetComponent<BrickTracker>().TimeSinceFlicked = 0; 
        bricks.Add(new_brick);
    }

    // **HALFWAY UNCOUPLED** (make return) 
    private void generateRandoms(float x_range, float y_range, float z_range)
    {        
        // changes seed just in case x,y, z is cube equal -ensure not same twice
        Xvalue = Random.Range(x_range * -1, x_range);
        Random.InitState(System.DateTime.Now.Millisecond);
        Yvalue = Random.Range(y_range * -1, y_range);
        Random.InitState(System.DateTime.Now.Millisecond);
        Zvalue = Random.Range(z_range * -1, z_range);
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    /*
    private float getRandoms(float x_range, float y_range, float z_range)
    {

    } */
        
}
