using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class RoadCreation : MonoBehaviour
{
    public delegate void ChangeRoad();

    public bool pun;
    public static event ChangeRoad changeRoadEvent;
    public static string direction;
    public    static int n = 0;
    static Vector3 vector3 = new Vector3(0f, 0f, 0f);
    public   static Quaternion rotator ;
    private PhotonView myPhotonView;
    private static  Transform next_road_position;
    public float timeToLive;
    private List<GameObject> roadss;
    private List<GameObject> roadss2;
    private List<float> timers;
    private float time;
    [Header("Fade away road color")]
    public Color startColor;
    public Color endColor;

    [Header("Time for spawning road")] 
    public float minSpeed;
    public float overTime;    
    public float maxSpeed ;



    [Header("Road Deletion")]
    public int roadcheck;
    public int nroaddelete;

    [Header("UI")]
//    [SerializeField] private GameObject img1;
//    [SerializeField] private GameObject img2;
//    [SerializeField] private GameObject img3;
    [SerializeField]
    private GameObject UI;

    float currentTime=0.01f;
    static bool flag=true;
    float acceleration=1;
    //inrease speed 
    static float speed=1;
   public AudioClip AudioClip;

    // Start is     called before the first frame update
    private void Awake()
    {    
        myPhotonView = GetComponent<PhotonView>();
        if (myPhotonView.IsMine)
        {
            time = Time.timeSinceLevelLoad;
            Debug.Log(" TIME:" + time);
            roadss2 = new List<GameObject>();
            roadss = new List<GameObject>();
            timers = new List<float>();
//            img1.SetActive(true);
//            img2.SetActive(true);
//            img3.SetActive(true);
            UI.SetActive(true);
            next_road_position=GetComponent<Transform>();
            //        _tr.GetComponents<Transform>();
        }
        

    }
    
    void Start()
    {
        if (myPhotonView.IsMine)
        {
            time = Time.timeSinceLevelLoad;
            n = 0;
            next_road_position.position = vector3;
            rotator= Quaternion.Euler(-90f, 0f, 90f);
            //GameObject go = ObjectPoolingManager.Instance.GetObject(straight.name);
            //go.transform.position =  vector3;
            // go.transform.rotation = Quaternion.identity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (myPhotonView.IsMine)
        {
            timeToLive = Mathf.SmoothStep(maxSpeed, minSpeed, (Time.timeSinceLevelLoad / overTime ));
            currentTime -= acceleration * Time.deltaTime;

//            if (currentTime <= 0)
//            {
//                currentTime = 0f;
//                img1.SetActive(false);
//                img2.SetActive(false);
//                img3.SetActive(false);
//                GameManager.Instance.EndGame();
//                //set active gameover image
//            }

            for(int i=0; i<timers.Count; i++)
            {
                
                if (timers[i] <= 3f)
                {
                    Material[] materials = roadss2[i].GetComponent<Renderer>().materials;
                    if (materials.Length > 1)
                    {
                        materials[0].color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time,1f));
//                    materials[1].color = Color.Lerp(Color.gray, Color.black, Mathf.PingPong(Time.time,1f));
                        materials[2].color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time,1f));
                    }
                    else
                    {
                        materials[0].color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time,1f));

                    }
                }
                
                if (timers[i] <= 0f)
                {
                    if (pun)
                    {
                        if (myPhotonView.IsMine)
                        {
                            PhotonNetwork.Destroy(roadss[i]);
                        }
                    }
                    roadss2[i].SetActive(false);
                    roadss.RemoveAt(0);
                    roadss2.RemoveAt(0);
                    timers.RemoveAt(0);
                }

                
            }
            


            for(int i=0; i<timers.Count; i++)
            {
                timers[i] -= Time.deltaTime;
            }

            //if (flag == true)
            //{
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

               // }
                }
        }
    }
    

    public void mainchange(int i) {
        GameObject[] del = GameObject.FindGameObjectsWithTag("chooser");
        foreach (GameObject ro in del)
        {
            ro.SetActive(false);
            ro.tag = "Untagged";
        }
        SoundManager.instance.playSingle();
        if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
        {

            name_road(i);
            print("we here" + RandomRoadChooser.choose[i].ToString());
            GameObject go = PhotonNetwork.Instantiate(
                    Path.Combine("PhotonPrefabs", RandomRoadChooser.choose[i].roadName.ToString()),
                    next_road_position.position + vector3, rotator);
            GameObject go2=   ObjectPoolingManager.Instance.GetObject(RandomRoadChooser.choose[i].roadName.ToString());
            roadss.Add(go);
            roadss2.Add(go2);
            timers.Add(timeToLive);
            n++;
            go.tag = n.ToString();
            go.transform.position = next_road_position.position + vector3;
            go2.GetComponent<Renderer>().materials = go.GetComponent<Renderer>().materials;
            go2.transform.position = next_road_position.position + vector3;
            go.transform.rotation = rotator;
            go2.transform.rotation = rotator;

            next_road_position.position = go.gameObject.transform.GetChild(3).position;
            if (pun)
            {
                CleanRoad(roadcheck,nroaddelete);
            }
            go.SetActive(false);
            //DeleteRoad.CleanRoad();
            RoadRotator.rotator();

            flag = false;
            print(n);
            if (changeRoadEvent != null)
                changeRoadEvent();

        }
    }
    
    public void CleanRoad(int maxroad, int delete)
    {
        if (roadss.Count > maxroad)
        {
            for(int i = 0; i < delete;i++)
            {
                if (pun)
                {
                    if (myPhotonView.IsMine)
                    {
                        PhotonNetwork.Destroy(roadss[i]);
                    }
                }
                roadss2[i].SetActive(false);

            }
            roadss.RemoveRange(0,delete);
            roadss2.RemoveRange(0,delete);
        }
    }
    
    private void name_road(int i)
    {
       direction= RandomRoadChooser.choose[i].roadName.ToString();
        print(direction);
    }
}
