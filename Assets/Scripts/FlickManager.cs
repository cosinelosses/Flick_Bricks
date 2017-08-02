using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickManager : MonoBehaviour {

    // make calculated private
    public float thrust_up; 
    public float thrust_forward; 

    public Rigidbody rb;

    // premade

    public float minSwipeLength = 200f;

    Vector2 firstPressPos;
    Vector2 secondPressPos;

    Vector2 mousePosition; 
    List<Vector2> points = new List<Vector2>();
    Vector3 thrust; 


    bool shouldAppend; 

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        shouldAppend = false;
	}

    // Update is called once per frame            
	void Update () {

        if (Input.GetKeyDown(KeyCode.Y))
        {                        
            rb.AddForce(transform.up * thrust_up);
            rb.AddForce(transform.forward * thrust_forward);            
        }

        if (Input.GetMouseButtonDown(0))
        {
            // start input            
            shouldAppend = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            // stop getting input
            shouldAppend = false;

            // calculate thrust  
            if (points.Count > 0)
            {
                thrust = calculateFlickThrust(points, 3);

                // apply thrust 
                rb.AddForce(thrust);
                // after calculating thrust 
                points.Clear();
            }
        }
    }

    private void FixedUpdate()
    {       
        if (shouldAppend)
        {
            mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            // print(mousePosition);

            // print(points[0].x);

            // add current mouse position
            points.Add(mousePosition);
        }
    }

    void ApplyForce(Rigidbody body)
    {
        Vector3 direction = body.transform.position - transform.position;
        body.AddForceAtPosition(direction.normalized, transform.position);               
    }

    private Vector3 calculateFlickThrust(List<Vector2> points, float thrustScaleVertical = 3, float thrustScaleForward = 70, float forwardConstant = 20)
    {
        Vector3 thrustVector = new Vector3();

        float comp_forward; 
        float comp_vert;
        float comp_horizontal;

        for (int i = 0; i < points.Count; i++)
        {
            print("Point in list: " + points[i].x + " " + points[i].y); 
        }

        // vertical component
        comp_vert = points[points.Count - 1].y - points[0].y;
            comp_vert *= thrustScaleVertical;

        // horizontal component
        comp_horizontal = points[points.Count - 1].x - points[0].x; // z is horizonatal component relative to the world, x is horizontal relative to the screen (for mouse input)         
            comp_horizontal *= 2; 
        // forward component
        comp_forward = forwardConstant * thrustScaleForward;

        if (comp_forward < 0)
        {
            // make positive only
            comp_forward *= -1.0f; 
        }                

        thrustVector = new Vector3(comp_horizontal, comp_vert, comp_forward);
        print("Thurst vector: " + thrustVector); 

        return thrustVector;
    }
}
