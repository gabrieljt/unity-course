using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public string serverIP = "127.0.0.1";
	public int serverPort = 7100;

	void OnGUI ()
	{
		if (uLink.Network.peerType == uLink.NetworkPeerType.Disconnected) 
		{
			serverIP = GUI.TextField (new Rect (120, 10, 100, 20), serverIP);
			serverPort = int.Parse (GUI.TextField (
				new Rect (230, 10, 40, 20), serverPort.ToString()));

			if (GUI.Button (new Rect (10, 10, 100, 30), "Connect")) 
			{
				uLink.Network.Connect (serverIP, serverPort);
				Debug.Log ("Connect request sent to Server @" +
				           serverIP + ":" + serverPort);
			}

			if (GUI.Button (new Rect (10, 50, 100, 30), "Start Server")) 
			{
				uLink.Network.InitializeServer (32, serverPort);
			}
		} 
		else 
		{
			string ipAddress = uLink.Network.player.ipAddress;
			string port = uLink.Network.player.port;
			string status;

			GUI.Label (new Rect (140, 20, 250, 40), 
			           "IP Address: " + ipAddress + ":" + port);

			if (uLink.Network.isServer)
				status = "Running as Server";
			else if (uLink.Network.isClient)
				status = "Running as Client";
			GUI.Label (new Rect (140, 60, 350, 40), status);			
		}
	}

	void uLink_OnServerInitialized ()
	{
		Debug.Log ("Server Initialized @" +
		           serverIP + ":" + serverPort);
	}

	void uLink_OnConnectedToServer ()
	{
		Debug.Log ("Connected to server @" +
		           serverIP + ":" + serverPort);
		Debug.Log ("Local Port: " + 
		           uLink.Network.player.port.ToString ());
	}

	void uLink_OnPlayerDisconnected (uLink.NetworkPlayer player)
	{
		uLink.Network.DestroyPlayerObjects (player);
		uLink.Network.RemoveRPCs (player);
	}

	void uLink_OnFailedToConnect (uLink.NetworkConnectionError error)
	{
		Debug.Log ("Failed to connect to server: " + error);
	}

	void uLink_OnPlayerConnected (uLink.NetworkPlayer player)
	{
		Debug.Log ("Player connected from: " +
		           player.ipAddress + ":" + player.port);
	}

}
