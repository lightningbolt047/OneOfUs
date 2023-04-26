using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCanvas : MonoBehaviour
{
    public GameObject panel;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenMapCanvas();
    }
    void OpenMapCanvas(){
        if(Input.GetKey(KeyCode.B)){
            panel.SetActive(false);   
        }
        else if( Input.GetKey(KeyCode.K))
        {
            Debug.Log(gameObject.name);
            panel.SetActive(true);
        }
    }
}
