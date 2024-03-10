using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Mushroom;

public class Brew : MonoBehaviour
{
    private Dictionary<FungiType, int> content;



    public void AddMushroom(Mushroom mushy)
    {
        Debug.Log("Added " + mushy.type);

        content[mushy.type] += 1;
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
