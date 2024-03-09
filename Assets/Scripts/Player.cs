using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    System.Random rnd = new System.Random();
    public GameObject mushroom;
    public int waitTime = 1;
    public int mushroomSpawnCount = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        int count = 0;

        while(count < mushroomSpawnCount){
            yield return new WaitForSeconds(waitTime);
            GenerateMushroom();
            count++;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col){
        Destroy(col.gameObject);
    }

    void GenerateMushroom(){
        int quantity = 1;
        for(int i = 0; i < quantity; i++){
            var tmp = Instantiate(mushroom, new Vector3((float)(rnd.NextDouble() * (10 + 10) - 10), 5.8f, 0f), Quaternion.identity);
            Destroy(tmp, 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.N)){
            GenerateMushroom();
        }

        Vector3 pos = gameObject.transform.position;
        Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Debug.Log("Mouse x: " + mousePos.x);
        pos.x = mousePos.x;

        if(pos.x < -10 || pos.x > 10){
            if(pos.x < 0)
                pos.x = -10;
            else
                pos.x = 10;
        }

        gameObject.transform.position = pos;
    }
}
