using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_sync : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform cameraTransform=gameObject.transform.Find("Main Camera");
        gameObject.transform.rotation=cameraTransform.rotation;
        gameObject.transform.position=cameraTransform.position;
    }
}
