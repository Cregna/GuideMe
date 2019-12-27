using System;
using Photon.Pun;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    private void Awake()
    {
        CreatePlayer(); //Create a networked player object for each player that loads into the multiplayer scenes.

    }

    // This script will be added to any multiplayer scene
    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        //string role = PlayerPrefs.GetString("role");
        string role = Testmulplayer.Role;
        if (role.Equals("DRIVER"))
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Car"), new Vector3(0, 0.1f, 13), new Quaternion(0, 180, 0, 0));
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "CarCameraRig"), new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        }
       else 
        {
           PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "RoadController"), new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        }
    }
}
