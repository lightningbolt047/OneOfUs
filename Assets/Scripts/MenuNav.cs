using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MenuNav : MonoBehaviour
{
    public Canvas c;
    public GameObject B;
    public EventSystem eventsystem;

    private void Update()
    {
        if (c != null && c.gameObject.activeSelf && eventsystem != null)
        {
            if (eventsystem.GetComponent<StandaloneInputModule>().enabled == false)
            {
                eventsystem.GetComponent<XRCardboardInputModule>().enabled = false;
                eventsystem.GetComponent<StandaloneInputModule>().enabled = true;
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(B);
            }
        }
    }
}