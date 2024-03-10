using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Mushroom;

public class MushroomSpawner : MonoBehaviour
{


    [SerializeField]
    private InputActionReference mousePoseAction;
    
    [SerializeField]
    private GameObject mushroomPrefab;
    
    [SerializeField]
    private Sprite redMushroom;
    [SerializeField]
    private Sprite brownMushroom;
    [SerializeField]
    private Sprite purpleMushroom;
    [SerializeField]
    private Sprite darkredMushroom;
    [SerializeField]
    private Sprite greenMushroom;
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
        
        switch (type)
        {
            case FungiType.Red:
            renderer.sprite = redMushroom;
            break;
            case FungiType.Green:
            renderer.sprite = greenMushroom;
            break;
            case FungiType.DarkRed:
            renderer.sprite = darkredMushroom;
            break;
            case FungiType.Purple:
            renderer.sprite = purpleMushroom;
            break;
            case FungiType.Brown:
            renderer.sprite = brownMushroom;
            break;
        }
    }

}
