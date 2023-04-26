using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBtns : MonoBehaviour
{
    public GameObject panel;
    //public GameObject settingsCanvasObject;
    public GameObject MapPanel;
    public GameObject character;
    GameObject currentActiveButtonObject;
    // Start is called before the first frame update
    void Start()
    {
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("here:"+currentActiveButtonObject.name);
        //Debug.Log("HERE at btns");
        if (Input.GetKey(KeyCode.L)){
            
            switch(gameObject.name){
                case "Resume":
                    Debug.Log("RESUME");
                    break;
                case "Map":
                    Debug.Log("MAP");
                    Debug.Log("inMAP");
                    MapPanel.SetActive(true);
                    break;
                case "Quit":
                    Debug.Log("Quit");
                    Debug.Log("inQuit");
                    Application.Quit();
                    break;
            }
        }
        
        // if (gameObject.name=="Resume" && Input.GetKey(KeyCode.I)){
            
        // }
        // else if(gameObject.name=="Map" && Input.GetKey(KeyCode.I)){
        //     Debug.Log("MAP");
        // }
        // else if(gameObject.name=="Quit" && Input.GetKey(KeyCode.I)){
        //     Debug.Log("Quit");
        // }
        
    }
}
