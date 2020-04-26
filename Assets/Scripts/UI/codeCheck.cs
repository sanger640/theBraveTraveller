using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeCheck : MonoBehaviour {
    private GameObject[] boxes; //Array containing all boxes on UI screen
    private bool allCorrect; //Stores if all boxes have the correct code snippet
   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
        allCorrect = true; //Assume all boxes have correct snippet
        boxes = GameObject.FindGameObjectsWithTag("Box") as GameObject[];

        for (int i = 0; i < boxes.Length; i++)
        {
            //If a box has incorrect snippet, "allCorrect" becomes false
            if (!boxes[i].GetComponent<DetectCorrect>().getCorrect())
                allCorrect = false;
        }
        
        if (boxes.Length > 0 && allCorrect)
        {
            InteractionControl.codeTwo++;
            Debug.Log(InteractionControl.codeTwo);
            
            GetComponent<InteractionControl>().exit();
        }
    }
}
