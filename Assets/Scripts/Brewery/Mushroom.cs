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

    public enum FungiType
    {
        Purple,
        Red,
        Green,
        Brown,
        DarkRed

    };

    public bool isFollow = false;

    public Sprite getSprite()
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
