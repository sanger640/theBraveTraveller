using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public GameObject character; //Stores the character object
    public float smoothMultiplier = 0.0001f; //Stores smoothness of camera tracking
    private Vector3 dist; //Stores displacement of camera

    // Use this for initialization
    void Start () {
        dist = transform.position - character.transform.position; //Calculates displacement
    }
	
	// Update is called once per frame
	void LateUpdate () {
		//Moves the camera smoothly to adjust for player movement
        Vector3 finalPos = character.transform.position + dist;
        Vector3 smoothPos = Vector3.Lerp(transform.position, finalPos, smoothMultiplier);
        
        transform.position = smoothPos;
    }
}
