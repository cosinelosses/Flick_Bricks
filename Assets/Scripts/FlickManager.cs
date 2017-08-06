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

    Vector2 firstPressPos;
    Vector2 secondPressPos;

    Vector2 mousePosition;
    List<Vector2> points = new List<Vector2>();
    Vector3 thrust;

    //bool shouldTrack; // will be tracking the entire time the Flick Manager component is attached 
    bool canFlick;

    // Use this for initialization
    void Start()
    {        
        
    }

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame            
    void Update()
    {
        // while mouse is down, track movement
        while (Input.GetMouseButtonDown(0))
        {
            mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            points.Add(mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            //calculateFlickThrust();

            // reset tracker 
            points.Clear();

            // apply the flick

            // remove flick manger from this brick 
            Destroy(this.GetComponent<FlickManager>());
        }

    }

    private void FixedUpdate()
    {
        
    }

    void ApplyForce(Rigidbody body)
    {
        Vector3 direction = body.transform.position - transform.position;
        body.AddForceAtPosition(direction.normalized, transform.position);
    }

    private Vector3 calculateFlickThrust(float scale_forward, float scale_vertial, float scale_horizontal, int forward_constant, float thrust_max)
    {
        Vector3 thrustVector = new Vector3();
        

        return thrustVector;
    }

    private Vector3 createRotation(float x_amt, float y_amt, float z_amt)
    {
        Vector3 rotation = new Vector3();

        return rotation;
    }
}
