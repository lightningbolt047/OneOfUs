using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wire : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    /* private GameObject currentGameObject;
    GameObject character;
    bool grabEnabled = false, pointerOverButton = false;
    PointerEventData pointerData;
 */
    // Start is called before the first frame update
    void Start()
    {
        
    }

   /*  // Update is called once per frame
    void Update()
    {
        Debug.Log("In Wire.cs");
        Debug.Log(gameObject.transform.parent.gameObject.name);
        character = GameObject.Find("Character");
        if(pointerOverButton && Input.GetButton("js4")){ //e - js4 // js1 - b
            Debug.Log("Trying to grab");
            SetGrab(true);
            character.GetComponent<CharacterMovement>().enabled = false;
        }

        if(grabEnabled){
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(pointerData.position.x, pointerData.position.y,-Camera.main.transform.position.z-5f));
            currentGameObject.transform.position = mousePosition;
        }

        if(grabEnabled && Input.GetButton("js4")){ //f - js5 // js0 - a
            Debug.Log("Letting go of grab");
            
            SetGrab(false);
            character.GetComponent<CharacterMovement>().enabled = true;
        } 
    } */

    private void onMouseDrag(){
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        //update wire
        //update position
        transform.position = newPosition;
    }

    /* public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Debug.Log("Wire.cs: On Pointer Enter");
        
        SetPointerData(pointerEventData);
        SetPointerOverButton(true);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {

        SetPointerOverButton(false);
    }

    public void SetCurrentGameObject(GameObject gameObject){
        currentGameObject = gameObject;
    }

    public void SetGrab(bool enabled){
        grabEnabled = enabled;
    }

    void SetPointerData(PointerEventData data){
        pointerData = data;
    }

    void SetPointerOverButton(bool enabled){
        pointerOverButton = enabled;
    } */

}
