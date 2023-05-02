using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrashCanvas : MonoBehaviour
{
    public GameObject textMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject trash = GameObject.Find("Trash");
        if(trash == null){
            textMessage.SetActive(true);
        }
    }
}
