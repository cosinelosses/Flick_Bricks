using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickManager : MonoBehaviour
{
    // rb to flick
    public Rigidbody rb;

    // multipliers for thurst calculation 
    public float thrustScaleVertical = 3;
    public float thrustScaleForward = 4;
    public float horizontalScale = 2;
    public int forwardConstant = 300;

    // limits 
    public float thrustMax = 1000;
    public int minSwipeLength = 200;

    // rotational forces (can add other axes later) 
    public float x_rotation = 30;

    // mouse inputs
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 mousePosition;
    List<Vector2> points = new List<Vector2>();
    Vector3 thrust;

    bool shouldTrack;
    public float flick_delay;

    // current time ; 
    private float time;
    
    // Use this for initialization
    void Start()
    {
        time = 0; 
    }

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame            
    void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            points.Add(mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            
            thrust = calculateFlickThrust();

            
            rb.AddForce(thrust);
            createRotation();
            
            GameObject platform = GameObject.FindGameObjectWithTag("platform");
           // platform.GetComponent<BrickSpawnManager>().time_last_brick = time;

            

            // reset mouse tracker 
            points.Clear();

            // remove forward translation comp 
            Destroy(this.GetComponent<ForwardBehavior>()); 

            // remove flick manger from this brick 
            Destroy(this.GetComponent<FlickManager>());
        }        
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime; 
    }

    void ApplyForce(Rigidbody body)
    {
        Vector3 direction = body.transform.position - transform.position;
        body.AddForceAtPosition(direction.normalized, transform.position);
    }

    private Vector3 calculateFlickThrust()
    {
        Vector3 thrustVector = new Vector3();

        float comp_vert;
        float comp_horizontal;
        float comp_forward; 

        // vertical component
        comp_vert = points[points.Count - 1].y - points[0].y;
        comp_vert *= thrustScaleVertical;

        // horizontal component
        comp_horizontal = points[points.Count - 1].x - points[0].x; // z is horizonatal component relative to the world, x is horizontal relative to the screen (for mouse input)         
        comp_horizontal *= horizontalScale;

        // forward component
        comp_forward = forwardConstant * thrustScaleForward;

        thrustVector = new Vector3(comp_forward, comp_vert, comp_horizontal);

        return thrustVector;
    }

    private Vector3 createRotation()
    {
        Vector3 rotation = new Vector3();

        rb.AddForceAtPosition(new Vector3(0, 100, 0), new Vector3(0.2f, 0.2f, 0.2f));

        return rotation;
    }
}