using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	private bool state; //Stores whether the button is on or off
	public Material material; //Get the material component for this box (for changing colours)
	
	// Update is called once per frame
	void Update () {
		if (state) material.color = Color.green; //If button is on, set colour to green
		else material.color = Color.red; //If button is off, set colour to red
	}

	//Method that changes the state of the button
	public void toggleButton() {
		state = !state;
	}

	//Method that gets the state of the button
	public bool getState() {
		return state;
	}
}
