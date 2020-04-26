using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public bool onTrigger;
    public string targetLevel;

    // Use this for initialization
    void Start()
    {
        
    }

   
    void OnTriggerStay(Collider other)
    {
		 //If player collides with object and collision is turned on, send player to next level
        if (!onTrigger && other.gameObject.tag == "Player")
            SceneManager.LoadScene(targetLevel, LoadSceneMode.Single);
    }

	//Loads the desired scene when called from another script
    public void goToLevel()
    {
        SceneManager.LoadScene(targetLevel, LoadSceneMode.Single);
    }

}