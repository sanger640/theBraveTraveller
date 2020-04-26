using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlatformControl : MonoBehaviour {

    public int leftBoundary; //Stores left boundary for object
    public int rightBoundary; //Stores right boundary for object
	public int upBoundary; //Stores up boundary for object
	public int downBoundary; //Stores down boundary for object
	public float speed; //Stores speed at which the platforms move at

    private Vector3 firstWaypoint; //Stores the first waypoint for object to reach
    private Vector3 secondWaypoint; //Stores the second waypoint for object to reach
	private Vector3 startingPos; //Stores starting position of object
    private Vector3 thisPos; //Stores the current position of object
    private bool forward; //Stores whether the object is moving forward

    // Use this for initialization
    void Start () {
		startingPos = transform.position; //Sets the starting position
		forward = true; //Object initially facing forward
    }
	
	// Update is called once per frame
	void Update () {
		//Calculates vector position of first waypoint
		firstWaypoint = new Vector3(startingPos.x - leftBoundary, startingPos.y + upBoundary, startingPos.z); 
		//Calculates vector position of second waypoint
        secondWaypoint = new Vector3(startingPos.x + rightBoundary, startingPos.y - downBoundary, startingPos.z);
		
        thisPos = transform.position; //Gets position of this object

        if (isClose(thisPos, firstWaypoint)) forward = true; //If object has reached left waypoint, head towards right waypoint
        if (isClose(thisPos, secondWaypoint)) forward = false; //If object has reached right waypoint, head towards left waypoint
		
		//Moves the object towards the desired waypoint depending on the way it is facing
        if (forward) transform.position = Vector3.MoveTowards(thisPos, secondWaypoint, speed * Time.deltaTime);
        else transform.position = Vector3.MoveTowards(thisPos, firstWaypoint, speed * Time.deltaTime);
    }

    //Checks to see if two 3D coordinates are close enough to each other
    public bool isClose(Vector3 posA, Vector3 posB)
    {
        if (Mathf.Abs(posA.x - posB.x) < 1 && Mathf.Abs(posA.y - posB.y) < 1 && Mathf.Abs(posA.z - posB.z) < 1) return true;
        return false;
    }

	//Gets input from text box for the boundaries of the object
	public void getInput(string input) {
		if (input.Length > 0) {
			rightBoundary = Int32.Parse(input); //Converts from string to integer
			transform.position = startingPos;
		}
	}
}
