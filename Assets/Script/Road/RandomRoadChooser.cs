using System.Collections;
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
    public Material[] mat;
    public Material matdirt;

    float percentage = 0.8f;
    Vector3[] positionArray = new[]{ new Vector3(1200.4f, 2201.7f, -2943.6f), new Vector3(1650.3f, 2201.7f, -2943.6f), new Vector3(2200.4f, 2201.7f, -2943.6f) };
    int index;
    public static bool spdup=false;
    public static List<RoadType> choose = new List<RoadType>();
    private List<int> lotteryTickets = new List<int> ();
    int generatedRoads=0;
    private int speedDifficultyMultiplier = 3;
    private int startDifficultTurn = 10;
    



    private void OnEnable()
    {
        RoadCreation.changeRoadEvent += chooseNewRoad;
        // RoadCreationSingle.changeRoadEvent += chooseNewRoad;
    }

    private void OnDisable()
    {
        RoadCreation.changeRoadEvent -= chooseNewRoad;
        //RoadCreationSingle.changeRoadEvent -= chooseNewRoad;
    }


    // Start is called before the first frame update
    void Start()
    {
        
        if (generatedRoads==0)
        {
            for(int i=0; i<5; i++)
            {
                lotteryTickets.Add(0);
            }

        }
        chooseNewRoad();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void chooseNewRoad() {

        for (int i = 0; i < speedDifficultyMultiplier; i++)
            lotteryTickets.Add(1);


        if (generatedRoads >= startDifficultTurn)
        {
            for (int i = 0; i < speedDifficultyMultiplier; i++)
                lotteryTickets.Add(2);
        }

        generatedRoads += 1;

        choose.Clear();

        List<RoadType> obj = new List<RoadType> { new RoadType("straight", "straight", straight), new RoadType("left45", "left45", left45), new RoadType("right45", "right45", right45), new RoadType("left_tunnel45", "left45", left45),  new RoadType("right_tunnel45", "right45", right45), new RoadType("left90", "left90", left90), new RoadType("right90", "right90", right90), new RoadType("straightsplit", "straight", straight), new RoadType("right_tunnel90", "right90", right90), new RoadType("left_tunnel90", "left90", left90), new RoadType("dirt", "straight", straight), new RoadType("loop", "straight", straight), new RoadType("hole", "straight", straight), new RoadType("bridge", "straight", straight), new RoadType("tramp", "straight", straight) };
        List<int> alreadyPicked = new List<int>();

        for (int j = 0; j < 3; j++)
        {
            int z = 0;

            int index_difficulty = UnityEngine.Random.Range(0, lotteryTickets.Count);
            int difficulty = lotteryTickets[index_difficulty];

            int startIndex = difficulty * 5;
            int endIndex = difficulty * 5 + 5;

            index = Random.Range(startIndex, endIndex);
            if(alreadyPicked.Contains(index))
            {
                j--;
                continue;
            }
            alreadyPicked.Add(index);
           

            choose.Add(new RoadType(obj[index].roadName, obj[index].roadType, obj[index].icon));

            GameObject go = ObjectPoolingManager.Instance.GetObject(obj[index].roadName);
            if(!obj[index].roadName.Contains("tunnel"))
            {
                go.GetComponent<Renderer>().materials = mat;
            }
            if(obj[index].roadName.Contains("tunnel"))
            {
                Material[] mat2 = new Material[3];
                mat2[0] = mat[2];
                mat2[1] = mat[0];
                mat2[2] = mat[1];
                go.GetComponent<Renderer>().materials = mat2;
            }

            if (obj[index].roadName.Equals("dirt"))
            {
                go.GetComponent<Renderer>().material = matdirt;
            }
            
            if (obj[index].roadName == "tramp")
            {
                go.transform.localScale = new Vector3(12f,20f,20f);
            }
            //n++;
            //go.tag = n.ToString();
            go.transform.position = positionArray[j];
            go.tag = "chooser";
            go.transform.rotation = RoadCreation.rotator;
            GameObject textui = GameObject.Find("Text"+j);
            
            if (Random.value > percentage)
            {
                go.gameObject.transform.GetChild(1).gameObject.SetActive(true);
               
               
            }
            else
            {
                print(go.gameObject.transform.GetChild(1));
                go.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                
            }
            textui.GetComponent<UnityEngine.UI.Text>().text = "Normal";
            textui.GetComponent<UnityEngine.UI.Text>().color = Color.white;

            if (go.gameObject.transform.GetChild(1).gameObject.active == true) {
                textui.GetComponent<UnityEngine.UI.Text>().text = "Speed";
                textui.GetComponent<UnityEngine.UI.Text>().color = Color.blue;
                spdup = true;
            }
        }
        
        int k = 0;
        while (k < choose.Count)
        {

            print(choose[k].roadName);
        

            k++;
        }
       if (updateUI != null)
            updateUI();
    }
}
