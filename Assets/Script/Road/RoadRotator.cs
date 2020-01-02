using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void rotator() {
        GameObject[] imageObject = GameObject.FindGameObjectsWithTag("image");
        switch (RoadCreation.direction) {
            case "straight":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0f, 0);
                foreach (GameObject go in imageObject) {
                    print(go.tag);
                    print(go.ToString());
                    go.transform.Rotate(0, 0f, 0f);
                }
                
                break;
            case "right45":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0f, 45f);
                print("Your rotating is"+RoadCreation.rotator);
                foreach (GameObject go in imageObject)
                {
                    print(go.tag);
                    print(go.ToString());
                    go.transform.Rotate(0, 0f, -45f);
                }

                break;
            case "right90":
                RoadCreation.rotator = RoadCreation.rotator* Quaternion.Euler(0, 0, 90f);
                print("Your rotating is" + RoadCreation.rotator);
                foreach (GameObject go in imageObject)
                {
                    print(go.tag);
                    print(go.ToString());
                    go.transform.Rotate(0, 0f, -90f);
                }

                break;
            case "left45":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0, -45f);
                print("Your rotating is" + RoadCreation.rotator);
                foreach (GameObject go in imageObject)
                {
                    print(go.tag);
                    print(go.ToString());
                    go.transform.Rotate(0, 0f, 45f);
                }

                break;
            case "left90":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0, -90f);
                print("Your rotating is" + RoadCreation.rotator);
                foreach (GameObject go in imageObject)
                {
                    print(go.tag);
                    print(go.ToString());
                    go.transform.Rotate(0, 0f, 90f);
                }

                break;
            case "left_tunnel45":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0f, -45f);
                print("lol");
                break;
            case "left_tunnel90":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0f, -90f);
                print("lol");
                break;
            case "right_tunnel90":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0f, 90f);
                print("lol");
                break;
            case "right_tunnel45":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0f, 45f);
                print("lol");
                break;
            case "loop":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0f, 0);
                print("lol");
                break;
            case "bridge":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0f, 0);
                print("lol");
                break;
            case "straightsplit":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0f, 0);
                print("lol");
                break;
            case "dirt":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0f, 0);
                print("lol");
                break;
            case "hole":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0f, 0);
                print("lol");
                break;
            

        }

        switch (RoadCreationSingle.direction)
        {
            case "straight":
                RoadCreationSingle.rotator = RoadCreationSingle.rotator * Quaternion.Euler(0, 0, 0);
                foreach (GameObject go in imageObject)
                {
                    print(go.tag);
                    print(go.ToString());
                    go.transform.Rotate(0, 0f, 0f);
                }

                break;
            case "right45":
                RoadCreationSingle.rotator = RoadCreationSingle.rotator * Quaternion.Euler(0, 0f, 45f);
                print("Your rotating is" + RoadCreationSingle.rotator);
                foreach (GameObject go in imageObject)
                {
                    print(go.tag);
                    print(go.ToString());
                    go.transform.Rotate(0, 0f, -45f);
                }

                break;
            case "right90":
                RoadCreationSingle.rotator = RoadCreationSingle.rotator * Quaternion.Euler(0, 0f, 90f);
                print("Your rotating is" + RoadCreationSingle.rotator);
                foreach (GameObject go in imageObject)
                {
                    print(go.tag);
                    print(go.ToString());
                    go.transform.Rotate(0, 0f, -90f);
                }

                break;
            case "left45":
                RoadCreationSingle.rotator = RoadCreationSingle.rotator * Quaternion.Euler(0, 0f, -45f);
                print("Your rotating is" + RoadCreationSingle.rotator);
                foreach (GameObject go in imageObject)
                {
                    print(go.tag);
                    print(go.ToString());
                    go.transform.Rotate(0, 0f, 45f);
                }

                break;
            case "left90":
                RoadCreationSingle.rotator = RoadCreationSingle.rotator * Quaternion.Euler(0, 0f, -90f);
                print("Your rotating is" + RoadCreationSingle.rotator);
                foreach (GameObject go in imageObject)
                {
                    print(go.tag);
                    print(go.ToString());
                    go.transform.Rotate(0, 0f, 90f);
                }

                break;
            
            case "left_tunnel45":
                RoadCreationSingle.rotator = RoadCreationSingle.rotator * Quaternion.Euler(0, 0f, -45f);
                print("lol");
                break;
            case "left_tunnel90":
                RoadCreationSingle.rotator = RoadCreationSingle.rotator * Quaternion.Euler(0, 0f, -90f);
                print("lol");
                break;
            case "right_tunnel90":
                RoadCreationSingle.rotator = RoadCreationSingle.rotator * Quaternion.Euler(0, 0f, 90f);
                print("lol");
                break;
            case "right_tunnel45":
                RoadCreationSingle.rotator = RoadCreationSingle.rotator * Quaternion.Euler(0, 0f, 45f);
                print("lol");
                break;
        

        }
    }
    
    public static void rotatorsingle() {
        switch (RandomRoadSinglePlayer.direction) {
            case "straight":
                RandomRoadSinglePlayer.rotator = RandomRoadSinglePlayer.rotator * Quaternion.Euler(0, 0f, 0f);
                break;
            case "right45":
                RandomRoadSinglePlayer.rotator = RandomRoadSinglePlayer.rotator * Quaternion.Euler(0, 0f, 45f);


                break;
            case "right90":
                RandomRoadSinglePlayer.rotator = RandomRoadSinglePlayer.rotator* Quaternion.Euler(0, 0f, 90f);
               

                break;
            case "left45":
                RandomRoadSinglePlayer.rotator = RandomRoadSinglePlayer.rotator * Quaternion.Euler(0, 0f, -45f);
         
                break;
            case "left90":
                RandomRoadSinglePlayer.rotator = RandomRoadSinglePlayer.rotator * Quaternion.Euler(0, 0f, -90f);
                break;
            
            case "left_tunnel45":
                RandomRoadSinglePlayer.rotator = RandomRoadSinglePlayer.rotator * Quaternion.Euler(0, 0f, -45f);
                print("lol");
                break;
            case "left_tunnel90":
                RandomRoadSinglePlayer.rotator = RandomRoadSinglePlayer.rotator * Quaternion.Euler(0, 0f, -90f);
                print("lol");
                break;
            case "right_tunnel90":
                RandomRoadSinglePlayer.rotator = RandomRoadSinglePlayer.rotator * Quaternion.Euler(0, 0f, 90f);
                print("lol");
                break;
            case "right_tunnel45":
                RandomRoadSinglePlayer.rotator = RandomRoadSinglePlayer.rotator * Quaternion.Euler(0, 0f, 45f);
                print("lol");
                break;

        }
    }
}
