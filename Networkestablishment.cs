using UnityEngine;
using System.Collections;

public class Networkestablishment : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("1.0");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
	//	GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString);
	}
	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom();


	}
	void OnPhotonRandomJoinFailed(){
		Debug.Log ("Cannot join room!");
		PhotonNetwork.CreateRoom ("TestRoom");
	}
	void OnCreatedRoom(){
		Debug.Log ("Room created!");

	}
	void OnJoinedRoom(){
		GameObject monster = PhotonNetwork.Instantiate("Player1", new Vector3(0,1,0), Quaternion.identity, 0);
		monster.GetComponent<CameraandMovement>().enabled = true;
	}

}
