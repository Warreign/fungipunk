using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{



    public enum FungiType
    {
        Purple,
        Red,
        Green,
        Brown,
        DarkRed

    };

    public FungiType type = FungiType.Red;

     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {

        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        // gameObject.transform.position = mouseWorldPos;

        var rb = gameObject.GetComponent<Rigidbody2D>();
        rb.MovePosition(Vector2.Lerp(rb.position, mouseWorldPos, 0.5f));
    }

}
