using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Mushroom;

public class Cauldron : MonoBehaviour
{

    [SerializeField]
    private GameObject inside;
    private SpriteRenderer brewRenderer;
    private Brew currentBrew;


    [Serializable]
    private struct FungiCount
    {
        public FungiType type;
        public int count;
    }

    [Serializable]
    private struct Potion
    {
        public string name;
        public FungiCount[] mushrooms;
    }

    // Start is called before the first frame update

    [SerializeField]
    private Potion[] potions;

    void Start()
    {
        // startBrew();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        AddMushroom(other.gameObject.GetComponent<Mushroom>());
        Destroy(other.gameObject);
    }

    public void AddMushroom(Mushroom mushy)
    {
        // Debug.Log(mushy);
        currentBrew.AddMushroom(mushy);
        brewRenderer.color = currentBrew.GetColor();
        StartCoroutine(ChangeColor(currentBrew.GetColor()));
    }

    public void DiscardBrew()
    {
        Debug.Log("Discarding brew");
        currentBrew = null;
        inside.SetActive(false);
    }

   

    public void startBrew()
    {
        if (currentBrew != null)
        {
            return;
        }
        Debug.Log("Starting new brew");

        currentBrew = new Brew();

        inside.SetActive(true);
        brewRenderer = inside.GetComponent<SpriteRenderer>();
        brewRenderer.color = currentBrew.GetColor();

    }

    private IEnumerator ChangeColor(Color newColor)
    {
        float tick = 0f;
        Color oldColor = brewRenderer.color;
        while (brewRenderer.color != newColor)
        {
            tick += Time.deltaTime * 0.001f;
            brewRenderer.material.color = Color.Lerp(oldColor, newColor, tick);
            yield return null;
        }
    }

    public void finishBrew()
    {
        if (currentBrew == null)
        {
            Debug.Log("No brew");
            return;
        }

        bool finished = false;

        foreach (var p in potions)
        {
            if (Array.Exists(p.mushrooms, m => currentBrew.content[m.type] != m.count)) 
            {
                continue;
            }
            else
            {
                Debug.Log("Finished brew with result: " + p.name);
                finished = true;
                break;
            }
        }

        DiscardBrew();
    }

}
