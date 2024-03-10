using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements.Experimental;
using static Mushroom;

public class Bag : MonoBehaviour
{

    [SerializeField]
    private FungiType _type;

    public MushroomSpawner spawner;
    [SerializeField]
    private MushroomPicker picker;
    [SerializeField]
    private SpriteRenderer iconRenderer;
    [SerializeField]
    private TextMeshProUGUI countText;

    
    public FungiType Type
    {
        get => _type;
        set => _type = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        // GetComponentInChildren<SpriteRenderer>().sprite = picker.GetSprite(Type);
        iconRenderer.sprite = picker.GetSprite(Type);
    }

    void Awake()
    {
        updateCount();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateCount()
    {
        countText.text = Controller.storedMushrooms[Type].ToString();
    }

    void OnMouseDown()
    {
        int stored = Controller.storedMushrooms[Type];
        if (stored <= 0)
        {
            return;
        }

        spawner.SpawnMushroomOnMouse(Type);
        Controller.storedMushrooms[Type]--;
        updateCount();
    }
}
