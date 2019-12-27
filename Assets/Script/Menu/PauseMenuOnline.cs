using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuOnline : MonoBehaviour
{
    private bool _exit;
    private PhotonView photonView;
    public static bool gameIsPaused = false;

    public GameObject PauseMenuUI;
    // Start is called before the first frame update
    void Start()
    { 
        photonView = PhotonView.Get(this);
        _exit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        PauseMenuUI.SetActive(true);
        gameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        gameIsPaused = false;
    }
    


    [PunRPC]
    private void OnExitRPC()
    {
        ObjectPoolingManager.Instance.ResetPool();
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene("MainMenu");
    }

    public void Back()
    {
       // OnExit();
         photonView.RPC("OnExitRPC", RpcTarget.All);
         SceneManager.LoadScene("MainMenu");
//        ObjectPoolingManager.Instance.ResetPool();
//        PhotonNetwork.LeaveRoom();
//        PhotonNetwork.LeaveLobby();
//        SceneManager.LoadScene("MainMenu");
//        gameIsPaused = false;
        
    }
}
