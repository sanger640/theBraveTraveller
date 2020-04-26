using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    
    public int leftBoundary; //Stores left boundary for object
    public int rightBoundary; //Stores right boundary for object

    private Vector3 leftWaypoint; //Stores the left waypoint for object to reach
    private Vector3 rightWaypoint; //Stores the right waypoint for object to reach
    private Vector3 thisPos; //Stores the position of this object
    private bool forward; //Stores whether the object is moving forward

    // Use this for initialization
    void Start () {
		//Calculates vector position of left waypoint
        leftWaypoint = new Vector3(transform.position.x - leftBoundary, transform.position.y, transform.position.z);
		//Calculates vector position of right waypoint
        rightWaypoint = new Vector3(transform.position.x + rightBoundary, transform.position.y, transform.position.z);
		forward = true; //Object initially facing forward
    }
	
	// Update is called once per frame
	void Update () {
        thisPos = transform.position; //Gets position of this object

		//If object has reached left waypoint, turn around and head towards right waypoint
        if (isClose(thisPos, leftWaypoint) && !forward) {
			forward = true;
			transform.RotateAround (transform.position, transform.up, 180f);
		}
		//If object has reached right waypoint, turn around and head towards left waypoint
        if (isClose(thisPos, rightWaypoint) && forward) {
			forward = false;
			transform.RotateAround (transform.position, transform.up, 180f);
		}

		//Moves the object towards the desired waypoint depending on the way it is facing
        if (forward) transform.position = Vector3.MoveTowards(thisPos, rightWaypoint, Time.deltaTime);
        else transform.position = Vector3.MoveTowards(thisPos, leftWaypoint, Time.deltaTime);
    }

    //Checks to see if two 3D coordinates are close enough to each other
    public bool isClose(Vector3 posA, Vector3 posB)
    {
        if (Mathf.Abs(posA.x - posB.x) < 1 && Mathf.Abs(posA.y - posB.y) < 1 && Mathf.Abs(posA.z - posB.z) < 1) return true;
        return false;
    }
}
