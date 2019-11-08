using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseEvent : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;

    [SerializeField] private Transform carposition;
    // Start is called before the first frame update
    void Start()
    {
        
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
