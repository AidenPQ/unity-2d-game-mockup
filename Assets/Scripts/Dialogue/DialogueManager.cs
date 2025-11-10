using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private float txtspeed;

    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        txtspeed = PlayerPrefs.GetFloat("txtspd");
    }

   public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = "";

        StartCoroutine(WriteSentence(sentence));
    }

    IEnumerator WriteSentence(string sentence)
    {
        foreach (string word in sentence.Split(' '))
        {
            yield return new WaitForSeconds(txtspeed);
            dialogueText.text += " " + word;
           
        }
        

    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
