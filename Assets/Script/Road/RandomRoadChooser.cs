﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomRoadChooser : MonoBehaviour
{
    public delegate void UpdateUI();
    public static event UpdateUI updateUI;
    public Sprite right90;
    public Sprite right45;
    public Sprite left90;
    public Sprite left45;
    public Sprite straight;
    float percentage = 0.8f;
    Vector3[] positionArray = new[] { new Vector3(1449.4f, 2201.7f, -2943.6f), new Vector3(1650.3f, 2201.7f, -2943.6f), new Vector3(1800.4f, 2201.7f, -2943.6f) };
    int index;
    public static bool spdup=false;
   public static List<RoadType> choose = new List<RoadType>();


    private void OnEnable()
    {
        RoadCreation.changeRoadEvent += chooseNewRoad;
        RoadCreationSingle.changeRoadEvent += chooseNewRoad;
        

    }

    private void OnDisable()
    {
        RoadCreation.changeRoadEvent -= chooseNewRoad;
        RoadCreationSingle.changeRoadEvent -= chooseNewRoad;
    }

    void DoStuff() {

        Debug.Log("Helooo");
    }

    // Start is called before the first frame update
    void Start()
    {
       
        chooseNewRoad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void chooseNewRoad() {

        choose.Clear();

        List<RoadType> obj = new List<RoadType> { new RoadType("straight", "straight", straight), new RoadType("left45", "left45", left45), new RoadType("right45", "right45", right45), new RoadType("left_tunnel45", "left45", left45),  new RoadType("right_tunnel45", "right45", right45), new RoadType("left90", "left90", left90), new RoadType("right90", "right90", right90), new RoadType("straightsplit", "straight", straight), new RoadType("right_tunnel90", "right90", right90), new RoadType("left_tunnel90", "left90", left90), new RoadType("dirt", "straight", straight), new RoadType("loop", "straight", straight), new RoadType("hole", "straight", straight), new RoadType("bridge", "straight", straight), new RoadType("tramp", "straight", straight) };

        for (int j = 0; j < 3; j++)
        {
            int z = 0;
            
           
            index = Random.Range(0, (obj.Count));
          
            choose.Add(new RoadType(obj[index].roadName, obj[index].roadType, obj[index].icon));
            print(obj[index].roadName);
            GameObject go = ObjectPoolingManager.Instance.GetObject(obj[index].roadName);
            print(go.gameObject.name);
            print(positionArray[j]);
            print(RoadCreationSingle.rotator);
            print(RoadCreation.rotator);

            //n++;
            //go.tag = n.ToString();
            go.transform.position = positionArray[j];
            go.tag = "chooser";
            go.transform.rotation = RoadCreation.rotator;
            GameObject textui = GameObject.Find("Text"+j);
            print(textui.ToString());
            print(Random.value);
            if (Random.value > percentage)
            {
                go.gameObject.transform.GetChild(1).gameObject.SetActive(true);
               
                print(go.gameObject.transform.GetChild(1).gameObject.active);
               
            }
            else
            {
                print(go.gameObject.transform.GetChild(1));
                go.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                print(go.gameObject.transform.GetChild(1).gameObject.active);
                
            }
            textui.GetComponent<UnityEngine.UI.Text>().text = "Normalooo";
            textui.GetComponent<UnityEngine.UI.Text>().color = Color.white;
            print("GGGGGGGGGGGGGGGG"+ go.gameObject.transform.GetChild(1));

            if (go.gameObject.transform.GetChild(1).gameObject.active == true) {
                textui.GetComponent<UnityEngine.UI.Text>().text = "Speed Up";
                textui.GetComponent<UnityEngine.UI.Text>().color = Color.blue;
                spdup = true;
            }
            obj.RemoveAt(index);



          
        }
        
        int k = 0;
        print("Your random chooser is:");
        while (k < choose.Count)
        {

            print(choose[k].roadName);
        

            k++;
        }
       if (updateUI != null)
            updateUI();
    }
}
