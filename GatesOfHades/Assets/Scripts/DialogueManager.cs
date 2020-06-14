using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBody;
    public GameObject Charon;
    public string[] dialogues;
    public TextMeshProUGUI dialogueText;
    private int i;
    public AudioSource nextSound;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Enter"))
        {
            Debug.Log("Pressed");
            nextSound.Play();
            if (i <= dialogues.Length - 1)
            {
                dialogueText.text = dialogues[i];
                i++;

            } else if(i >= dialogues.Length)
            {
                Charon.GetComponent<ActionManager>().CharonAction();
                this.transform.Find("DialogueBody").gameObject.SetActive(false);
            }
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                dialogueBody.SetActive(true);
                StartDialogue();


            }
        }

        private void StartDialogue()
        {
            i = 0;
           dialogueText.text = dialogues[i];
           i++;
            
    }
    
}
