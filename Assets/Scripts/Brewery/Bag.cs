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
    public FungiType Type
    {
        get => _type;
        set => _type = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
