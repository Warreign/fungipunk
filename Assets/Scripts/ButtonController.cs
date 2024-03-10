using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void onClickExit(){
        Application.Quit();
    }

    public void onClickNewGame(){
        SceneManager.LoadScene("Brewery");
    }

    public void onClickCloseTutorial(GameObject gameObject){
        gameObject.SetActive(false);
    }

    public void onClickOpenTutorial(GameObject gameObject){
        gameObject.SetActive(true);
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
