using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour {


    private GameObject ref_platform;
    private float platform_pos_z; 

	// Use this for initialization
	void Start () {
        ref_platform = GameObject.FindWithTag("platform");
        platform_pos_z = ref_platform.transform.position.z; 
	}
	
	// Update is called once per frame
	void Update () {
        platform_pos_z = ref_platform.transform.position.z; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        // bad code 
        //GameObject brickToShatter = GameObject.FindGameObjectsWithTag("Brick")[0];

        // only do if away from the platform
        if (this.transform.position.z > platform_pos_z + 5.0f)
        {

            //this.gameObject.AddComponent<TriangleExplosion>();

            //StartCoroutine(gameObject.GetComponent<TriangleExplosion>().SplitMesh(true));
        }        
    }
}
