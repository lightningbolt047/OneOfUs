using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject character;
    private bool panelVisible = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        FixedUpdate();

        if (panelVisible)
        {
            // disable character movement
            character.GetComponent<CharacterController>().enabled = false;
            FixedUpdate();
        }
        else
        {
            // enable character movement
            character.GetComponent<CharacterController>().enabled = true;
            OnPanelClose();
        }
    }
    void FixedUpdate()
    {
        Debug.Log("Here");
        if (Input.GetKey(KeyCode.B))
        {
            if (!panelVisible)
            {
                panel.SetActive(true);
                panelVisible = true;
            }
        }
    }

    public void OnPanelClose()
    {   
        if (Input.GetKey(KeyCode.V)){
            panel.SetActive(false);
            panelVisible = false;
        }
        
    }
}
