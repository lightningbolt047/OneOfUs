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
                    Destroy(gameObject.GetComponent<Rigidbody>());
                    gameObject.transform.localPosition = new Vector3(0, 0, 7);

                    //Debug.Log(gameObject.transform.rotation);
                }
                else
                {
                    gameObject.transform.parent = GameObject.Find("Terrain").transform;
                    gameObject.AddComponent<Rigidbody>();
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    /*if (gameObject.GetComponent<ConstantForce>() == null)
                    {
                        ConstantForce gravity=gameObject.AddComponent<ConstantForce>();
                        gravity.force = new Vector3(0f, -9.81f, 0f);
                    }*/


                }
            }

            if (Input.GetButtonDown("js1"))
            {
                gameObject.transform.parent = GameObject.Find("Terrain").transform;
            }
        }

    }
}
