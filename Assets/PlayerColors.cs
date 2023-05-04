using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColors : MonoBehaviour
{
    public Material pink;
    public Material red;
    public Material blue;
    public Material yellow;
    public Material green;

    string[] colors = { "pink", "red", "blue", "green", "yellow" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void AssignColors()
    {
        GameObject character = gameObject;
        if (character == null)
        {
            return;
        }
        string name = character.GetComponent<Photon.Pun.PhotonView>().Owner.NickName;
        Transform childTransform = character.transform.Find("amongus");
        Renderer childRenderer = childTransform.GetComponent<Renderer>();
        if (name == "pink")
        {
            childRenderer.material = pink;
        }
        else if (name == "red")
        {
            childRenderer.material = red;
        }
        else if (name == "blue")
        {
            childRenderer.material = blue;
        }
        else if (name == "green")
        {
            childRenderer.material = green;
        }
        else if (name == "yellow")
        {
            childRenderer.material = yellow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //AssignColors();
    }
}
