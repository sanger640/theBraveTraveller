using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

	public GameObject object1; //Stores the first button object
	public GameObject object2;	//Stores the second button object
	public bool answer1; //Stores correct answer for button1
	public bool answer2; //Stores correct answer for button2

	private bool state; //Stores if the light is on or off
	public Material material; //Get the material component for this box (for changing colours)
	
	// Update is called once per frame
	void Update () {
		//Determines whether the answers are correct and turns state on or off
		if (object1.GetComponent<ButtonController>().getState() == answer1 && 
			object2.GetComponent<ButtonController>().getState() == answer2)
			state = true;
		else state = false;

		if (state) material.color = Color.green; //If light is on, set colour to green
		else material.color = Color.red; //If light is off, set colour to red
	}

	//Gets whether the light is on or off
	public bool getState() {
		return state;
	}
}
