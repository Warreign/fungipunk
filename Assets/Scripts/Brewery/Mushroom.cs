using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mushroom : MonoBehaviour
{

    [SerializeField]
    private InputActionReference mousePosAction;

    public enum FungiType
    {
        Purple,
        Red,
        Green,
        Brown,
        DarkRed

    };

    public bool isFollow = false;

    public FungiType type = FungiType.Red;

     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollow)
        {

            var mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosAction.action.ReadValue<Vector2>());
            mouseWorldPos.z = 0f;
            // gameObject.transform.position = mouseWorldPos;

            var rb = gameObject.GetComponent<Rigidbody2D>();
            rb.MovePosition(Vector2.MoveTowards(rb.position, mouseWorldPos, 0.9f));
        }
    }

    void OnMouseUp()
    {
        isFollow = false;
    }

    void OnMouseDown()
    {
        isFollow = true;
    }

    // void OnMouseDrag()
    // {

    // }

}
