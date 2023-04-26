using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ApplicationQuit();
    }
    void ApplicationQuit(){
        if (Input.GetKey(KeyCode.P)){
            Debug.Log("here");
            Application.Quit();
        }
    }
}
