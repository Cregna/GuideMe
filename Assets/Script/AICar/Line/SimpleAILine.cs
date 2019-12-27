using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class SimpleAILine : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject Waypoint;
    public List<Transform> wayPointList;
    public float minSpeed;
    public float maxSpeed;

    public int currentWayPoint = 0; 
         Transform targetWayPoint;
         private float time;
         private float accelerationTime;
         private int cont; 
         public float speed = 4f;
     
         // Use this for initialization
         void Start ()
         {    
             wayPointList = new List<Transform>();
             wayPointList.Add(Waypoint.transform.GetChild(0));
             accelerationTime = 120f;    
             time = 0;
             cont = 1;
         }
         
         
         // Update is called once per frame
         void Update () {

             if (wayPointList.Count < Waypoint.transform.childCount)
             {
                 wayPointList.Add(Waypoint.transform.GetChild(cont));
                 cont++;
             }
             // check if we have somewere to walk
             if(currentWayPoint < this.wayPointList.Count)
             {
    
                 if(targetWayPoint == null)
                     targetWayPoint = wayPointList[currentWayPoint];
                 walk();
             }
             speed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime );
             time += Time.deltaTime ;
             deletewaypoint();
         }
     
         void walk(){
             // rotate towards the target
             transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, 2*Time.deltaTime, 0.0f);
     
             // move towards the target
             transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
     
             if(transform.position == targetWayPoint.position)
             {
//                 if (Waypoint.transform.childCount > 21)
//                 {
//                     Debug.Log(Waypoint.transform.childCount);
//                     for (int i = 0; i < 3; i++)
//                     {
//                         Destroy(Waypoint.transform.GetChild(0).gameObject);
//                         Debug.Log("waypoint gameobject count " + Waypoint.transform.childCount);
//                     }
//                     wayPointList.RemoveRange(0,3);
//                     Debug.Log("List count " + wayPointList.Count);
//                     if (currentWayPoint > 19)
//                     {
//                         currentWayPoint -= 1;
//                     }
//                     cont -= 3;
//                 }
//                 else
//                 {
                     currentWayPoint++;
                    
//                 }
                 Debug.Log("current waypoint " + currentWayPoint);
                 targetWayPoint = wayPointList[currentWayPoint];
             }
         }

         private void deletewaypoint()
         {
             if (Waypoint.transform.childCount > 22)
             {
                 for (int i = 0; i < 20; i++)
                 {
                     Destroy(Waypoint.transform.GetChild(0).gameObject);
                 }
                 wayPointList.RemoveRange(0,5);
                 cont -= 5;
                 currentWayPoint -= 5;
             }
         }

         private void OnTriggerEnter(Collider other)
         {    
             Debug.Log(other.name);
             if (other.CompareTag("Player"))
             {
                 GameOverUI.SetActive(true);
             }
         }
}
