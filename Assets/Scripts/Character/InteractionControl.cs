using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionControl : MonoBehaviour
{
    public GameObject textPanel; //Gets text panel object
    public static int codeTwo = 0; //Stores number of nuclear codes found

    private string activatedObject = null; //Stores if the user interacted with the panel
    private GameObject currObject; //Stores the current object the user is interacting with
    
	//Initialize variables when game starts
    void Start()
    {
        textPanel.SetActive(false); //Hides the text panel at beginning of level
    }

	//Tracks collisions between this and other objects
    void OnTriggerStay(Collider other)
    {
        string tag = other.gameObject.tag; //Get tag name of other object
        currObject = other.gameObject; //Get the other object;
		//Check to see if the tag match one of the following interactable objects
        if (tag == "Door" || tag == "Panel" || tag == "NPC" || tag == "FinalPanel" || tag == "EasterEgg" || tag == "Button")
        {
            if (activatedObject == null)
            {
                textPanel.SetActive(true); //Activates the text panel prompt if no object has been activated
            }
            //If user presses "E", set activatedObject to the object tag that has been activated
            if (Input.GetKeyDown(KeyCode.E))
            {
                activatedObject = tag;
                textPanel.SetActive(false);
            }
        }
        
		//If user presses Esc, exit the interface
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exit();
        }

    }

	//If the character no longer collides with other objects, close the UI panel
    public void OnTriggerExit(Collider other)
    {
        textPanel.SetActive(false);
		activatedObject = null; //Remove the current activated object
    }

	//Removes activated object, closes UI, and enables character movement when called
    public void exit()
    {
        activatedObject = null;
        textPanel.SetActive(true);
        GetComponent<MovementControl>().enabled = true;
    }

    //Getter method, returns if user has activated panel or not
    public string isActive()
    {
        return activatedObject;
    }

	//Getter method, returns the current activated object
    public GameObject getObject()
    {
        return currObject;
    }
}
