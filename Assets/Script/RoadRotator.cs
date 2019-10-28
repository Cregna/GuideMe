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
        switch (RoadCreation.direction) {
            case "straight":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 0f, 0f);
                break;
            case "right45":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, 45f, 0f);
                print("Your rotating is"+RoadCreation.rotator);

                break;
            case "right90":
                RoadCreation.rotator = RoadCreation.rotator* Quaternion.Euler(0, 90f, 0f);
                print("Your rotating is" + RoadCreation.rotator);

                break;
            case "left45":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, -45f, 0f);
                print("Your rotating is" + RoadCreation.rotator);

                break;
            case "left90":
                RoadCreation.rotator = RoadCreation.rotator * Quaternion.Euler(0, -90f, 0f);
                print("Your rotating is" + RoadCreation.rotator);

                break;

        }
    }
}
