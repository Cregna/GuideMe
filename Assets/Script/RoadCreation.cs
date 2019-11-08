using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadCreation : MonoBehaviour
{
    [SerializeField] private GameObject imge;
    public delegate void ChangeRoad();
    public static event ChangeRoad changeRoadEvent;
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
    [SerializeField] Text txt;
    float currentTime=0.01f;
    float startingTime=5f;
    static bool flag=true;
    float acceleration=1;
    //inrease speed 
    static float speed=1;

    // Start is     called before the first frame update
    private void Awake()
    {
        next_road_position=GetComponent<Transform>();
        //        _tr.GetComponents<Transform>();

    }


    void Start()
    {
        currentTime = startingTime;

        next_road_position.position = vector3;
       rotator= Quaternion.Euler(0f, 0f, 0f);
        //GameObject go = ObjectPoolingManager.Instance.GetObject(straight.name);
        //go.transform.position =  vector3;
        // go.transform.rotation = Quaternion.identity;

    }

    // Update is called once per frame
    void Update()
    {
       
            currentTime -= acceleration * Time.deltaTime;
            txt.text = currentTime.ToString("f1");

        if (currentTime <= 0) {
            currentTime = 0f;
            imge.SetActive(true);
            //set active gameover image
        }

        if (flag == true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
                {
                    name_road(0);
                    print("we here" + RandomRoadChooser.choose[0].roadName.ToString());

                    GameObject go = ObjectPoolingManager.Instance.GetObject(RandomRoadChooser.choose[0].roadName.ToString());
                    print("we here" + next_road_position.position);
                    n++;
                    go.tag = n.ToString();
                    go.transform.position = next_road_position.position + vector3;
                    go.transform.rotation = rotator;
                    next_road_position.position = go.gameObject.transform.GetChild(1).position;

                    DeleteRoad.CleanRoad();
                    RoadRotator.rotator();

                    currentTime = startingTime;
                    if (acceleration <= 2.5f) {
                        acceleration = acceleration * 1.1f;
                    }
                   // acceleration=
                    flag = false;
                    StartCoroutine(nextDelay());
                    print(n);
                 //   acceleration=ac
                    if (changeRoadEvent != null)
                        changeRoadEvent();
                    
                }
            }
            if (Input.GetKeyDown(KeyCode.N))
            {

                if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
                {
                    name_road(1);
                    print("we here" + RandomRoadChooser.choose[1].ToString());
                    GameObject go = ObjectPoolingManager.Instance.GetObject(RandomRoadChooser.choose[1].roadName.ToString());
                    n++;
                    go.tag = n.ToString();
                    go.transform.position = next_road_position.position + vector3;
                    go.transform.rotation = rotator;
                    next_road_position.position = go.gameObject.transform.GetChild(1).position;
                    DeleteRoad.CleanRoad();
                    RoadRotator.rotator();
                    currentTime = startingTime;
                    if (acceleration <= 2.5f)
                    {
                        acceleration = acceleration * 1.1f;
                    }
                    flag = false;
                    StartCoroutine(nextDelay());
                    print("Hey, carutine");

                    if (changeRoadEvent != null)
                        changeRoadEvent();
                    
                }
            }
            if (Input.GetKeyDown(KeyCode.M))
            {

                if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
                {
                    name_road(2);
                    print("we here" + RandomRoadChooser.choose[2].ToString());
                    GameObject go = ObjectPoolingManager.Instance.GetObject(RandomRoadChooser.choose[2].roadName.ToString());
                    n++;
                    go.tag = n.ToString();
                    go.transform.position = next_road_position.position + vector3;
                    go.transform.rotation = rotator;
                    next_road_position.position = go.gameObject.transform.GetChild(1).position;
                    DeleteRoad.CleanRoad();
                    RoadRotator.rotator();
                    currentTime = startingTime;
                    if (acceleration <= 2.5f)
                    {
                        acceleration = acceleration * 1.1f;
                    }

                    flag = false;
                    StartCoroutine(nextDelay());
                    print(n);
                    if (changeRoadEvent != null)
                        changeRoadEvent();
                    
                }
            }
        }
    }

    IEnumerator nextDelay() { 
        yield return new WaitForSeconds(2*speed);
        speed = speed*0.9f;
        flag = true;
        print("Hey, carutine bitch");

    }
    private void name_road(int i)
    {
       direction= RandomRoadChooser.choose[i].roadName.ToString();
    }
}
