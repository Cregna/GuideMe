using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfo : MonoBehaviour
{
    
    public Transform carposition;
    public Text score;
    public Text time;
    private float seconds;
    private Vector3 lastposition;
    private float distance;

    // Start is called before the first frame update

    
    void Start()
    {
        lastposition = carposition.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance += Vector3.Distance(carposition.position, lastposition);
        lastposition = carposition.position;
        seconds = (int) (Time.time % 60f);
        time.text = "TIME: " + seconds;
        score.text = "SCORES: " + (int)distance;

    }
}
