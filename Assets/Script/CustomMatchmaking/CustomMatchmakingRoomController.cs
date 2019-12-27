using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;
using UnityEngine.UI;

public class CustomMatchmakingRoomController : MonoBehaviourPunCallbacks,IOnEventCallback
{
    
    [SerializeField]
    private GameObject lobbyPanel; //display for when in lobby
    [SerializeField]
    private GameObject roomPanel; //display for when in room
    
    [SerializeField]
    private GameObject startButton; //only for the master client. used to start the game and load the multiplayer scene

    [SerializeField]
    private Transform playersContainer; //used to display all the players in the current room
    [SerializeField]
    private GameObject playerListingPrefab; //Instantiate to display each player in the room

    [SerializeField]
    private Text roomNameDisplay; //display for the name of the room

    [SerializeField] private GameObject readyButton;
    [SerializeField] private Text readytext;
    private bool _ready = false;

    private string role;

    private void Awake()
    {
        role = Testmulplayer.Role;
        _ready = false;
    }

    void ClearPlayerListings()
    {
        for (int i = playersContainer.childCount - 1; i >= 0; i--) //loop through all child object of the playersContainer, removing each child
        {
            Destroy(playersContainer.GetChild(i).gameObject);
        }
    }

    void ListPlayers() 
    {

        foreach (Player player in PhotonNetwork.PlayerList) //loop through each player and create a player listing
        {
            GameObject tempListing = Instantiate(playerListingPrefab, playersContainer);
            Text tempText = tempListing.transform.GetChild(0).GetComponent<Text>();
            tempText.text = player.NickName;
        }
        
    }



    public void OnSetState()
    {            
        _ready = !_ready;
        if (_ready) readytext.text = "Not Ready";
        else readytext.text ="Ready";
        byte evCode = 1; // Custom Event 1: Used as "MoveUnitsToTargetPosition" event
        object[] content = new object[] {(bool)_ready }; // Array contains the target position and the IDs of the selected units
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.MasterClient }; // You would have to set the Receivers to All in order to receive this event on the local client as well
        SendOptions sendOptions = new SendOptions { Reliability = true };
        PhotonNetwork.RaiseEvent(evCode, content, raiseEventOptions, sendOptions);
        
    }
    
    
    
    public void OnEvent(EventData photonEvent)
    {
        object[] data = (object[])photonEvent.CustomData;

        if (PhotonNetwork.IsMasterClient)
        {
            byte eventCode = photonEvent.Code;
            bool received = (bool)data[0];
            if (eventCode == 1)
            {
                if (received)
                    startButton.SetActive(true);
                else
                    startButton.SetActive(false);

            }
        }
    }
    
    public override void OnJoinedRoom()//called when the local player joins the room
    {
        _ready = false;
        roomPanel.SetActive(true); //activate the display for being in a room
        lobbyPanel.SetActive(false); //hide the display for being in a lobby
        roomNameDisplay.text = PhotonNetwork.CurrentRoom.Name; //update room name display
        ListPlayers();
        if (!PhotonNetwork.IsMasterClient) //if master client then activate the start button
        {
            readyButton.SetActive(true);
        }
        else
        {
            readyButton.SetActive(false);
        }
        //photonPlayers = PhotonNetwork.PlayerList;
        ClearPlayerListings(); //remove all old player listings
        ListPlayers(); //relist all current player listings
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) //called whenever a new player enter the room
    {
        ClearPlayerListings(); //remove all old player listings
        ListPlayers(); //relist all current player listings
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)//called whenever a player leave the room
    {
        ClearPlayerListings();//remove all old player listings
        ListPlayers();//relist all current player listings
        if (PhotonNetwork.IsMasterClient)//if the local player is now the new master client then we activate the start button
        {
            startButton.SetActive(false);
        }
    }

    public void StartGameOnClick() //paired to the start button. will load all players into the multiplayer scene through the master client and AutomaticallySyncScene
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false; //Comment out if you want player to join after the game has started
            PhotonNetwork.LoadLevel("OnlineGame");
            
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
//        if (PhotonNetwork.IsMasterClient)
//        {
//            readytext.text = "Ready";
//            readyButton.SetActive(false);
//            startButton.SetActive(true);
//        }
        lobbyPanel.SetActive(true);
        roomPanel.SetActive(false);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        StartCoroutine(rejoinLobby());
        
    }

    IEnumerator rejoinLobby()
    {
        yield return new WaitForSeconds(1);
        PhotonNetwork.JoinLobby();
    }

    public void BackOnClick() // paired to the back button in the room panel. will return the player to the lobby panel.
    {   ClearPlayerListings();
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsVisible = false;
        }
        lobbyPanel.SetActive(true);
        roomPanel.SetActive(false);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        StartCoroutine(rejoinLobby());
    }

    
}
