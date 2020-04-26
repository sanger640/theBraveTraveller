using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour {

    private Vector3 startPos; //Stores the starting position of the player

    void Start()
    {
        startPos = transform.position; //Records the starting position
    }

    void OnTriggerStay(Collider other)
    {
		//If the user collides with enemy vision or spike, return to start
        if (other.gameObject.tag == "Vision" || other.gameObject.tag == "Spike") {
            transform.position = startPos;
		}
    }
}
