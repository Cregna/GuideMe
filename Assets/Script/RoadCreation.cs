using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCreation : MonoBehaviour
{
public    static int n = 0;
    static Vector3 vector3 = new Vector3(0f, 0f, 0f);
    public Transform next_road_position;
    public GameObject straight;
    public GameObject right45;
    public GameObject right90;
    public GameObject left45;
    public GameObject left90;


    // Start is     called before the first frame update
    private void Awake()
    {
        //        _tr.GetComponents<Transform>();
    }
    void Start()
    {
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
                print("we here"+ RandomRoadChooser.choose[0].ToString());
                GameObject go = ObjectPoolingManager.Instance.GetObject(RandomRoadChooser.choose[0].ToString());
                n++;
                go.tag = n.ToString();
                go.transform.position = next_road_position.position + vector3;
                go.transform.rotation = next_road_position.rotation;
                vector3.x = vector3.x + next_road_position.position.x;
                vector3.y = vector3.y + next_road_position.position.y;
                vector3.z = vector3.z + next_road_position.position.z;
                DeleteRoad.CleanRoad();
                print(n);
              
                }
            }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
            {
                print("we here" + RandomRoadChooser.choose[1].ToString());
                GameObject go = ObjectPoolingManager.Instance.GetObject(RandomRoadChooser.choose[1].ToString());
                n++;
                go.tag = n.ToString();
                go.transform.position = next_road_position.position + vector3;
                go.transform.rotation = next_road_position.rotation;
                vector3.x = vector3.x + next_road_position.position.x;
                vector3.y = vector3.y + next_road_position.position.y;
                vector3.z = vector3.z + next_road_position.position.z;
                DeleteRoad.CleanRoad();
                print(n);

            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
            {
                print("we here" + RandomRoadChooser.choose[1].ToString());
                GameObject go = ObjectPoolingManager.Instance.GetObject(RandomRoadChooser.choose[2].ToString());
                n++;
                go.tag = n.ToString();
                go.transform.position = next_road_position.position + vector3;
                go.transform.rotation = next_road_position.rotation;
                vector3.x = vector3.x + next_road_position.position.x;
                vector3.y = vector3.y + next_road_position.position.y;
                vector3.z = vector3.z + next_road_position.position.z;
                DeleteRoad.CleanRoad();
                print(n);

            }
        }

    }

    }
