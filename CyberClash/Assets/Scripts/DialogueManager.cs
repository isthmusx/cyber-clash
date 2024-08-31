using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Animator animator;

    public bool IsDialogueFinished { get; private set; } = false;

    private Queue<string> sentences;

    bool isTalking;
    float typingSpeed;

    void Awake()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
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
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        typingSpeed = 0.1f;
        isTalking = true;

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            
            yield return new WaitForSeconds(typingSpeed);
        }
        isTalking = false;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        IsDialogueFinished = true;
    }
    public void ButtonClickHandler()
    {
        typingSpeed = 0f;

        if (!isTalking)
        {
            DisplayNextSentence();
        }
    }

}
