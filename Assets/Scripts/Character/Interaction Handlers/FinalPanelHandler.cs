using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalPanelHandler : MonoBehaviour
{

    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        if (GetComponent<InteractionControl>().isActive() == "FinalPanel")
        {
            if (InteractionControl.codeTwo == 2 )
            {
                
                if(ItemHandler.eEggs == 3)
                {
                    ItemHandler.eEggs = 0;
                    InteractionControl.codeTwo = 0;
                    MainMenu.collEnding = true;
                    SceneManager.LoadScene("CollectorEndingU");
                    

                }
                else
                {

                    ItemHandler.eEggs = 0;
                    InteractionControl.codeTwo = 0;
                    MainMenu.bondEnding = true;
                    SceneManager.LoadScene("BondEndingU");
                   


                }
                
            }

            else 
            {
                ItemHandler.eEggs = 0;
                InteractionControl.codeTwo = 0;
                MainMenu.falloutEnding = true;
                SceneManager.LoadScene("FalloutEndingU");
                

            }
            
        }
    }
}
