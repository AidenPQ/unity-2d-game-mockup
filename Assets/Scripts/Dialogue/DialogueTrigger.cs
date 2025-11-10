using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool InCollider = false;
    private bool DialogBegin = false;
    public Dialogue dialogue;

    private void Update()
    {
        if(InCollider)
        {
            if (Input.GetKeyDown(KeyCode.F) && !DialogBegin)
            {
                DialogBegin = true;
                TriggerDialogue();
            }
            if(Input.GetMouseButtonDown(0) && DialogBegin)
            {
                if(FindObjectOfType<DialogueManager>().sentences.Count == 0)
                {
                    DialogBegin = false;
                }
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InCollider = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InCollider = false;
        }
    }


}
