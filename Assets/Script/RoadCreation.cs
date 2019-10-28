using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCreation : MonoBehaviour
{
    public static string direction;
public    static int n = 0;
    static Vector3 vector3 = new Vector3(0f, 0f, 0f);
 public   static Quaternion rotator ;
    private static  Transform next_road_position;
    public GameObject straight;
    public GameObject right45;
    public GameObject right90;
    public GameObject left45;
    public GameObject left90;


    // Start is     called before the first frame update
    private void Awake()
    {
        next_road_position=GetComponent<Transform>();
        //        _tr.GetComponents<Transform>();
    }
    void Start()
    {
        
        next_road_position.position = vector3;
       rotator= Quaternion.Euler(0f, 0f, 0f);
        //GameObject go = ObjectPoolingManager.Instance.GetObject(straight.name);
        //go.transform.position =  vector3;
        // go.transform.rotation = Quaternion.identity;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
            {
                name_road(0);
                print("we here"+ RandomRoadChooser.choose[0].ToString());
              
                GameObject go = ObjectPoolingManager.Instance.GetObject(RandomRoadChooser.choose[0].ToString());
                print("we here" + next_road_position.position);
                n++;
                go.tag = n.ToString();
                go.transform.position = next_road_position.position + vector3;
                go.transform.rotation = rotator;
                next_road_position.position = go.gameObject.transform.GetChild(1).position;
                DeleteRoad.CleanRoad();
                RoadRotator.rotator();
                print(n);
              
                }
            }
        if (Input.GetKeyDown(KeyCode.N))
        {
           
            if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
            {
                name_road(1);
                print("we here" + RandomRoadChooser.choose[1].ToString());
                GameObject go = ObjectPoolingManager.Instance.GetObject(RandomRoadChooser.choose[1].ToString());
                n++;
                go.tag = n.ToString();
                go.transform.position = next_road_position.position + vector3;
                go.transform.rotation = rotator;
                next_road_position.position = go.gameObject.transform.GetChild(1).position;
                DeleteRoad.CleanRoad();
                RoadRotator.rotator();
                print(n);

            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            
            if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
            {
                name_road(2);
                print("we here" + RandomRoadChooser.choose[2].ToString());
                GameObject go = ObjectPoolingManager.Instance.GetObject(RandomRoadChooser.choose[2].ToString());
                n++;
                go.tag = n.ToString();
                go.transform.position = next_road_position.position + vector3;
                go.transform.rotation = rotator;
                next_road_position.position = go.gameObject.transform.GetChild(1).position;
                DeleteRoad.CleanRoad();
                RoadRotator.rotator();
                print(n);

            }
        }

    }

    private void name_road(int i)
    {
       direction= RandomRoadChooser.choose[i].ToString();
    }
}
