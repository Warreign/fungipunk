using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Mushroom;

public class Controller : MonoBehaviour
{

    [Serializable]
    private struct FungiCount
    {
        FungiType type;
        int count;
    }

    [Serializable]
    private struct Potion
    {
        string name;
        FungiCount[] mushrooms;
    }

    // Start is called before the first frame update

    [SerializeField]
    private Potion[] potions;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
