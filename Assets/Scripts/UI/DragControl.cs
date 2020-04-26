using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour {

    private GameObject [] boxes; //Array containing all boxes on UI screen
    private Vector3 boxPos; //Stores position of target box
    private Vector3 myPos; //Stores position of this text snippet

	//Initialize variables
	void Start () {
        boxes = GameObject.FindGameObjectsWithTag("Box") as GameObject[];
    }
	
	// Update is called once per frame
	void Update () {
        myPos = transform.position; //Get or update currect position
        for (int i = 0; i < boxes.Length; i++) //Cycle through all boxes
        {
            boxPos = boxes[i].transform.position; //Get target box position
            if (!Input.GetMouseButton(0) && isClose(myPos, boxPos) && boxes[i].GetComponent<DetectCorrect>().getOccupied() == -1)
            {
                //Snap the snippet position to the box position if they are close enough and the box is not occupied
                transform.position = new Vector3(boxPos.x, boxPos.y, boxPos.z - 0.01f);
            }
        }
	}
    
    //Allow the user to use the mouse to drag code snippets around
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7.9f);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;
    }

    //Checks to see if two 3D coordinates are close enough to each other
    public bool isClose(Vector3 posA, Vector3 posB)
    {
        if (Mathf.Abs(posA.x - posB.x) < 0.5 && Mathf.Abs(posA.y - posB.y) < 0.1 && Mathf.Abs(posA.z - posB.z) < 0.1) return true;
        return false;
    }
}
