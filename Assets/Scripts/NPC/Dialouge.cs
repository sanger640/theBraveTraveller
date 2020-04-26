using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialouge {

	//Stores the dialogue for each character
    public string name;
    [TextArea(3,10)]
    public string[] sentences;
}
