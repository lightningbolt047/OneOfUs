using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrabTask : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject grabObject;
    bool pointerInside = false;


    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerInside = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerInside = false;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject reticle = GameObject.Find("Reticle");

        if (pointerInside)
        {
            if (Input.GetButtonDown("js3"))
            {
                if(gameObject.transform.parent != reticle.transform)
                {
                    gameObject.transform.parent = GameObject.Find("Terrain").transform;
                    Debug.Log("Start task");
                }
            }
        }

    }
}
