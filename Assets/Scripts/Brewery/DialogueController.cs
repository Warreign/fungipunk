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
    private int linePosition;

    public void StartDialogue(DialogueCollectionAsset newDialogue)
    {
        currentDialogue = newDialogue;
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
        currentDialogue = null;
        dialogBox.SetActive(false);
        linePosition = -1;
    }

    public void yieldLine()
    {
        if (currentDialogue == null)
        {
            Debug.Log("No dialogue");
            return;
        }

        linePosition++;
        if (linePosition >= currentDialogue.sequence.Length)
        {
            Debug.Log("Dialog collection has ended");
            EndDialogue();
            return;
        }

        // nameText.text = currentDialogue.sequence[linePosition];
        DialogueAsset currentCharacter = currentDialogue.dialogs[currentDialogue.sequence[linePosition]];

        nameText.text = currentCharacter.name;
        dialogueText.text = currentCharacter.nextLine();
    }

    public string GetCurrentName()
    {
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
