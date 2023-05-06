using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class open_poll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool pointerInside = false, mapActive = false;
    public GameObject pollMenu;
    public GameObject mapPanel;
    float timer = 0f;
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
            if (Input.GetButtonDown("js0"))
            {
                // float distance = Vector3.Distance(gameObject.transform.position, GameObject.Find("Main Camera").transform.position);
                // if ()
                // {
                //     // pollMenu.SetActive(true);
                //     // pollMenu.GetComponent<voting>().populateCandidates();
                //     // panel.SetActive(false);
                // }

                if(!mapActive){
                    mapPanel.SetActive(true);
                    mapActive = true;
                }
                

            }
        }
        if(mapActive){
            if(timer>=2){
                mapActive=false;
                mapPanel.SetActive(false);
                timer = 0f;
            } else{
                timer += Time.deltaTime;
                mapActive = true;
            }
        }
        
    }
}
