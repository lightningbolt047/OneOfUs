using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyTrash : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject currentGameObject;
    public GameObject destroyMessageObject;
    GameObject character;
    bool pointerOverButton = false;
    PointerEventData pointerData;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("In DestroyTrash.cs");
        Debug.Log(gameObject.transform.parent.gameObject.name);
        character = GameObject.Find("Character");
        //GameObject.Find("DestroyTrashText").GetComponent<TMPro.TextMeshProUGUI>().text="Press 'A' for 3 sec to destroy trash";

        if(pointerOverButton && Input.GetButton("js0")){ //js0     //e - js4 // js1 - b
            if(timer>=2){
                Destroy(currentGameObject);
                TaskTracker.CompleteTask("Task 4");
                timer = 0f;
            } else{
                timer += Time.deltaTime;
            }
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Debug.Log("DestroyTrash.cs: On Pointer Enter");
        
        SetPointerData(pointerEventData);
        SetPointerOverButton(true);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Debug.Log("DestroyTrash.cs: On Pointer Exit");
        SetPointerOverButton(false);
    }

    public void SetCurrentGameObject(GameObject gameObject){
        currentGameObject = gameObject;
    }

    void SetPointerData(PointerEventData data){
        pointerData = data;
    }

    void SetPointerOverButton(bool enabled){
        pointerOverButton = enabled;
    }
}
