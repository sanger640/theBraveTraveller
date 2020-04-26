using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour {

    private GameObject [] boxes; //Array containing all boxes on UI screen
    public GameObject player; //Gets user object
	private int numCorrectBoxes; //Stores number of boxes that have correct answers
    private bool allCorrect; //Stores if all boxes have the correct code snippet
	private bool triggeredWall; //Stores whether the wall is moving
	public Animator anim; //Stores the animation object

	// Use this for initialization
	void Start () {
		//waypoint = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
		anim = GetComponent<Animator>(); //Gets the animator object
    }
	
	// Update is called once per frame
	void Update () {
        allCorrect = true; //Assume all boxes have correct snippet
        boxes = GameObject.FindGameObjectsWithTag("Box") as GameObject[];

		numCorrectBoxes = 0;
        for (int i = 0; i < boxes.Length; i++)
        {
            //Gets the total number of correct boxes
            if (boxes[i].GetComponent<DetectCorrect>().getCorrect())
                numCorrectBoxes++;
        }
		if (numCorrectBoxes < 4) allCorrect = false; //If less than 4 boxes are correct, set all correct to false
        
        //If all the boxes have correct snippets, move the wall back and close UI screen
        if (boxes.Length > 0 && allCorrect || triggeredWall)
        {
			triggeredWall = true; 
			anim.SetBool("Up", true); //Animates the wall

            player.GetComponent<InteractionControl>().exit();
        }
	}

	//Gets whether the wall is moving
	public bool isTriggered() {
		return triggeredWall;
	}
}
