using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAudio : MonoBehaviour {
	//Plays music
    static BAudio instance = null;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
