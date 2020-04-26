using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValutControl : MonoBehaviour {

    public GameObject lightBlock; //Stores the light block object
    private Vector3 waypoint; //Stores the waypoint for the object

	// Use this for initialization
	void Start () {
		//Calculates vector position of waypoint
        waypoint = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//If the final light block is on, then open the door
		if (lightBlock.GetComponent<LightDetectCorrect>().getState())
        {
			//Translate the door up
            transform.position = Vector3.MoveTowards(transform.position, waypoint, 2 * Time.deltaTime);
        }
	}
}
