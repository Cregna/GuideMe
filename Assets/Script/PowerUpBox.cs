using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpBox : MonoBehaviour
{
    public float percentage;
    public float pushforce;
    public bool txtui;
    int n = 0;
    public delegate void ChangeText();
    public static event ChangeText changetext;
    public delegate void ChangeText2();
    public static event ChangeText2 changetext2;
    // Start is called before the first frame update



    void Start()
    {


        print("sSAAAAAAAAAAAAAAAAAAAAAA" + RandomRoadChooser.spdup);
        n++;
      
        if ((RandomRoadChooser.spdup == true)&&(n==3))
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            print(gameObject.transform.GetChild(1).gameObject.active);
            n = 0;
        }
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var heading  = transform.parent.GetChild(3).position - transform.parent.GetChild(2).position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        Debug.Log("CAR ENTER");
        GameObject go = GameObject.FindGameObjectWithTag("Player"); 
        go.GetComponent<Rigidbody>().AddForce(direction * pushforce, ForceMode.Acceleration);
    }
}
