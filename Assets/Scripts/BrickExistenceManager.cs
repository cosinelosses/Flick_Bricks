using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExistenceManager : MonoBehaviour {

    public Vector3 cutoffLevel;
    public GameObject prefabBrick;
    public GameObject platform;

    // obj for in targ dectection
    public DetectInTarget DetectInTarget; 

<<<<<<< HEAD
    private Vector3 platformCurrentPosition;
=======
    private GameObject currentBrick;

    public string brickTag; 
>>>>>>> CalculatedFlick

    private GameObject currentBrick;
    
	// Use this for initialization
	void Start () {
        // spawn the first brick at start 
        // Instantiate(prefabBrick, )

        // get initial coordinates of platform and create new
        platformCurrentPosition = new Vector3(platform.transform.position.x, platform.transform.position.y,
            platform.transform.position.z);

<<<<<<< HEAD
        currentBrick = (GameObject)Instantiate(prefabBrick);        
=======
        currentBrick = (GameObject)Instantiate(prefabBrick);
       
>>>>>>> CalculatedFlick
    }
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
     
       try
        {
            if (currentBrick.transform.position.y < cutoffLevel.y)
            {
                // destroy the old brick
                Destroy(currentBrick);                

                // get current platform position
                platformCurrentPosition = new Vector3(platform.transform.position.x, platform.transform.position.y,
                    platform.transform.position.z);

                // create a new one on the current location of platforms surface                
                currentBrick = (GameObject)Instantiate(prefabBrick, platformCurrentPosition + new Vector3(0, 2.0f, 0),
                    transform.rotation);                
            }           
        }
        catch (Exception)
        {
            //print("The brick being referenced was destroyed");
        }

        if (GameObject.FindGameObjectWithTag("Brick") == null)
        {
            // create new brick at platform
            platformCurrentPosition = new Vector3(platform.transform.position.x, platform.transform.position.y,
                platform.transform.position.z);

            currentBrick = (GameObject)Instantiate(prefabBrick, platformCurrentPosition + new Vector3(0, 2.0f, 0),
               transform.rotation);
        }
    }

    private void FixedUpdate()
    {                   
        //print(platformCurrentPosition);
=======

       
	}

    private void FixedUpdate()
    {
        // get the platform current position 
        platformCurrentPosition = new Vector3(platform.transform.position.x, platform.transform.position.y,
            platform.transform.position.z);

        currentBrick = GameObject.FindWithTag(brickTag);

        if (currentBrick == null)
        {
            currentBrick = (GameObject)Instantiate(prefabBrick, platformCurrentPosition + new Vector3(0, 2.0f, 0),
                    transform.rotation);
        }
        
          if (currentBrick.transform.position.y < cutoffLevel.y)
          {
              // destroy the old brick
              Destroy(currentBrick);
            
              // create a new one on the current location of platforms surface              
              currentBrick = (GameObject)Instantiate(prefabBrick, platformCurrentPosition + new Vector3(0, 2.0f, 0),
                  transform.rotation);
          }                
        
        // brick is destroyed action 
        
>>>>>>> CalculatedFlick
    }
}
