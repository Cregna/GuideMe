using Photon.Pun;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    // This script will be added to any multiplayer scene
    void Start()
    {
        CreatePlayer(); //Create a networked player object for each player that loads into the multiplayer scenes.
    }

    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        string role = PlayerPrefs.GetString("role");
        if (role.Equals("DRIVER"))
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Car"), new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "CarCameraRig"), new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        }
        else
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TopViewCamera"), new Vector3(0, 25, -16), new Quaternion(0,0,0,0));
        }
    }
}
