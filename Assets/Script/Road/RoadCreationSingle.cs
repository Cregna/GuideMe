using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadCreationSingle : MonoBehaviour
{
    public delegate void ChangeRoad();
    public static event ChangeRoad changeRoadEvent;
    public static string direction;
    private List<GameObject> roadss;
    public    static int n = 0;
    static Vector3 vector3 = new Vector3(0f, 0f, 0f);
    public   static Quaternion rotator ;
    private static  Transform next_road_position;
    //private WaypointRoute myroute;
    private bool first = true;


    [Header("IMG")]
    [SerializeField] private GameObject img1;
    [SerializeField] private GameObject img2;
    [SerializeField] private GameObject img3;
    [Header("TXT")]
    [SerializeField] Text txt;
    float currentTime=0.01f;
    float startingTime=20f;
    static bool flag=true;
    float acceleration=1;
    //inrease speed 
    static float speed=1;
   public AudioClip AudioClip;

    // Start is     called before the first frame update
    private void Awake()
    {
        img1.SetActive(true);
        img2.SetActive(true);
        img3.SetActive(true);
        next_road_position=GetComponent<Transform>();
        roadss = new List<GameObject>();

        //        _tr.GetComponents<Transform>();

    }
    
    void Start()
    {
        currentTime = startingTime;
        n = 0;
        next_road_position.position = vector3;
       rotator= Quaternion.Euler(-90f, 0f, 90f);
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
            img1.SetActive(false);
            img2.SetActive(false);
            img3.SetActive(false);
            GameManager.Instance.EndGame();
            //set active gameover image
        }
        

        if (flag == true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                mainchange(0);

            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                mainchange(1);
                
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                mainchange(2);
               
            }
        }
    }
    public void mainchange(int i) {
        SoundManager.instance.playSingle();
        if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
        {
            print("hereee");
            name_road(i);
            print("we here" + RandomRoadChooser.choose[i].roadName.ToString());
            GameObject go = ObjectPoolingManager.Instance.GetObject(RandomRoadChooser.choose[i].roadName.ToString());
            print(go.gameObject.name);
            roadss.Add(go);
            //n++;
            //go.tag = n.ToString();
            go.transform.position = next_road_position.position + vector3;
            go.transform.rotation = rotator;
            print(go.gameObject.transform.GetChild(3));
            next_road_position.position = go.gameObject.transform.GetChild(3).position;
            //DeleteRoad.CleanRoad_god();
            //DeleteRoad.CleanRoad();
            CleanRoad(4,1);
            RoadRotator.rotator();
            currentTime = startingTime;
            //myroute.UpdateNodes();
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
    
    
    public void CleanRoad(int maxroad, int delete)
    {

        if (roadss.Count > maxroad)
        {
            if (first)
            {
                GameObject.Find("start").SetActive(false);
                first = false;
            }
            for(int i = 0; i < delete;i++)
            {
                roadss[i].SetActive(false);
            }
            roadss.RemoveRange(0,delete);
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
