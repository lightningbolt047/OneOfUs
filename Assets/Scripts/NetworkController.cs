using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomNameInputField;
	[SerializeField] TMP_Text errorText;
	[SerializeField] TMP_Text roomNameText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();
        
    }

    public override void OnConnectedToMaster() {
        Debug.Log("We are connected to "+ PhotonNetwork.CloudRegion);
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {
        MenuManager.Instance.OpenMenu("lobby");
        Debug.Log("Joined lobby");
    }

	public void CreateRoom()
	{
		if(string.IsNullOrEmpty(roomNameInputField.text))
		{
			return;
		}
		PhotonNetwork.CreateRoom(roomNameInputField.text);
		MenuManager.Instance.OpenMenu("loading");
	}
    
    public override void OnJoinedRoom()
	{
		MenuManager.Instance.OpenMenu("room");
		roomNameText.text = PhotonNetwork.CurrentRoom.Name;

		// Player[] players = PhotonNetwork.PlayerList;

		// foreach(Transform child in playerListContent)
		// {
		// 	Destroy(child.gameObject);
		// }

		// for(int i = 0; i < players.Count(); i++)
		// {
		// 	Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
		// }

		// startGameButton.SetActive(PhotonNetwork.IsMasterClient);
	}

    public override void OnCreateRoomFailed(short returnCode, string message)
	{
		errorText.text = "Room Creation Failed: " + message;
		Debug.LogError("Room Creation Failed: " + message);
		MenuManager.Instance.OpenMenu("error");
	}

    public void LeaveRoom()
	{
		PhotonNetwork.LeaveRoom();
        Debug.Log("Left the room");
		MenuManager.Instance.OpenMenu("loading");
	}

	public override void OnLeftRoom()
	{
		MenuManager.Instance.OpenMenu("lobby");
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
