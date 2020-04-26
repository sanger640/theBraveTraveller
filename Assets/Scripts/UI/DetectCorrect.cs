using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCorrect : MonoBehaviour {

    private GameObject[] snipps; //Array containing all code snippets on the UI screen
    private Vector3 snipPos; //The position of the snippet
    private Vector3 myPos; //The position of this box
    public Material material; //Get the material component for this box (for changing colours)
    public int correctAns; //Stores the correct answer for this box (eg. 1, 2, 3, etc.)
    private int occupied; //Stores if this box is occupied
    private bool correct; //Stores if the correct code snippet is placed into this box

    //Initialize variables
    void Start () {
        snipps = GameObject.FindGameObjectsWithTag("Snip") as GameObject[];
        material.color = Color.white; //make the box white originally
        correct = false;
    }

    // Update is called once per frame
    void Update()
    {
        myPos = transform.position; //Get or update position of this box
        occupied = -1; //Set "-1" value for unoccupied status
        for (int i = 0; i < snipps.Length; i++) //Cycle through all snippets
        {
            snipPos = snipps[i].transform.position; //Get position of target snippet
            if (isClose(myPos, snipPos))
            {
                //If a snippet is detected to be close, store which snippet it is by its 
                //last number int othe "occupied" variable and exit the loop
                occupied = (int)snipps[i].name[snipps[i].name.Length - 1] - 48;
                break;
            }
        }
        //Check if the snippet occuping the box is correct snippet
        if (occupied + "" == correctAns + "")
        {
            //If it is correct, box turns green and "correct" will be true
            material.color = Color.green;
            correct = true;
        }
        else if (occupied > 0)
        {
            //If it is incorrect, box turns red and "correct" will be false
            material.color = Color.red;
            correct = false;
        }
        else
        {
            //If no snippet occupies the box, the box turns white and "correct" will be false
            material.color = Color.white;
            correct = false;
        }
    }

    //Get occupied variable
    public int getOccupied()
    {
        return occupied;
    }

    //Get correct variable
    public bool getCorrect()
    {
        return correct;
    }

    //Checks to see if two 3D coordinates are close enough to each other
    public bool isClose(Vector3 posA, Vector3 posB)
    {
        if (Mathf.Abs(posA.x - posB.x) < 0.01 && Mathf.Abs(posA.y - posB.y) < 0.01 && Mathf.Abs(posA.z - posB.z) < 1) return true;
        return false;
    }
}
