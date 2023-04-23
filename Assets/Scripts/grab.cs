using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class grab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

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
                if (gameObject.transform.parent != reticle.transform)
                {
                    gameObject.transform.position = reticle.transform.position;
                    gameObject.transform.position += new Vector3(0, 0, -7);
                    gameObject.transform.parent = reticle.transform;
                }
                else
                {
                    
                }
            }

            if (Input.GetButtonDown("js1"))
            {
                gameObject.transform.parent = GameObject.Find("Terrain").transform;
            }
        }

    }
}
