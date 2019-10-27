using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(deleteFirst());
        
    }

    IEnumerator deleteFirst()
    {
        print("Here broo");
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("start");
        foreach (GameObject gm in gameObjectArray)
        {
            print(gm.ToString() + "dsd");
            gm.SetActive(false);

        }


        yield return new WaitForSeconds(3);
            }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CleanRoad() {
        print("Your n is " + RoadCreation.n);
        if (RoadCreation.n == 3)
        {

            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("1");
            print(gameObjectArray);
            foreach (GameObject gm in gameObjectArray)
            {
                gm.SetActive(false);
                RoadCreation.n = 0;
                
            }
        }
        if (RoadCreation.n == 2)
        {
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("3");
            foreach (GameObject gm in gameObjectArray)
            {
                gm.SetActive(false);


            }

        }

        if (RoadCreation.n == 1)
        {
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("2");
            foreach (GameObject gm in gameObjectArray)
            {
                gm.SetActive(false);


            }
        }

    } 
}
