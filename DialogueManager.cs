using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {

    // TextMeshProUGUI
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    public bool inDialogue = false;
    public bool ReadyToProgress = false;
    public static Vector3 DialoguePosition;
    public static float DialogueDistance;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (inDialogue == true && ReadyToProgress == true)
            {
                Debug.Log("Submit is pressed while IN DIALOGUE");
                DisplayNextSentence();
            }
            else
            {
                Debug.Log("Submit pressed, but inDialogue: " + inDialogue + " and ReadyToProgress: " + ReadyToProgress);
            }
        }
    }

    public static void SetDialoguePosition(Transform pos, int offset)
    {
        // Setting DialogueBox object's location
        DialoguePosition = pos.transform.position;
        GameObject.Find("DialogueBox").transform.position = Camera.main.WorldToScreenPoint(DialoguePosition);
        DialoguePosition = GameObject.Find("DialogueBox").transform.position;
        DialoguePosition.y += 150 + offset;
        GameObject.Find("DialogueBox").transform.position = DialoguePosition;

    }

    public void StartDialogue (Dialogue dialogue)
    {
        inDialogue = true;

        // disable player movement
        CharController.standstill = true;

        animator.SetBool("isOpen", true);

        Debug.Log ("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        ReadyToProgress = false;

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log("Sentence displayed");
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.02f);
        }

        ReadyToProgress = true;
    }

    void EndDialogue()
    {
        // enable player movement
        CharController.standstill = false;

        animator.SetBool("isOpen", false);
        Debug.Log("DIALOGUE ENDED");
        inDialogue = false;

        DialogueTrigger.inDialogue = false;
    }
}
