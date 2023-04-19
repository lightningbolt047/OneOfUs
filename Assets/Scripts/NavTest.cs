using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class NavTest : MonoBehaviour
{
    public Canvas c;
    public GameObject B;
    public EventSystem eventsystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
