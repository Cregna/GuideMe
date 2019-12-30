using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadType : MonoBehaviour
{
    public string roadName;
    public string roadType;
    public Sprite icon;
    public RoadType(string newroadName, string newroadtype, Sprite newicon) {
        roadName = newroadName;
        roadType = newroadtype;
        icon = newicon;
    }

}
