using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIGameOver : MonoBehaviour
{

    public Text difficulty;

    private void Awake()
    {
        difficulty.text = "Difficulty: " + Diffulty.Difficulty;
    }

    // Start is called before the first frame update
    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    




    public void Retry()
    {
        FindObjectOfType<GameManager>().RestartGame();
    }
}
