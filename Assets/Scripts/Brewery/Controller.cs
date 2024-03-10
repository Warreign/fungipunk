using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Mushroom;

public class Controller : MonoBehaviour
{

    [SerializeField]
    private Customer initialCustomer;

    private Customer currentCustomer;

    void Start()
    {
        DontDestroyOnLoad(this);

        currentCustomer = initialCustomer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
