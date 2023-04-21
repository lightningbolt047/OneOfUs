using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoscene : MonoBehaviour
{
    //For Start Page
    public void gotoCreateJoinRoom()
    {
        SceneManager.LoadScene(sceneName: "CreateJoinRoom");
    }

    public void quitgame()   //Different from other gotoscene function but kept it here for consistency
    {
        Application.Quit();
    }

    //For Create Join Room
    public void gotoStartpage()
    {
        SceneManager.LoadScene(sceneName: "StartPage");
    }
    public void gotoLobby()
    {
        SceneManager.LoadScene(sceneName: "Lobby");
    }

    public void gotoMap()
    {
        SceneManager.LoadScene(sceneName: "Map");
    }

    public void gotoTask1()
    {
        SceneManager.LoadScene(sceneName: "Task1");
    }

    public void gotoTask2()
    {
        SceneManager.LoadScene(sceneName: "Task2");
    }
}