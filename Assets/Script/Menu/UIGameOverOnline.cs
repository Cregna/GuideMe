using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIGameOverOnline : MonoBehaviour, IOnEventCallback
{
    private bool _exit;
    private string role;
    [SerializeField] private Button retryButton;
    [SerializeField] private GameObject retryGameObject;
    [SerializeField] private Text retryText;
    [SerializeField] private GameObject readyButton;
    [SerializeField] private Text readytext;
    private bool _ready = false;
    private PhotonView photonView;


    

    private void Awake()
    {
        photonView = PhotonView.Get(this);
        _ready = false;
        _exit = false;
        role = Testmulplayer.Role;
        if (role == "GOD")
        {
            retryButton.interactable = false;
            retryText.text = "Waiting..";
        }
        else
        {
            retryGameObject.SetActive(false);
            readyButton.SetActive(true);
        }
    }

    // Start is called before the first frame update
    public void Quit()
    {
        photonView.RPC("OnExitRPC", RpcTarget.All);
        SceneManager.LoadScene("MainMenu");
    }
    
    public void OnEvent(EventData photonEvent)
    {

        byte eventCode = photonEvent.Code;

        if (eventCode == 1)
        {
            object[] data = (object[])photonEvent.CustomData;
            bool received = (bool)data[0];
            if (received)
                Quit();
            else
                return;
        }

        if (eventCode == 10)
        {
            if (role == "GOD")
            {
                object[] data = (object[])photonEvent.CustomData;
                bool received = (bool)data[0];
                if (received)
                {
                    retryText.text = "Start";
                    retryGameObject.SetActive(true);
                    retryButton.interactable = true;
                }
                else
                {
                    retryButton.interactable = false;
                    retryText.text = "Waiting..";
                }
            }

        }
        
    }
    
    
    [PunRPC]
    private void OnExitRPC()
    {
        ObjectPoolingManager.Instance.ResetPool();
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene("MainMenu");
    }

    [PunRPC]
    private void CanStart(bool ready)
    {
        if (ready)
        {

            retryText.text = "Start";
            retryGameObject.SetActive(true);
            retryButton.interactable = true;
        }
        else
        {
            retryButton.interactable = false;
            retryText.text = "Waiting..";
        }
    }

    public void OnReady()
    {
        _ready = !_ready;
        if (_ready) readytext.text = "Not Ready";
        else readytext.text ="Ready";
        photonView.RPC("CanStart",RpcTarget.Others,_ready);
//        byte evCode = 10; // Custom Event 1: Used as "MoveUnitsToTargetPosition" event
//        object[] content = new object[] {(bool)_ready }; // Array contains the target position and the IDs of the selected units
//        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All }; // You would have to set the Receivers to All in order to receive this event on the local client as well
//        SendOptions sendOptions = new SendOptions { Reliability = true };
//        PhotonNetwork.RaiseEvent(evCode, content, raiseEventOptions, sendOptions);
    
    

        
    }

    [PunRPC]
    private void RetryRPC()
    {
        PhotonNetwork.LoadLevel("OnlineGame");
    }
    
    public void Retry()
    {
        photonView.RPC("RetryRPC",RpcTarget.All);
        //FindObjectOfType<GameManager>().RestartGame();
    }
}
