using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static Mushroom;

public class Controller : MonoBehaviour
{
    [Serializable]
    public struct Charater
    {
        public string name;
        public GameObject Object;
    }

    [SerializeField]
    private Charater[] _characters;
    private Dictionary<string, GameObject> characters = new Dictionary<string, GameObject>();


    [SerializeField]
    private Customer initialCustomer;

    private Customer currentCustomer;

    public DialogueCollectionAsset firstDayDialogues;

    public InputActionReference nextLineAction;
    public DialogueController dialogueController;

    void Start()
    {
        foreach (var c in _characters)
        {
            characters.Add(c.name, c.Object);
        }
        // DontDestroyOnLoad(this);

        currentCustomer = initialCustomer;

        dialogueController.StartDialogue(firstDayDialogues);

        nextLineAction.action.performed += (InputAction.CallbackContext c) => NextLine();
    }

    private void NextLine()
    {
        string name = dialogueController.GetCurrentName();
        if (characters.ContainsKey(name))
        {
            characters[name].SetActive(false);
        }
        dialogueController.yieldLine();
        name = dialogueController.GetCurrentName();

        if (characters.ContainsKey(name))
        {
            characters[name].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ChangeCustomer()
    {

    }
    
}
