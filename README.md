# PhotonNetwork
Unity PhotonNetwork sunucu işlemleri

## Sunucuyla bağlantı kurma

```c#
PhotonNetwork.ConnectUsingSettings();
```

## Sunucu bağlantı kontrolü

```c#
public override void OnConnectedToMaster()
{
  // Sunucuya bağlanıldığında ve client hazır olduğunda çalışır.
}
```

## Lobiye bağlanma

```c#
PhotonNetwork.JoinLobby();
```

## Lobi bağlantı kontrolü

```c#
public override void OnJoinedLobby()
{
  // Lobiye bağlanıldığında çalışır.
}
```

## Nickname ayarlama

```c#
PhotonNetwork.NickName = "Melih";
```

## Oda oluşturma

```c#
PhotonNetwork.CreateRoom("Oda", new RoomOptions() {MaxPlayers = 2, IsOpen = true, IsVisible = true},TypedLobby.Default);
```

## Odaya katılma

```c#
PhotonNetwork.JoinRoom("Oda");
```

## Oda oluşturma ve katılma

```c#
PhotonNetwork.JoinOrCreateRoom("Oda", new RoomOptions() {MaxPlayers = 2, IsOpen = true, IsVisible = true},TypedLobby.Default);
```

## Oda bağlantı kontrolü

```c#
public override void OnJoinedRoom()
{
  // Odaya bağlanıldığında çalışır.
}
```

## Lobi bilgileri

```c#
PhotonNetwork.CountOfPlayers; //Lobideki oyuncu sayısı
PhotonNetwork.CountOfRooms; //Lobideki oda sayısı
PhotonNetwork.CountOfPlayersInRooms; //Odalardaki toplam oyuncu sayısı
PhotonNetwork.CountOfPlayersOnMaster; //Oda kuran toplam oynucu sayısı
```

## Hata kontrolleri

```c#
public override void OnJoinRoomFailed(short returnCode, string message)
{
  //Odaya katılırken hata aldığında çalışır.
}
public override void OnCreateRoomFailed(short returnCode, string message)
{
  //Odaya kurarken hata aldığında çalışır.
}
```

## Bağlantı kesme

```c#
PhotonNetwork.Disconnect();
```

## Yeniden bağlanma

```c#
PhotonNetwork.Reconnect();
```

## İstatistik öğrenme

```c#
PhotonNetwork.NetworkStatisticsEnabled = true; //İstatistik bilgisini aktif ediyoruz.
string istatistik = PhotonNetwork.NetworkStatisticsToString();
```

## İstatistik sıfırlama

```c#
PhotonNetwork.NetworkStatisticsReset();
```

## Ping öğrenme

```c#
string ping = PhotonNetwork.GetPing().ToString();
```
