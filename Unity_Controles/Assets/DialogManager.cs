﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;
    public GameObject exclamationSprite;
    public Animator animator;
   
    
    void Start()
    {
        sentences = new Queue<string>();
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        print("dialogue with" + dialogue.name);
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
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    void EndDialogue()
    {
        exclamationSprite.SetActive(true);
        animator.SetBool("IsOpen", false);
        Debug.Log("End of dialogue");
    }
    
}


