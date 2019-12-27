using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public Dropdown resolutionDropdown;
    public Slider volumeslider;
    public Toggle fullscreen;
    private Resolution[] resolutions;
    

    private void Start()
    {
        if(PlayerPrefs.HasKey("Fullscreen"))
        {
            if (PlayerPrefs.GetInt("Fullscreen") == 1)
            {
                fullscreen.isOn = true;
            }
            else
            {
                fullscreen.isOn = false;
            }
        }
        if (PlayerPrefs.HasKey("MasterAudio"))
        {
            volumeslider.value = PlayerPrefs.GetFloat("MasterAudio");
        }
        resolutions = Screen.resolutions;
        if (PlayerPrefs.HasKey("MasterAudio"))
        {
            volumeslider.value = PlayerPrefs.GetFloat("MasterAudio");
        }
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                Debug.Log(Screen.currentResolution);
                currentResolutionIndex = i;
            }
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }



    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen)
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen", 0);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("mastervolume", volume);
        PlayerPrefs.SetFloat("MasterAudio", volume);
    }
    
}
