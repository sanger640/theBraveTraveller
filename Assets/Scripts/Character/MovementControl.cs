using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementControl : MonoBehaviour
{
    public float speed; //How fast character moves
    public float jumpFactor; //How much character jumps
    public float gravity; //The gravity multiplier
    private Vector3 moveDir; //The 3D vector direction the character is moving
    private bool firstJump; //Records if it is the character's first jump
    private CharacterController controller; //The character control component in unity

    private static Vector3[] lastPositions = new Vector3[10]; //Stores the last position of the character for every level
    private static bool[] hasVisited = new bool[10]; //Stores whether the level has already been visited
    private int sceneIndex; //Stores the current scene as an index number
    private string currScene; //Stores the name of the current scene
    private Animator anim; //Stores the animator object

    //Initialize the variables when game starts
    void Start()
    {
        moveDir = new Vector3(0, 0, 0); //Initialize movement direction
        controller = GetComponent<CharacterController>(); //Get the chracter controll component in unity
        firstJump = false;
        anim = GetComponent<Animator>();

        currScene = SceneManager.GetActiveScene().name;

        switch (currScene)
        {
            case "Level1":
                sceneIndex = 0;
                break;
            case "Level2":
                sceneIndex = 1;
                break;
            case "Level2b":
                sceneIndex = 2;
                break;
            case "Level4":
                sceneIndex = 4;
                break;
            case "Level5":
                sceneIndex = 8;
                break;
			case "Level5a":
				sceneIndex = 9;
				break;
            default:
                sceneIndex = -1;
                break;
        }
    }

    //Runs repeat
    void Update() {
        //Horizontal movement recorded into vector form
        moveDir.x = Input.GetAxis("Horizontal") * speed;
        moveDir = transform.TransformDirection(moveDir);

		if (controller.isGrounded) {
			moveDir.y = 0;
			//Vertical movement recorded into vector form
			if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("w")))
			{
				moveDir.y = jumpFactor;
				firstJump = true;
			}
		}

        //Checks if character is jumping and if user wants to jump
        //also make sure the character has been in the air for some time
        if (firstJump && moveDir.y < 1 && (Input.GetButton("Jump") || Input.GetKeyDown("w"))) 
        {
            //If character is jumping, this allows for double jump
            moveDir.y = jumpFactor;
            firstJump = false;
        }

        //Uses the recorded vector variable to control the movement of the character
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);

        if (sceneIndex > 0)
        {
            if (!isClose(transform.position, lastPositions[sceneIndex]) && hasVisited[sceneIndex])
            {
                transform.position = lastPositions[sceneIndex];
            }
            lastPositions[sceneIndex] = transform.position;
            hasVisited[sceneIndex] = true;
        }

        if (Input.GetKeyDown("d"))
        {
            anim.SetBool("Run R", true);
            anim.SetBool("Run L", false);
        }
        else if (Input.GetKeyDown("a"))
        {
            anim.SetBool("Run L", true);
            anim.SetBool("Run R", false);
        }
        if (Input.GetKey("a") == false && Input.GetKey("d") == false)
        {
            anim.SetBool("Run R", false);
            anim.SetBool("Run L", false);
        }
    }

    public bool isClose(Vector3 posA, Vector3 posB)
    {
        if (Mathf.Abs(posA.x - posB.x) < 1 && Mathf.Abs(posA.y - posB.y) < 1 && Mathf.Abs(posA.z - posB.z) < 1) return true;
        return false;
    }

}