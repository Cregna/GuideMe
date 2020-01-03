using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpBox : MonoBehaviour
{

    public bool txtui;
    int n = 0;
    public delegate void ChangeText();
    public static event ChangeText changetext;
    public delegate void ChangeText2();
    public static event ChangeText2 changetext2;
    private PhotonView photonView;

    // Start is called before the first frame update

    
    void Start()
    {

        photonView = PhotonView.Get(this);

        print("sSAAAAAAAAAAAAAAAAAAAAAA" + RandomRoadChooser.spdup);
        n++;
      
        if ((RandomRoadChooser.spdup == true)&&(n==3))
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            print(gameObject.transform.GetChild(1).gameObject.active);
            n = 0;
        }
  
    }



    [PunRPC]
    private void setPowerUp()
    {
        Debug.Log(" TRY TO CHANGE PROPERTY");
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
    
}
