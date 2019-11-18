using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class SimpleAILine : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject Waypoint;
    public Transform[] wayPointList;
     
         public int currentWayPoint = 0; 
         Transform targetWayPoint;
     
         public float speed = 4f;
     
         // Use this for initialization
         void Start () {
     
         }
         
         // Update is called once per frame
         void Update () {
             
             for(int i = 0; i< Waypoint.transform.childCount; i++ )
             {
                 wayPointList[i] = Waypoint.transform.GetChild(i);
             }
             // check if we have somewere to walk
             if(currentWayPoint < this.wayPointList.Length)
             {
    
                 if(targetWayPoint == null)
                     targetWayPoint = wayPointList[currentWayPoint];
                 walk();
             }
         }
     
         void walk(){
             // rotate towards the target
             transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed*Time.deltaTime, 0.0f);
     
             // move towards the target
             transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
     
             if(transform.position == targetWayPoint.position)
             {
                 currentWayPoint ++ ;
                 targetWayPoint = wayPointList[currentWayPoint];
             }
         }

         private void OnTriggerEnter(Collider other)
         {    
             
             if (other.CompareTag("Player"))
             {
                 GameOverUI.SetActive(true);
             }
         }
}
