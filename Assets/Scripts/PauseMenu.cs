using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI; //Stores the UI object
    public static bool GameIsPaused = false; //Stores whether the game is paused

	// Update is called once per frame
	void Update () {
		//If user presses P, toggle between pause and unpause
		if(Input.GetKeyDown(KeyCode.P))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

	//Resumes the game by setting time to normal
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

	//Pauses game by freezing time
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

	//Goes back to main menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        InteractionControl.codeTwo = 0;
        ItemHandler.eEggs = 0;
        SceneManager.LoadScene("MainMenu");
        
    }

	//Closes the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
