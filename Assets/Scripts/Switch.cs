using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject up;
    public GameObject on;
    public bool isOn;
    public bool isUp;
    // Start is called before the first frame update
    void Start()
    {
        on.SetActive(isOn);
        up.SetActive(isUp);
        if(isOn){
            // add point to BG game object
            Main.Instance.SwitchChange(1);
        }
    }

    // triggered when you click mouse and it is over a collider
    // currenlty configured with pointer click event trigger on prefab!
    public void onMouseUp(){
        if(Input.GetButton("Submit")){
            isUp = !isUp;
            isOn = !isOn;
            on.SetActive(isOn);
            up.SetActive(isUp);
            if(isOn){
                Main.Instance.SwitchChange(1);
            } else{
                Main.Instance.SwitchChange(-1);
            }
            // Main.Instance.SwitchChange(isOn ? 1 : -1);
        }
    }
}
