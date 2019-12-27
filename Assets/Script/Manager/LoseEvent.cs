using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseEvent : MonoBehaviour
{
    public bool pun;

// Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < -2f)
        {
            if (!pun)
            {
                GameManager.Instance.EndGame();
            }
            else
            {
                GameManager.Instance.EndGameOnline();
            }
        }
        
    }
}
