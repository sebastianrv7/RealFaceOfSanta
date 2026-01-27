using System;
using System.Collections;
using UnityEngine;
using TMPro;    

public class DialogueController: MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;

    [SerializeField]
    private CameraController cameraController;

    [SerializeField]
    private PlayerInputHandler playerInputHandler;

    private string[] dialogues;
    private int index;
    private bool dialogueActive;

    private void Update()
    {
        if (!dialogueActive) return;

        if (Input.GetMouseButtonDown(0))
        {
            ContinueDialogue();
            
        }
    }

    public void InitializeDialogue(string[] dialogueInfo)
    {         
        dialogues = dialogueInfo;
    }

    public void StartDialogue()
    {
        if (dialogues == null || dialogues.Length == 0)
            return;

        dialogueActive = true;
        index = 0;
        ShowDialogue();
    }

    private void ShowDialogue()
    {
        if (index >= dialogues.Length)
        {
            EndDialogue();
            return;
        }

        dialogueText.SetText(dialogues[index]);
    }

    private void ContinueDialogue()
    {
        index++;
        ShowDialogue();
    }

    private void EndDialogue()
    {
        dialogueActive = false;
        dialogueText.SetText("");
        cameraController.FocusOnPlayer();
        playerInputHandler.EnableInput();
    }
}
