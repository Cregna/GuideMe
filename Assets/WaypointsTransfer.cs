using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsTransfer : MonoBehaviour
{

    // Start is called before the first frame update

    public void Deletewaypoints()
  {
      if (transform.childCount > 2)
      {
          GameObject.Destroy(transform.GetChild(transform.childCount - 1).gameObject);
      }

  }

  public  void setwaypoints(Transform waypoint1, Transform waypoint2)
  {
      waypoint1.SetParent(transform);
      waypoint2.SetParent(transform);
  } 
}
