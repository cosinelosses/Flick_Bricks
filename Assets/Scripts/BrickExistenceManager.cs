using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExistenceManager : MonoBehaviour {

    public Vector3 cutoffLevel;
    public GameObject prefabBrick;
    public GameObject platform;

    public Vector3 startBrickLocation; 

	// Use this for initialization
	void Start () {
        // spawn the first brick at start 
        // Instantiate(prefabBrick, )
	}
	
	// Update is called once per frame
	void Update () {
		if(prefabBrick.transform.position.y < cutoffLevel.y)
        {
            Destroy(gameObject);
            // Destroy(GameObject);

            // creates new as soon as the other is destroyed -change to be create new sooner
            // location needs to be on the moving platform
            // CHANGES
            //Vector3 spawnLocation = getCooridinatesOfPlatform(); 
            //Instantiate(prefabBrick)

            // this is a useless change to test
        }
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
