using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

	private bool hasInteracted; //Stores if the user has interacted with the object already
	private GameObject button; //Stores the button object
	
	// Update is called once per frame
	void Update () {
		//Checks if the interacted object is a button
		if (!hasInteracted && GetComponent<InteractionControl>().isActive() == "Button") 
		{
            hasInteracted = true; //True if the user interacts first time
			button = GetComponent<InteractionControl>().getObject(); //Gets the button object
			button.GetComponent<ButtonController>().toggleButton(); //Toggles the button (on/off)
		}
		else if (GetComponent<InteractionControl>().isActive() != "Button")
		{
            hasInteracted = false; //Returns to false after user leaves the button
        }
	}
}
