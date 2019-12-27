using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopViewCamera1 : MonoBehaviour
{

    public GameObject car;        //Public variable to store a reference to the player game object
    public Camera cam;

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        string role = Testmulplayer.Role;
        Debug.Log(role);
        if (role.Equals("DRIVER"))
            cam.depth = -10;
        if (role.Equals("GOD"))
            cam.depth = 90;
        if (car)
        {
            //Calculate and store the offset value by getting the distance between the player's position and camera's position.
            offset = transform.position - car.transform.position;
        }
        else offset = transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (!car)
        {
            Debug.Log("CIAO");
            car = GameObject.FindWithTag("Player");
        }
        else
        {
            transform.position = car.transform.position + offset;
            transform.rotation = new Quaternion(transform.rotation.x,car.transform.rotation.y,transform.rotation.z, 0);
        }
    }
}

