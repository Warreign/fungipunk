using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static Mushroom;

public class MushroomSpawner : MonoBehaviour
{


    [SerializeField]
    private MushroomPicker picker;

    [SerializeField]
    private InputActionReference mousePoseAction;
    
    [SerializeField]
    private GameObject mushroomPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMushroomOnMouse(FungiType type)
    {
        Debug.Log("Spawned " + type);

        // var type = FungiType.Purple;
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePoseAction.action.ReadValue<Vector2>());
        mouseWorldPos.z = 0f;

        var newFungus = Instantiate(mushroomPrefab, mouseWorldPos, Quaternion.identity);
        var renderer = newFungus.GetComponent<SpriteRenderer>();
        var mushroom = newFungus.GetComponent<Mushroom>();

        mushroom.type = type;
        mushroom.isFollow = true;
        
        renderer.sprite = picker.GetSprite(mushroom.type);
    }

}
