using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class RandomRoadSinglePlayer : MonoBehaviour
{
    public static string direction;
    public static int n = 0;
    static Vector3 vector3 = new Vector3(0f, 0f, 0f);
    public static Quaternion rotator;
    private static Transform next_road_position;
    
    private WaypointRoute myroute;
    
    static bool flag = true;
    float elapsed = 0f;
    public float ntime = 2f;
    [SerializeField] private GameObject waypoints;
    [SerializeField] private GameObject[] myArray;
    
    
    // Start is     called before the first frame update
    private void Awake()
    {
        next_road_position = GetComponent<Transform>();
        //        _tr.GetComponents<Transform>();

    }


    void Start()
    {
        next_road_position.position = vector3;
        rotator = Quaternion.Euler(0f, 0f, 0f);
        //GameObject go = ObjectPoolingManager.Instance.GetObject(straight.name);
        //go.transform.position =  vector3;
        // go.transform.rotation = Quaternion.identity;

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= ntime)
        {
            elapsed = elapsed % ntime;
            GenRoad();
        }

    }
     void GenRoad()
    {
        if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
        {
            int value = UnityEngine.Random.Range(0, 4);
            name_road(value);
            GameObject go = ObjectPoolingManager.Instance.GetObject(myArray[value].name);
            print("we here" + next_road_position.position);
            n++;
            go.tag = n.ToString();
            go.transform.position = next_road_position.position + vector3;
            go.transform.rotation = rotator;
            next_road_position.position = go.gameObject.transform.GetChild(1).position;
            
            //DeleteRoad.CleanRoadSingle();
            RoadRotator.rotatorsingle();
            Deletewaypoints();
            setwaypoints(go.gameObject.transform.GetChild(0), go.gameObject.transform.GetChild(1));
            myroute.UpdateNodes();

        }
    }

     private void Deletewaypoints()
     {
         if (waypoints.transform.childCount > 2)
         {
             GameObject.Destroy(waypoints.transform.GetChild(waypoints.transform.childCount - 1).gameObject);
         }

     }

     private void setwaypoints(Transform waypoint1, Transform waypoint2)
     {
         waypoint1.SetParent(waypoints.transform);
         waypoint2.SetParent(waypoints.transform);
     }
     private void name_road(int i)
     {
         direction= myArray[i].name.ToString();
     }
}
