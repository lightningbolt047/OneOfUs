using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeAction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public bool pannelClose = false;
    public GameObject character;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FixedUpdate();
         
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.O) && gameObject.name=="Resume")
        {
            panel.SetActive(false);
            character.GetComponent<CharacterController>().enabled = true;
            pannelClose = true;
        
        }
    }
}
