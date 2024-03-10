using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static Mushroom;

public class Controller : MonoBehaviour
{
    public static bool s_isRunning = false;
    public static Dictionary<FungiType, int> storedMushrooms = new Dictionary<FungiType, int>();

    public static void PopulateStored()
    {
        foreach (var k in Enum.GetValues(typeof(FungiType)))
        {
            storedMushrooms.Add((FungiType)k, 0);
        }
    }

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
    private GameObject bags;


    [SerializeField]
    private Customer initialCustomer;

    private Customer currentCustomer;
    public GameObject recipePanel;
    public TextMeshProUGUI goalText;

    public DialogueCollectionAsset firstDayDialogues;

    public InputActionReference nextLineAction;
    public InputActionReference goOutsideAction;
    public InputActionReference openRecipesAction;
    public DialogueController dialogueController;

    static Controller()
    {
        PopulateStored();
    }

    void Start()
    {
        foreach (var c in _characters)
        {
            characters.Add(c.name, c.Object);
        }
        // DontDestroyOnLoad(this);
        
        if (!s_isRunning)
        {
            currentCustomer = initialCustomer;
            dialogueController.StartDialogue(firstDayDialogues);
            s_isRunning = true;
        }
        else
        {
            // PlayerPrefs.GetInt()
            foreach (var k in Enum.GetValues(typeof(FungiType)))
            {
                var ft = (FungiType)k;
                storedMushrooms[ft] += PlayerPrefs.GetInt(ft.ToString());
                Debug.Log("" + ft.ToString() + ": " + storedMushrooms[ft]);
            }
            Debug.Log("Found " + bags.GetComponentsInChildren<Bag>().Length + " components");
            foreach (var b in bags.GetComponentsInChildren<Bag>())
            {
                b.updateCount();
            }
        }
        goalText.text = dialogueController.GetGoalName();

        nextLineAction.action.performed += (InputAction.CallbackContext c) => NextLine();
        goOutsideAction.action.performed += (InputAction.CallbackContext c) => SceneManager.LoadScene("MushroomCatch");
        openRecipesAction.action.performed += (InputAction.CallbackContext c) => recipePanel.SetActive(!recipePanel.activeSelf);
        
    }

    private void NextLine()
    {
        string name = dialogueController.GetCurrentName();
        if (characters.ContainsKey(name))
        {
            characters[name].SetActive(false);
        }

        if (!dialogueController.yieldLine()) return;

        name = dialogueController.GetCurrentName();

        if (characters.ContainsKey(name))
        {
            characters[name].SetActive(true);
        }
    }

    public void CheckBrew(string name)
    {
        if (name.Equals(dialogueController.GetGoalName()))
        {
            if (dialogueController.nextGoal())
            {
                goalText.text = dialogueController.GetGoalName();
            }
            else{
                winScreen();
            }
            
        }
    }

    public void winScreen()
    {

    }

    public void NextGoal()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ChangeCustomer()
    {

    }
    
}
