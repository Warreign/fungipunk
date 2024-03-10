using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogBox;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI dialogueText;

    [SerializeField]
    private DialogueCollectionAsset currentDialogue;
    private bool isCurrentOver = true;
    private int linePosition;

    public void StartDialogue(DialogueCollectionAsset newDialogue)
    {
        currentDialogue = newDialogue;
        isCurrentOver = false;
        dialogBox.SetActive(true);
        linePosition = -1;

        foreach (var d in newDialogue.dialogs)
        {
            d.clear();
        }

        yieldLine();
    }

    public void EndDialogue()
    {
        // currentDialogue = null;
        isCurrentOver = true;
        dialogBox.SetActive(false);
        linePosition = -1;

        nameText.text = String.Empty;
        dialogueText.text = String.Empty;
    }

    public bool yieldLine()
    {
        if (isCurrentOver)
        {
            Debug.Log("No dialogue");
            return false;
        }

        linePosition++;
        if (linePosition >= currentDialogue.sequence.Length)
        {
            Debug.Log("Dialog collection has ended");
            EndDialogue();
            return false;
        }

        // nameText.text = currentDialogue.sequence[linePosition];
        DialogueAsset currentCharacter = currentDialogue.dialogs[currentDialogue.sequence[linePosition]];

        nameText.text = currentCharacter.name;
        dialogueText.text = currentCharacter.nextLine();

        return true;
    }

    public string GetGoalName()
    {
        return currentDialogue.goalPotion;
    }

    public bool nextGoal()
    {
        if (currentDialogue.nextGoal != null)
        {
            StartDialogue(currentDialogue.nextGoal);
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetCurrentName()
    {
        if (isCurrentOver) return "";
        return currentDialogue.dialogs[currentDialogue.sequence[linePosition]].name;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
