using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        spawner.SpawnMushroomOnMouse(Type);
    }
}
