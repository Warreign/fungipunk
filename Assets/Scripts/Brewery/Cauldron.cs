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
    private Brew currentBrew;

    void Start()
    {
        
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
        currentBrew.AddMushroom(mushy);
    }

    public void DiscardBrew()
    {
        currentBrew = null;
        inside.SetActive(false);
    }

    public void startBrew()
    {   
        Debug.Log("Starting new brew");
        if (!currentBrew)
        {
        }

        currentBrew = new Brew();
        inside.SetActive(true);
    }

}
