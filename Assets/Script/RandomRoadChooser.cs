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

    int index;
    
   public static List<RoadType> choose = new List<RoadType>();


    private void OnEnable()
    {
        RoadCreation.changeRoadEvent += chooseNewRoad;
    }

    private void OnDisable()
    {
        RoadCreation.changeRoadEvent -= chooseNewRoad;

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

        List<RoadType> obj = new List<RoadType> { new RoadType("straight", straight), new RoadType("left90", left90), new RoadType("left45", left45), new RoadType("right45", right45), new RoadType("right90", right90) };

        for (int j = 0; j < 3; j++)
        {
            int z = 0;
            
           
            index = Random.Range(0, (obj.Count));
          
            choose.Add(new RoadType(obj[index].roadName, obj[index].icon));

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
