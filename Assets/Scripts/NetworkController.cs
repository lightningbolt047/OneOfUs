using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using System.Linq;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public static NetworkController Instance;

    [SerializeField] TMP_InputField roomNameInputField;
	[SerializeField] TMP_Text errorText;
	[SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
	[SerializeField] GameObject roomListItemPrefab;
    [SerializeField] Transform playerListContent;
	[SerializeField] GameObject PlayerListItemPrefab;
	[SerializeField] GameObject startGameButton;
	private List<string> availableNames = new List<string> { "Player1", "Player2", "Player3", "Player4" };

 	void Awake()
	{
		Instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();
        
    }

    public override void OnConnectedToMaster() {
        Debug.Log("We are connected to "+ PhotonNetwork.CloudRegion);
        PhotonNetwork.JoinLobby();

		// sync scene for all players
		PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby() {
        MenuManager.Instance.OpenMenu("lobby");		
		int randomIndex = Random.Range(0, availableNames.Count);
		string selectedName = availableNames[randomIndex];
		availableNames.RemoveAt(randomIndex);
		PhotonNetwork.NickName = selectedName;
		Debug.Log("Joined lobby with nickname: " + selectedName);
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

	public void JoinRoom(RoomInfo info)
	{
		PhotonNetwork.JoinRoom(info.Name);
		MenuManager.Instance.OpenMenu("loading");
	}
	public override void OnJoinedRoom()
	{
		MenuManager.Instance.OpenMenu("room");
		roomNameText.text = PhotonNetwork.CurrentRoom.Name;

		Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;

		foreach(Transform child in playerListContent)
		{
			Destroy(child.gameObject);
		}

		for(int i = 0; i < players.Count(); i++)
		{
			Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
		}

		// set the start game button active only for the host
		startGameButton.SetActive(PhotonNetwork.IsMasterClient);
	}

	// TODO: If the host leaves the game some other player should be able to start the game.
	public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
	{
		startGameButton.SetActive(PhotonNetwork.IsMasterClient);
	}

    public override void OnCreateRoomFailed(short returnCode, string message)
	{
		errorText.text = "Room Creation Failed: " + message;
		Debug.LogError("Room Creation Failed: " + message);
		MenuManager.Instance.OpenMenu("error");
	}

	public void StartGame() {
		PhotonNetwork.LoadLevel(2);
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

	public override void OnRoomListUpdate(List<RoomInfo> roomList)
	{
		foreach(Transform trans in roomListContent)
		{
			Destroy(trans.gameObject);
		}

		for(int i = 0; i < roomList.Count; i++)
		{
			if(roomList[i].RemovedFromList)
				continue;
			Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
		}
	}

	public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
	{
		Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
	}

}
