using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_script : MonoBehaviour
{
    
    public ObjectDialog dialog;
    public  int i = 1;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void OnTriggerEnter(Collider other)
    {
        print("looool");
       
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            
            FindObjectOfType<DialogManager>().StartDialog(dialog);
        //    Time.timeScale = 0;
            
        

    }

}
