using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExistenceManager : MonoBehaviour {

    public int score; 

    public Vector3 cutoffLevel;
    public GameObject prefabBrick;
    public GameObject platform;    

    private Vector3 platformCurrentPosition;
    
    private GameObject currentBrick;

    private string brickTag;
    
    // Use this for initialization
    void Start () {        

        // set brick tag programmatically 
        brickTag = "Brick"; 

        // get initial coordinates of platform and create new
        platformCurrentPosition = new Vector3(platform.transform.position.x, platform.transform.position.y,
            platform.transform.position.z);

        // spawn the first brick at start 
        currentBrick = (GameObject)Instantiate(prefabBrick, platformCurrentPosition + new Vector3(0, 2.0f, 0),
                    transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {

       
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
        
    }
}
