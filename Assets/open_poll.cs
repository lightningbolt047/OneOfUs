using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class open_poll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool pointerInside = false;
    public GameObject pollMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerInside = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerInside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointerInside)
        {
            if (Input.GetButtonDown("js3"))
            {
                float distance = Vector3.Distance(gameObject.transform.position, GameObject.Find("Main Camera").transform.position);
                if (distance < 10f)
                {
                    pollMenu.SetActive(true);
                    pollMenu.GetComponent<voting>().populateCandidates();
                }
            }
        }
    }
}
