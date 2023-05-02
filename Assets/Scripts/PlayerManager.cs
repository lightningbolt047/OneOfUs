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
        // Debug.Log("Instantiated player controller");
		GameObject prefabInstance = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "gamer"), new Vector3(235.0f, 9.699999809265137f, 109.4000015258789f), Quaternion.identity, 0, new object[] { PV.ViewID });
		Transform childTransform = prefabInstance.transform.Find("amongus");
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