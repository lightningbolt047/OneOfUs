using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main Instance;

    public GameObject[] switchList;
    public int switchCount;
    public GameObject winText;
    private int onCount = 0;
    private void Awake(){
        Instance = this;
    }

    public void SwitchChange(int points){
        onCount = onCount + points;
        if(onCount == switchCount){
            winText.SetActive(true);
            SceneManager.LoadScene(sceneName:"Map");
            // DeactivateSwitches();
        }
    }

    /* void DeactivateSwitches(){
        for(int i=0; i<switchList.Length; i++){
            switchList[i].gameObject.GetComponentsInChildren<Switch>().enable = false;
        }
    } */

}
