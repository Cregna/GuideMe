using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseEvent : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;

    [SerializeField] private Transform carposition;

    [SerializeField] private GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (carposition.position.y < -4)
        {
            GameOverUI.SetActive(true);
        }
        
    }
}
