using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown difficultDropdown;
    private void Awake()
    {
        audioMixer.SetFloat("mastervolume", PlayerPrefs.GetFloat("MasterAudio"));

    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial1");
    }
    public void PlaySingle()
    {
        switch (difficultDropdown.value)
        {
            case 0:
                Diffulty.Difficulty = "Easy";
                break;
            case 1:
                Diffulty.Difficulty = "Normal";
                break;
            case 2:
                Diffulty.Difficulty = "Hard";
                break;
            case 3:
                Diffulty.Difficulty = "Insane";
                break;
            default:
                Diffulty.Difficulty = "Normal";
                break;
        }
        
            SceneManager.LoadScene("SinglePlayer");
    }

    public void PlayDriver()
    {
        //PlayerPrefs.SetString("role", "DRIVER");
        Testmulplayer.Role = "DRIVER";
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MatchmakingMenu");
    }
    public void PlayGodGame()
    {
        //PlayerPrefs.SetString("role","GOD");
        Testmulplayer.Role = "GOD";
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MatchmakingMenu");
    }

    public void LoadMenu()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }
}
 