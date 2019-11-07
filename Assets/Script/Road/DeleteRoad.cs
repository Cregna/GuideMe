using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
        
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CleanRoad() {
        print("Your n is " + RoadCreation.n);
        if (RoadCreation.n == 4)
        {

            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("1");
            print(gameObjectArray);
            foreach (GameObject gm in gameObjectArray)
            {
                gm.SetActive(false);
                RoadCreation.n = 0;
                
            }
        }
        if (RoadCreation.n == 3)
        {

            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("4");
            print(gameObjectArray);
            foreach (GameObject gm in gameObjectArray)
            {
                gm.SetActive(false);
             

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
    
    public static void CleanRoadSingle() {
        print("Your n is " + RandomRoadSinglePlayer.n);
        if (RandomRoadSinglePlayer.n == 4)
        {

            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("1");
            print(gameObjectArray);
            foreach (GameObject gm in gameObjectArray)
            {
                gm.SetActive(false);
                RandomRoadSinglePlayer.n = 0;
                
            }
        }
        if (RandomRoadSinglePlayer.n == 3)
        {

            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("4");
            print(gameObjectArray);
            foreach (GameObject gm in gameObjectArray)
            {
                gm.SetActive(false);
             

            }
        }
        if (RandomRoadSinglePlayer.n == 2)
        {
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("3");
            foreach (GameObject gm in gameObjectArray)
            {
                gm.SetActive(false);


            }

        }

        if (RandomRoadSinglePlayer.n == 1)
        {
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("2");
            foreach (GameObject gm in gameObjectArray)
            {
                gm.SetActive(false);


            }
        }

    } 
}
