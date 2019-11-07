using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadType : MonoBehaviour
{
    public string roadName;
    public Sprite icon;
    public RoadType(string newroadName, Sprite newicon) {
        roadName = newroadName;
        icon = newicon;
    }

}
