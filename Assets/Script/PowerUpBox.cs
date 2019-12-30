using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpBox : MonoBehaviour
{
    public float percentage;
    public float pushforce;
    // Start is called before the first frame update



    void Start()
    {
        if (Random.value > percentage)
        {
            gameObject.SetActive(true);
        }
        else
        { 
            gameObject.SetActive(false);
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
