using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class connect : MonoBehaviourPunCallbacks {

    public GameObject prefab;
    public Vector3 posForSpawn = new Vector3(0,1,0);
    public string gameVersion = "1";
    public static GameObject LocalPlyer;
    private string access;
    public GameObject Doctor;
    public static GameObject HostPlayer;
    public GameObject UIcon;


    // Use this for initialization
    void Start () {
        Connect();
        access = "Player";

    }
    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
           
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("connect");
        PhotonNetwork.JoinRandomRoom();
       
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("Error connect");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Connect to room");

        if (access == "Player")
        {
            LocalPlyer = PhotonNetwork.Instantiate(prefab.name, posForSpawn, Quaternion.identity, 0);
            DontDestroyOnLoad(LocalPlyer);
            UIcon.SetActive(false);
        }
        if (access == "host")
        {
            HostPlayer = PhotonNetwork.Instantiate(Doctor.name, posForSpawn, Quaternion.identity, 0);
            DontDestroyOnLoad(HostPlayer);
            UIcon.SetActive(true);
        }
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null,new RoomOptions());
        access = "host";
    }



    // Update is called once per frame
    void Update () {
		
	}
}
