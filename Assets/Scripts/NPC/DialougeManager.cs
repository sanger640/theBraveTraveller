using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour {

    public Text nameText; //Stores name of NPC
    public Text dialougeText; //Stores dialogue of NPC
    public GameObject character; //Stores character object

    public Animator animator; //Stores animator object

    private Queue<string> sentences; //Creates sentences from dialogue
	// Use this for initialization
	void Start () {
        sentences = new Queue<string>(); //Initialize sentences
	}
    
    public void StartDialouge(Dialouge dialouge)
    {
		//Starts the animation
        animator.SetBool("IsOpen", true);

		//Gets the name of NPC
        nameText.text = dialouge.name;
        sentences.Clear();

		//Put all scentences in a queue
        foreach(string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
		//Extracts the senctences from the queue and display
        if(sentences.Count == 0)
        {
            EndDialouge();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
		//Loads the characters into the sentence
        dialougeText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialougeText.text += letter;
            yield return null;
        }
    }

	//Exit the dialogue
    void EndDialouge()
    {
        character.GetComponent<InteractionControl>().exit();
    }
}
