using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResumeBtn : MonoBehaviour
{
    public GameObject Mapanel;
    void Update(){
        closeImage();
    }
    void closeImage(){
        if (Input.GetKey(KeyCode.B))
        {

            Mapanel.SetActive(false);
        }

    }
    
}
