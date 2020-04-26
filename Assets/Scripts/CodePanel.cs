using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour {

    public InputField nameField; //Stores the input field object
    public GameObject right; //Stores the right UI component
    public GameObject wrong; //Stores the left UI component
    public GameObject d; //Stores the done UI component
    private bool done = false; //Stores whether the puzzle has been completed
    
    private string ans = "neil armstrong"; //Stores the correct answer

    public void OnSubmit()
    {
        wrong.SetActive(false);
        right.SetActive(false);
        if (done == true) //If puzzle is completed, display done
        {
            d.SetActive(true);
        }
        else
        {
			//If the user input is equal to the answer, display correct UI
            if (nameField.text.ToLower() == ans)
            {
                done = true;
                InteractionControl.codeTwo++;
                Debug.Log(InteractionControl.codeTwo);
                wrong.SetActive(false);
                right.SetActive(true);

            }
			//If the user input is not equal, display wrong UI
            else
            {
                right.SetActive(false);
                wrong.SetActive(true);
            }
        }
    }   
}
