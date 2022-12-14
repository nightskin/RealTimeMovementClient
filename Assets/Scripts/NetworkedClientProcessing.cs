using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class NetworkedClientProcessing
{

    #region Send and Receive Data Functions
    static public void ReceivedMessageFromServer(string msg)
    {
        Debug.Log("msg received = " + msg + ".");

        string[] input = msg.Split(',');
        if(input[0] == "Update")
        {
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] != string.Empty)
                {
                    if(GameObject.Find(input[i]) != null)
                    {
                        GameObject gameObject = GameObject.Find(input[i]);
                        gameObject.transform.position = new Vector3(float.Parse(input[i + 1]), float.Parse(input[i + 2]), 0);
                    }
                }
            }
        }
        else if(input[0] == "Connect")
        {
            for(int i = 1; i < input.Length; i++)
            {
                if(!GameObject.Find(input[i]) && input[i] != string.Empty)
                {
                    gameLogic.CreateCharacter(input[i]);
                }
            }
        }
        else if(input[0] == "Disconnect")
        {
            var p  = GameObject.Find(input[1]);
            GameObject.Destroy(p);
        }
    }

    static public void SendMessageToServer(string msg)
    {
        networkedClient.SendMessageToServer(msg);
    }

    #endregion

    #region Connection Related Functions and Events
    static public void ConnectionEvent()
    {
        SendMessageToServer("Connect");
    }
    static public void DisconnectionEvent()
    {
        SendMessageToServer("Disconnect");
    }
    static public bool IsConnectedToServer()
    {
        return networkedClient.IsConnected();
    }
    static public void ConnectToServer()
    {
        networkedClient.Connect();
    }
    static public void DisconnectFromServer()
    {
        networkedClient.Disconnect();
    }

    #endregion

    #region Setup
    static NetworkedClient networkedClient;
    static GameLogic gameLogic;

    static public void SetNetworkedClient(NetworkedClient NetworkedClient)
    {
        networkedClient = NetworkedClient;
    }
    static public NetworkedClient GetNetworkedClient()
    {
        return networkedClient;
    }
    static public void SetGameLogic(GameLogic GameLogic)
    {
        gameLogic = GameLogic;
    }

    #endregion

}

#region Protocol Signifiers
static public class ClientToServerSignifiers
{
    public const int asd = 1;
}

static public class ServerToClientSignifiers
{
    public const int asd = 1;
}

#endregion

