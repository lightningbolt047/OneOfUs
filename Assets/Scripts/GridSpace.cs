using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI buttonText;

    private GameController gameController;
    
    public void SetSpace(){
        Debug.Log("In SetSpace mtd");
        Debug.Log(gameController.playerMove);
        if(gameController.playerMove == true && Input.GetButton("js0")){
            Debug.Log("In SetSpace IF");
            buttonText.text = gameController.GetPlayerSide();
            button.interactable = false;
            gameController.EndTurn();
        }
    }

    public void SetGameControllerReference(GameController controller){
        gameController = controller;
    }
}
