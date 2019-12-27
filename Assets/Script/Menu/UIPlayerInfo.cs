using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfo : MonoBehaviour
{
    
    public Text time;
    private float seconds;
    private float minute;

    // Start is called before the first frame update

    

    // Update is called once per frame
    void Update()
    {

        //minute = (int) (Time.timeSinceLevelLoad / 60f);
        //seconds = (int) (Time.timeSinceLevelLoad % 60f);
        
        var timespan = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);            
        Console.WriteLine(timespan.ToString(@"mm\:ss"));
        time.text = "TIME: " + timespan.ToString(@"mm\:ss");
//        if (minute < 1)
//        {
//            time.text = "TIME: " + seconds;
//        }
//        else
//        {
//            time.text = "TIME: " + minute+ ":" +seconds;
//
//        }

    }
}
