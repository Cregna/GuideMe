using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoadChooser : MonoBehaviour
{
    int index;
   public static  ArrayList choose = new ArrayList { };
    ArrayList obj = new ArrayList { "straight", "right45", "right90", "left45", "left90" };
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < 3; j++)
        {
           
            index = Random.Range(0, (obj.Count-1));
            print(obj.Count);
            print(obj[index]);
            choose.Add(obj[index]);

            obj.Remove(obj[index]);
          

            
            print("lenght is " + choose.Count);

        }
        int k = 0;
        print("Your random chooser is:");
        while (k < choose.Count) {
            print(choose[k]);
            k++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
