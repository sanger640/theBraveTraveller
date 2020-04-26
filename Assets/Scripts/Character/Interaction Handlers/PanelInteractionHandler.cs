using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInteractionHandler : MonoBehaviour
{
	public GameObject UI; //Get the user interface screen object in the game

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<InteractionControl>().isActive() == "Panel")  
		{
			GetComponent<MovementControl>().enabled = false; //Disables character movement as if paused
			UI.SetActive(true); //Shows the UI for the panel
		}
		else 
			UI.SetActive(false); //Hides the UI when user leaves panel
    }

	//Closes UI and allows the character to move again
	public void closeUI ()
    {
        UI.SetActive(false);
        GetComponent<MovementControl>().enabled = true;
    }

}
