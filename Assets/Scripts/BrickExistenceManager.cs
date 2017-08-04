using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExistenceManager : MonoBehaviour {

    public int score; 

    public int cutoffLevel;
    public GameObject prefabBrick;
    public GameObject platform;    

    private Vector3 platformCurrentPosition;
    
    private GameObject currentBrick;

    public string brickTag;

    //private GameObject[] activeBricks;
    private List<GameObject> activeBricks = new List<GameObject>(); // might not use

    // used for converting game ob array to list which can make additions easier
    private GameObject[] bricks;

   // private float time_since_launch;
   // private bool shouldTracktime; // time += Time.deltaTime;

    // Use this for initialization
    void Start () {            
        
        // get initial coordinates of platform and create new
        platformCurrentPosition = new Vector3(platform.transform.position.x, platform.transform.position.y,
            platform.transform.position.z);

        activeBricks.Add((GameObject)Instantiate(prefabBrick, platformCurrentPosition + new Vector3(0, 3.0f, 0),
                    transform.rotation));

        //shouldTracktime = false;
       // time_since_launch = 0; 

        Debug.Log(activeBricks); 
    
        
        // spawn the first brick at start 
        /*currentBrick = (GameObject)Instantiate(prefabBrick, platformCurrentPosition + new Vector3(0, 2.0f, 0),
                    transform.rotation);*/
    }
	
	// Update is called once per frame
	void Update () {

       
	}

    private void FixedUpdate()
    {
        // get the platform current position 
        platformCurrentPosition = new Vector3(platform.transform.position.x, platform.transform.position.y,
            platform.transform.position.z);

        /*
        if(shouldTracktime)
        {
            time_since_launch += Time.deltaTime; 
        } */

        // get all the currently existing bricks
        updateBricksList(); 

        // CONDITIONS TO SPAWN NEW BRICK

        // if there is no current index (the index might need to be dynamically set) 
        if (activeBricks.Count <= 0) // true is shouldSpawnNew
        {
            // instantiate new brick and add to the list of active bricks
            activeBricks.Add((GameObject)Instantiate(prefabBrick, platformCurrentPosition + new Vector3(0, 2.0f, 0),
                     transform.rotation));
           // shouldTracktime = true;
           // time_since_launch = 0; 
        }

        // if brick has left the platform
        // create new brick one second after last launch
       
        if(activeBricks[activeBricks.Count - 1].transform.position.z > (platformCurrentPosition.z + 3.0f)) 
        {
            activeBricks.Add((GameObject)Instantiate(prefabBrick, platformCurrentPosition + new Vector3(0, 2.0f, 0),
                         transform.rotation));
           // shouldTracktime = true;
           // time_since_launch = 0; 
        } 
        
        // CONDITIONS TO DESTROY A BRICK

                
        // check to see if any bricks are below the cutoff level
        for (int i = 0; i < activeBricks.Count; i++)
        {
            if(activeBricks[i].transform.position.y < cutoffLevel)
            {
                Destroy(activeBricks[i]);  
            }
        }

        /*
        

        currentBrick = GameObject.FindWithTag(brickTag);      // this has to change  

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
          }*/

        // brick is destroyed action        
    }    

    // refreshes the active bricks list (come back to this) 
    private void updateBricksList()
    {
        // empty the list 
        activeBricks.Clear(); 
        
        // gets all existing bricks back into the list (beware of the order), could add a time property to the bricks and sort by launch time
        GameObject[] bricks = GameObject.FindGameObjectsWithTag(brickTag); 
        
        // adds brick game objects to list
        for (int i = 0; i < bricks.Length; i++)
        {
            activeBricks.Add(bricks[i]); 
        }
        
        print("there are " + activeBricks.Count + " active now.");        
    }

    private GameObject[] sortGameObjectArray(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
           
        }


        /* 
         * int temp;
     for (int i = 0; i < freq_array.Length; i++)
            {
                for (int n = 1; n < i; n++)
                {
                    if (freq_array[n] < freq_array[i]){
                        temp = freq_array[i];
                        freq_array[i] = freq_array[n];
                        freq_array[n] = temp;
                    }
                }
            }
         * 
         **/
        return gameObjects; 
    }
}
