using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawnManager : MonoBehaviour {

    public GameObject BrickPrefab;
    public float maxBricks;          
    private GameObject[] bricks;
    private GameObject platform;
    public float spawn_space; // space added to x_max for brick spawn time decision
    float rad;                     
    float x_max;
    float x_min;
    float diff;    

    // Use this for initialization
    void Start () {        
        platform = GameObject.FindGameObjectWithTag("platform");        
	}

    private void FixedUpdate()
    {                    
        bricks = GameObject.FindGameObjectsWithTag("brick");  // update
        calculatePlatformRange();

        Vector3 platform_position = new Vector3(platform.transform.position.x, platform.transform.position.y,
            platform.transform.position.z);

        
        if (bricks.Length == 0)
        {
            spawnNewBrick(platform_position);            
        }

        bricks = GameObject.FindGameObjectsWithTag("brick"); // update

        bool brickOnPlatform = true;

        foreach (GameObject ob in bricks)
        {
            float brick_pos_x = ob.transform.position.x;

            print("x_min: " + x_min);
            print("x_max: " + x_max);
            print("brick_pos_x " + brick_pos_x);

            if (brick_pos_x > x_min && brick_pos_x < x_max + spawn_space)
            {
                print("brick is on the platform");
                brickOnPlatform = true; 
            }
            else
            {
                print("brick is not on the platform");
                brickOnPlatform = false;
            }
        }  
        
        if(!brickOnPlatform)
        {
            print("SPAWNING NEW");
            spawnNewBrick(platform_position); 
        }
    }

    private void spawnNewBrick(Vector3 platform_position)
    {                
        float offset_x = 0;
        float offset_y = 2.0f;
        float offset_z = 0;

        Vector3 spawn_position = new Vector3(platform_position.x + offset_x, platform_position.y + offset_y,
            platform_position.z + offset_z);
        GameObject new_brick = Instantiate(BrickPrefab, spawn_position, Quaternion.identity);
    }

    

    private void calculatePlatformRange()
    {
        Renderer rend = platform.GetComponent<Renderer>();        

        float x_extent = rend.bounds.extents.x;
        float y_extent = rend.bounds.extents.y;         

        rad = rend.bounds.extents.magnitude;   
 
        x_max = platform.transform.position.x + x_extent;
        x_min = platform.transform.position.x - x_extent;

        diff = x_max - x_min;
    }    
}
