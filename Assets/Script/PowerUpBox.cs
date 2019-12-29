using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBox : MonoBehaviour
{

    public float pushforce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CAR ENTER");
        GameObject go = GameObject.FindGameObjectWithTag("Player"); 
        go.GetComponent<Rigidbody>().AddForce(Vector3.back * pushforce, ForceMode.Acceleration);
    }
}
