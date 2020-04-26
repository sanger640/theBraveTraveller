using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWallControl : MonoBehaviour {
	public Animator anim;
	public GameObject frontWall;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //If all the boxes have correct snippets, move the wall back and close UI screen
        if (frontWall.GetComponent<WallControl>().isTriggered())
        {
			anim.SetBool("UpR", true); //Runs animation of wall
        }
	}
}
