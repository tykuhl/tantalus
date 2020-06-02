using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public bool inRange;
    public static bool inDialogue = false;
    public int heightOffset;

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (inRange == true && inDialogue == false)
            {
                inDialogue = true;
                TriggerDialogue();
            }
        }
    }

    /** WIP
    public Vector3 GetDialoguePosition()
    {
        Transform trans = GetComponent<Transform>();
        Debug.Log("The Transform Component is " + trans.transform.position);
        return trans.transform.position;
    }
    **/

    // IS THIS BEING USED?
    public void EnableTrigger()
    {
        inDialogue = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
        Debug.Log("trigger entered");
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        Debug.Log("trigger exited");
    }

    public void TriggerDialogue()
    {
        // send the position for the object to the dialogue manager so the dialogue box position can be updated
        Transform trans = GetComponent<Transform>();
        Debug.Log("The Transform Component is " + trans.transform.position);
        DialogueManager.SetDialoguePosition(trans, heightOffset);

        // starts dialogue after position has been set
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
