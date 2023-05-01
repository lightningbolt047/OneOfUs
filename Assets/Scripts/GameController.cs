using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Player{
    public Image panel;
    public TextMeshProUGUI text;
    public Button button;
}

[System.Serializable]
public class PlayerColor{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI[] buttonList;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public GameObject restartButton;
    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;
    public GameObject startInfo;
    
    private string playerSide;
    private string computerSide;
    public bool playerMove;
    public float delay;
    private int value;
    private int moveCount;


    void Awake(){
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
        moveCount = 0;
        restartButton.SetActive(false);
        playerMove = true;
    }

    void Update(){
        if(playerMove == false){
            delay += delay * Time.deltaTime;
            if(delay >= 100){
                value = Random.Range(0,8);
                if(buttonList[value].GetComponentInParent<Button>().interactable == true){
                    buttonList[value].text = GetComputerSide();
                    buttonList[value].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                }
            }
        }
    }

    void SetGameControllerReferenceOnButtons(){
        for(int i=0; i<buttonList.Length; i++){
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void SetStartingSide(string startingSide){
        if(Input.GetButton("js0")){    
            playerSide = startingSide;
            if(playerSide == "X"){
                SetPlayerColors(playerX, playerO);
                computerSide = "O";
            } else{
                SetPlayerColors(playerO, playerX);
                computerSide = "X";
            }
            StartGame();
        }
    }

    void StartGame(){
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        startInfo.SetActive(false);
    }

    public string GetPlayerSide(){
        return playerSide;
    }

    public string GetComputerSide(){
        return computerSide;
    }

    public void EndTurn(){
        // Debug.Log("End Turn is Not Implemented!");

        moveCount++ ;

        if(buttonList[0].text == playerSide && buttonList[1].text == playerSide
            && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if(buttonList[3].text == playerSide && buttonList[4].text == playerSide
            && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if(buttonList[6].text == playerSide && buttonList[7].text == playerSide
            && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if(buttonList[0].text == playerSide && buttonList[3].text == playerSide
            && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if(buttonList[1].text == playerSide && buttonList[4].text == playerSide
            && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if(buttonList[2].text == playerSide && buttonList[5].text == playerSide
            && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if(buttonList[0].text == playerSide && buttonList[4].text == playerSide
            && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if(buttonList[2].text == playerSide && buttonList[4].text == playerSide
            && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if(buttonList[0].text == computerSide && buttonList[1].text == computerSide
            && buttonList[2].text == computerSide)
        {
            GameOver(computerSide);
        }

        else if(buttonList[3].text == computerSide && buttonList[4].text == computerSide
            && buttonList[5].text == computerSide)
        {
            GameOver(computerSide);
        }

        else if(buttonList[6].text == computerSide && buttonList[7].text == computerSide
            && buttonList[8].text == computerSide)
        {
            GameOver(computerSide);
        }

        else if(buttonList[0].text == computerSide && buttonList[3].text == computerSide
            && buttonList[6].text == computerSide)
        {
            GameOver(computerSide);
        }

        else if(buttonList[1].text == computerSide && buttonList[4].text == computerSide
            && buttonList[7].text == computerSide)
        {
            GameOver(computerSide);
        }

        else if(buttonList[2].text == computerSide && buttonList[5].text == computerSide
            && buttonList[8].text == computerSide)
        {
            GameOver(computerSide);
        }

        else if(buttonList[0].text == computerSide && buttonList[4].text == computerSide
            && buttonList[8].text == computerSide)
        {
            GameOver(computerSide);
        }

        else if(buttonList[2].text == computerSide && buttonList[4].text == computerSide
            && buttonList[6].text == computerSide)
        {
            GameOver(computerSide);
        }

        else if(moveCount >= 9){
            GameOver("draw");
        }

        else{
            ChangeSides();
            delay = 10;
        }
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer){
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    void GameOver(string winningPlayer){
        SetBoardInteractable(false);
        if(winningPlayer == "draw"){
            SetGameOverText("It's a draw!");
            SetPlayerColorsInactive();
        } else{
            SetGameOverText(playerSide + " Wins!");
            
            TaskTracker.CompleteTask("Task 1");
            SceneManager.LoadScene(sceneName:"Map");
        }
        restartButton.SetActive(true);

    }

    void ChangeSides(){
        // playerSide = (playerSide=="X") ? "O" : "X";
        playerMove = (playerMove == true) ? false : true;
        // if(playerSide == "X"){
        if(playerMove == true){
            SetPlayerColors(playerX, playerO);
        } else{
            SetPlayerColors(playerO, playerX);
        }
    }

    void SetGameOverText(string textValue){
        gameOverPanel.SetActive(true);
        gameOverText.text = textValue;

    }

    public void RestartGame(){
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetPlayerButtons(true);
        SetPlayerColorsInactive();
        startInfo.SetActive(true);
        playerMove = true;
        delay = 10;
        for(int i=0; i<buttonList.Length; i++){
            buttonList[i].text = "";
        }
    }

    void SetBoardInteractable(bool toggle){
        for(int i=0; i<buttonList.Length; i++){
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetPlayerButtons(bool toggle){
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    void SetPlayerColorsInactive(){
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }
}
