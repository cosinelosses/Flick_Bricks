using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExistenceManager : MonoBehaviour {

    public Vector3 cutoffLevel;
    public GameObject prefabBrick;
    public GameObject platform;    

    private Vector3 platformCurrentPosition;

    private GameObject currentBrick; 

	// Use this for initialization
	void Start () {
        // spawn the first brick at start 
        // Instantiate(prefabBrick, )

        // get initial coordinates of platform and create new
        platformCurrentPosition = new Vector3(platform.transform.position.x, platform.transform.position.y,
            platform.transform.position.z);
        currentBrick = (GameObject)Instantiate(prefabBrick);
    }
	
	// Update is called once per frame
	void Update () {
     
       try
        {
            if (currentBrick.transform.position.y < cutoffLevel.y)
            {
                // destroy the old brick
                Destroy(currentBrick);

                platformCurrentPosition = new Vector3(platform.transform.position.x, platform.transform.position.y,
                    platform.transform.position.z);
                // create a new one on the current location of platforms surface
                // currentBrick = (GameObject)Instantiate(prefabBrick, platformCurrentPosition, transform.rotation);
                currentBrick = (GameObject)Instantiate(prefabBrick, platformCurrentPosition, transform.rotation);
            }
        }
        catch (Exception)
        {
            //print("The brick being referenced was destroyed");
        }
	}

    private void FixedUpdate()
    {
        
        //print(platformCurrentPosition);
    }

    /*
   private Vector3 getCooridinatesOfPlatform()
    {
        
        Vector3 coordinatesCenter;

        coordinatesCenter.x = 

        return coordinatesCenter; 
    }

    */
}
