using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractionHandler : MonoBehaviour {
    public GameObject UI; //Store the user interface screen object
    private GameObject npc; //Store the NPC object
    private DialougeTrigger dialogue; //Store the dialogue control
    private bool hasInteracted; //Stores if the user has interacted with the object already
    
    //Initialize variables when game starts
    void Start()
    {
        UI.SetActive(false); //Hides the UI at the start of the level
    }

    // Update is called once per frame
    void Update()
    {
		//Checks if the interacted object is a NPC
        if (!hasInteracted && GetComponent<InteractionControl>().isActive() == "NPC") 
		{
			GetComponent<MovementControl>().enabled = false; //Disables character movement as if paused
            npc = GetComponent<InteractionControl>().getObject(); //Gets the NPC object
            dialogue = npc.GetComponent<DialougeTrigger>(); //Gets the dialogue trigger object
            UI.SetActive(true); //Shows the UI for dialogue
			dialogue.TriggerDialouge(); //Activates the NPC dialogue
            hasInteracted = true; //True if the user interacts first time
		}
		else if (GetComponent<InteractionControl>().isActive() != "NPC")
		{
            UI.SetActive(false); //Closes UI when user leaves the NPC
            hasInteracted = false;
        }
			
    }
}
