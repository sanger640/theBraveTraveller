using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour {
    
    public static int eEggs = 0; //Stores the number of easter eggs aquired
    public bool done = false;
    // Update is called once per frame
    void Update () {
        if (GetComponent<InteractionControl>().isActive() == "EasterEgg" && !done)
        {
            done = true;
			//Destroys the easter egg object and records the number of easter eggs
            DestroyObject(GetComponent<InteractionControl>().getObject());
            eEggs++;
        }
        
    }
}
