using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionHandler : MonoBehaviour {
    
    private GameObject door; //Stores the door object
	
	// Update is called once per frame
	void Update () {
		//Checks if the interacted object is a door
        if (GetComponent<InteractionControl>().isActive() == "Door")
        {
            door = GetComponent<InteractionControl>().getObject(); //Gets the door object
            door.GetComponent<LevelHandler>().goToLevel(); //Calls function to go to specified level
        }
	}
}
