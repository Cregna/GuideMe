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
        Debug.Log("CAR ENTER");
        GameObject go = GameObject.FindGameObjectWithTag("Player"); 
        go.GetComponent<Rigidbody>().AddForce(Vector3.forward * pushforce, ForceMode.Acceleration);
    }
}
