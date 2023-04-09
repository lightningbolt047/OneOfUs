using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public void gotoMap()
    {
        SceneManager.LoadScene(sceneName:"Map");
    }

    public void gotoTask1()
    {
        SceneManager.LoadScene(sceneName:"Task1");
    }

    public void gotoTask2()
    {
        SceneManager.LoadScene(sceneName:"Task2");
    }
}