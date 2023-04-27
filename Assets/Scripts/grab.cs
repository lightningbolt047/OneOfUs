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

    void checkPosition(GameObject reticle)
    {
        if (reticle == null)
        {
            return;
        }
        if (gameObject.transform.parent == reticle.transform)
        {
            if (gameObject.transform.position != new Vector3(0,0,7))
            {
                Debug.Log("Hello");
                gameObject.transform.localPosition = new Vector3(0, 0, 7);
                Debug.Log(gameObject.transform.position);
                
            }
            gameObject.transform.rotation = Quaternion.identity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject reticle = GameObject.Find("Reticle");
        //checkPosition(reticle);

        if (pointerInside)
        {
            if (Input.GetButtonDown("js3"))
            {
                if (gameObject.transform.parent != reticle.transform)
                {
                    //gameObject.transform.position = reticle.transform.position;
                    
                    gameObject.transform.parent = reticle.transform;
                    gameObject.transform.localPosition = new Vector3(0, 0, 7);

                    //Debug.Log(gameObject.transform.rotation);
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
