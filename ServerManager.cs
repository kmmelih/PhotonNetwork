using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ServerManager : MonoBehaviourPunCallbacks
{
    public TMP_Text metin;
    private bool pingGoster = false;
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        mesajYazdir("Sunucuya bağlanıyorsun.");
    }

    private void mesajYazdir(string m)
    {
        metin.text = m;
    }

    public override void OnConnectedToMaster()
    {
        mesajYazdir("Sunucuya bağlandın.");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        mesajYazdir("Lobiye bağlandın.");
        PhotonNetwork.NickName = "Melih";
        PhotonNetwork.JoinOrCreateRoom("Oda", new RoomOptions() {MaxPlayers = 2, IsOpen = true, IsVisible = true},
            TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        mesajYazdir("Odaya bağlandın. " + PhotonNetwork.LocalPlayer.NickName);
        /*
         * PhotonNetwork.CountOfPlayers;
         * PhotonNetwork.CountOfRooms;
         * PhotonNetwork.CountOfPlayersInRooms;
         * PhotonNetwork.CountOfPlayersOnMaster;
         */
        Debug.Log("Lobi bilgisi: "+PhotonNetwork.CurrentLobby);
        Debug.Log("Oda bilgisi: "+PhotonNetwork.CurrentRoom);
        Debug.Log("Sunucu bölgesi: "+PhotonNetwork.CloudRegion);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        mesajYazdir("Odaya bağlanamadın!" + message + " - " + returnCode);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        mesajYazdir("Oda oluşturulamadı!" + message + " - " + returnCode);
    }

    public void baglantiKes()
    {
        PhotonNetwork.Disconnect();
        pingGoster = false;
    }

    public void yenidenBaglan()
    {
        PhotonNetwork.Reconnect();
    }

    public void istatistikAl()
    {
        PhotonNetwork.NetworkStatisticsEnabled = true;
        mesajYazdir(PhotonNetwork.NetworkStatisticsToString());
    }

    public void istatistikSifirla()
    {
        PhotonNetwork.NetworkStatisticsReset();
    }

    public void pingGetir()
    {
        //mesajYazdir(PhotonNetwork.GetPing().ToString());
        if (pingGoster)
        {
            pingGoster = false;
            mesajYazdir("");
        }
        else
        {
            pingGoster = true;
        }
    }

    private void Update()
    {
        if (!PhotonNetwork.IsConnected)
        {
            mesajYazdir("Bağlantı koptu!");
        }

        if (pingGoster)
        {
            mesajYazdir(PhotonNetwork.GetPing().ToString());
        }
    }
}
