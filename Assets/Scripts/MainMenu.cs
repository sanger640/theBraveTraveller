using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	//Stores the type of ending to choose
    public static bool falloutEnding = false;
    public static bool bondEnding = false;
    public static bool collEnding = false;
	//All possible endings
    public GameObject falloutAfter;
    public GameObject falloutBefore;
    public GameObject bondAfter;
    public GameObject bondBefore;
    public GameObject collBefore;
    public GameObject collAfter;
    public GameObject exBefore;
    public GameObject exAfter;

	//Starts the game
    public void PlayGame()  
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	//Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }

	//Lets the player view the different endings
    private void Update()
    {
        if(falloutEnding)
        {
            falloutBefore.SetActive(false);
            falloutAfter.SetActive(true);
            
        }

        if(bondEnding)
        {
            bondBefore.SetActive(false);
            bondAfter.SetActive(true);
        }

        if(collEnding)
        {
            collBefore.SetActive(false);
            collAfter.SetActive(true);
            exBefore.SetActive(false);
            exAfter.SetActive(true);

        }
    }
}
