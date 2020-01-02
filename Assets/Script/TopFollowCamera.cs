using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopFollowCamera : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public float rotation;
    public int uibox; 
    public Vector3 offset;


    private void Start()
    {
        switch (uibox)
        {
            case 1:
                target = GameObject.FindGameObjectsWithTag("spawn1")[0].transform;
                break;
            case 2:
                target = GameObject.FindGameObjectsWithTag("spawn2")[0].transform;
                break;
            case 3:
                target = GameObject.FindGameObjectsWithTag("spawn3")[0].transform;
                break;
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(rotation, 0, 0));
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
       
        //transform.LookAt(target);
    }
    
}
