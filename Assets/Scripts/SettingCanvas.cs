using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject mapPanel;
    public GameObject character;
    public bool panelVisible=false;
    
    //Fun
  
    void Start()
    {
       // timer= GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
         OpenCanvas();
    }
    void OpenCanvas()
    {
        if (Input.GetKey(KeyCode.B))
        {
                panel.SetActive(true);
                panelVisible = true;
                character.GetComponent<CharacterController>().enabled = false;
                //timer.SetCanvasOpen(true);
            
        }
        
    }
        public void OnResumeButtonClicked()
    {
    
       
        // Resume the game
        panel.SetActive(false);
        mapPanel.SetActive(false);
        panelVisible = false;
        character.GetComponent<CharacterController>().enabled = true;
        
    }

    public void OnMapButtonClicked()
    {
        // Open the map scene
        //SceneManager.LoadScene("MapScene");
            mapPanel.SetActive(true);
            panel.SetActive(false);
            Debug.Log("Map");
    }

    public void OnQuitButtonClicked()
    {
        // Quit the game
        Application.Quit();
    }
    
}
