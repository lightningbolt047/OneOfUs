using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void startgame()
    {
        if (Input.GetButtonDown("js1"))
        {
            Debug.LogError("Running");
        }
    }
}