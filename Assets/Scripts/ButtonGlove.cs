using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonGlove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public TextMeshProUGUI Butt;
    public void OnPointerEnter(PointerEventData eventData)
    {
    //    Debug.Log("Mouse enter");
        Butt.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("Mouse exit");
        Butt.color = Color.black;
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
