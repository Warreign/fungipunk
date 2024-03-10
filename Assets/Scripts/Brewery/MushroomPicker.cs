using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Mushroom;

public class MushroomPicker : MonoBehaviour
{
    
    [SerializeField]
    private Sprite redMush;
    [SerializeField]
    private Sprite brownMush;
    [SerializeField]
    private Sprite greenMush;
    [SerializeField]
    private Sprite darkredMush;
    [SerializeField]
    private Sprite purpleMush;


    public Sprite GetSprite(FungiType type)
    {
        switch (type)
        {
            case FungiType.Red:
            return redMush;
            case FungiType.Brown:
            return brownMush;
            case FungiType.Purple:
            return purpleMush;
            case FungiType.Green:
            return greenMush;
            case FungiType.DarkRed:
            return darkredMush;
            default:
            return redMush;
        }
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
