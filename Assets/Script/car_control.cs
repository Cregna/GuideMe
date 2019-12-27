using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_control : MonoBehaviour
{
    public float motorForce, steerForce, breakForce;

    public WheelCollider FR, FL, BL, BR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float v = Input.GetAxis("Vertical") * motorForce;
        float h = Input.GetAxis("Horizontal") * -steerForce;

        BR.motorTorque = v * 3.0f;
        BL.motorTorque = v * 3.0f;

        
        FR.steerAngle = h;
        FL.steerAngle = h;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Space))
        {
            BR.brakeTorque = breakForce;
            BL.brakeTorque = breakForce;
        }
        
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Space))
        {
            BR.brakeTorque = 0;
            BL.brakeTorque = 0;
        }

        if (Input.GetAxis("Vertical") == 0)
        {
            BR.brakeTorque = breakForce;
            BL.brakeTorque = breakForce;
        }
        else
        {
            BR.brakeTorque = 0;
            BL.brakeTorque = 0;
        }

    }
}
