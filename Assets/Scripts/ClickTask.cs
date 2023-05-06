using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickTask : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool pointerInside = false;
    public string taskSceneName;
    public GameObject tempAlertCanvas;

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
                float distance = Vector3.Distance(gameObject.transform.position,GameObject.Find("Main Camera").transform.position);
                if (distance<10f)
                {
                    SceneManager.LoadScene(sceneName: taskSceneName);
                }
                else
                {
                    tempAlertCanvas.SetActive(true);
                    GameObject.Find("TemporaryAlertText").GetComponent<TMPro.TextMeshProUGUI>().text = "Get Closer to Object";
                }
     
            }
        }
    }
}
