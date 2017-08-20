using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour {

    public float TimeLaunched;
    private float time; 

	// Use this for initialization
	void Start () {
        time = 0; 
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime; 
	}
}
