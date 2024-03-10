using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static FallingMushroom;
using System;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    System.Random rnd = new System.Random();
    // public GameObject mushroom;
    public GameObject[] prefabs;
    [Serializable]
    public struct fungiSText_t {
        public FungiType name;
        public TextMeshProUGUI text;
    }

    public fungiSText_t[] fungiSText;
    public Dictionary<FungiType, TextMeshProUGUI> fungiSTextDict;
    public TextMeshProUGUI countM;
    public GameObject endPanel;
    public int waitTime = 1;
    public int mushroomSpawnCount = 30;
    public int mushroomInventory = 15;
    public int catchedMushroomCount = 0;
    private int count = 0;
    private bool isEnd = false;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        fungiSTextDict = new Dictionary<FungiType, TextMeshProUGUI>();
        for(int i = 0; i < 5; i++){
            fungiSTextDict.Add(fungiSText[i].name, fungiSText[i].text);
        }

        StartCoroutine(MushroomWaitCoroutine());
    }

    IEnumerator MushroomWaitCoroutine()
    {
        while(count < mushroomSpawnCount){
            yield return new WaitForSeconds(waitTime);
            if(isEnd)
                break;
            GenerateMushroom();
        }

        isEnd = true;
        endPanel.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(isEnd){
            return;
        }

        FungiType funghiType = col.gameObject.GetComponent<FallingMushroom>().fungiType;
        if (!PlayerPrefs.HasKey(funghiType.ToString()))
            PlayerPrefs.SetInt(funghiType.ToString(), 0);

        PlayerPrefs.SetInt(funghiType.ToString(), PlayerPrefs.GetInt(funghiType.ToString(), 0)+1);
        fungiSTextDict[funghiType].text = PlayerPrefs.GetInt(funghiType.ToString(), 0).ToString();
        Destroy(col.gameObject);
        catchedMushroomCount++;
        if(catchedMushroomCount >= mushroomInventory){
            StopCoroutine(MushroomWaitCoroutine());
            isEnd = true;
            endPanel.SetActive(true);
        }
    }

    void GenerateMushroom(){
        int quantity = rnd.Next(1,4);
        for(int i = 0; i < quantity; i++){
            if(!isEnd){
                var tmp = Instantiate(prefabs[rnd.Next(0, 5)], new Vector3((float)(rnd.NextDouble() * (10 + 10) - 10), 5.8f, 0f), Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)));
                Destroy(tmp, 10);
                count++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKey(KeyCode.N)){
        //     GenerateMushroom();
        // }

        Vector3 pos = gameObject.transform.position;
        Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Debug.Log("Mouse x: " + mousePos.x);
        if(!isEnd)
            pos.x = mousePos.x;

        if(pos.x < -10 || pos.x > 10){
            if(pos.x < 0)
                pos.x = -10;
            else
                pos.x = 10;
        }

        gameObject.transform.position = pos;

        countM.text = catchedMushroomCount.ToString();
    }
}
