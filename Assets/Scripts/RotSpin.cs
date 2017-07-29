using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotSpin : MonoBehaviour {

    public Vector3 rate_const_1 = Vector3.right * 70;
    public Vector3 rate_const_2 = Vector3.up * 30;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        // rotate around the local x at 1 degree/sec

        rotateSomewhatRandomly(rate_const_1, rate_const_2); 
	}

    private void rotateSomewhatRandomly(Vector3 rate_const_1, Vector3 rate_const_2)
    {
      this.transform.Rotate(rate_const_1 * Time.deltaTime);

      // also around world Y axsi
      this.transform.Rotate(rate_const_2 * Time.deltaTime, Space.World);
    }
}
