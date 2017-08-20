using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollector : MonoBehaviour {

    public float MinLevel;

    private GameObject[] bricks;	

    private void FixedUpdate()
    {
        bricks = GameObject.FindGameObjectsWithTag("brick");

        
        foreach (GameObject ob in bricks)
        {
            if (ob.transform.position.y < MinLevel)
            {
                Destroy(ob); 
            }
        }
    }
}
