using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool pointerInside = false;
    public bool commonInteractable = true;
    public GameObject controlAlert;

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
        var outline = gameObject.GetComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        
        outline.OutlineWidth = 5f;

        if(pointerInside)
        {
            Debug.Log("Hello");
            if (commonInteractable && !controlAlert.activeSelf)
            {
                controlAlert.SetActive(true);
                GameObject.Find("ControlAlertText").GetComponent<TMPro.TextMeshProUGUI>().text="Press OK to interact with object";
            }
            outline.OutlineColor = Color.white;
        }
        else
        {
            outline.OutlineColor = Color.clear;
        }
    }
}
