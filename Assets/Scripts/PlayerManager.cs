using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using System.IO;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerManager : MonoBehaviour
{
	PhotonView PV;
	public Material pink;
	public Material red;
	public Material blue;
	public Material yellow;
	public Material green;	

	GameObject controller;
	List<Vector3> spawnPosition = new List<Vector3> {
    	new Vector3(235.0f, 9.699999809265137f, 109.4000015258789f),
    	new Vector3(216.58311462402345f, 1.0799999237060547f, 141.476318359375f),
		new Vector3(68.49115f, 1.0799999237060547f, 102.476318359375f),
		new Vector3(251.49115f, 1.0799999237060547f, 115.476318359375f),
		new Vector3(228.49115f, 1.0799999237060547f, 238.476318359375f)
	};
	int kills;
	int deaths;

	void Awake()
	{
		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		if (PV.IsMine) {
			CreateController();
		}
	}

	void CreateController()
	{
		int randomIndex = Random.Range(0, spawnPosition.Count);
		Vector3 randomSpawnPosition = spawnPosition[randomIndex];
		spawnPosition.RemoveAt(randomIndex);
		GameObject prefabInstance = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "gamer"), randomSpawnPosition, Quaternion.identity, 0, new object[] { PV.ViewID });
		prefabInstance.name = PhotonNetwork.NickName;
		Debug.Log(prefabInstance.name);
		Transform childTransform = prefabInstance.transform.Find("amongus");
		if(childTransform == null) {
			Debug.Log("Empty");
		}
		Renderer childRenderer = childTransform.GetComponent<Renderer>();
		if (PhotonNetwork.NickName == "pink") {
			childRenderer.material = pink;
		} else if(PhotonNetwork.NickName == "red") {
			childRenderer.material = red;
		} else if(PhotonNetwork.NickName == "blue") {
			childRenderer.material = blue;
		} else if(PhotonNetwork.NickName == "green") {
			childRenderer.material = green;
		} else if(PhotonNetwork.NickName == "yellow") {
			childRenderer.material = yellow;
		}
		// childRenderer.material = Resources.Load<Material>(PhotonNetwork.NickName);
        // PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "gamer"), new Vector3(235.0f,9.699999809265137f,109.4000015258789f), Quaternion.identity);
		Debug.Log("Player " + PhotonNetwork.NickName + " is instantied");
		
		// Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
		// controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "gamer"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
	}

	public void Die()
	{
		PhotonNetwork.Destroy(controller);
		CreateController();

		deaths++;

		Hashtable hash = new Hashtable();
		hash.Add("deaths", deaths);
		PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
	}

	public void GetKill()
	{
		PV.RPC(nameof(RPC_GetKill), PV.Owner);
	}

	[PunRPC]
	void RPC_GetKill()
	{
		kills++;

		Hashtable hash = new Hashtable();
		hash.Add("kills", kills);
		PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
	}

	public static PlayerManager Find(Photon.Realtime.Player player)
	{
		return FindObjectsOfType<PlayerManager>().SingleOrDefault(x => x.PV.Owner == player);
	}
}