using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapclose : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mapanel;
    void Start()
    {
        
    }

    // Update is called once per frame
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
