using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("looool");

        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(true);

        Time.timeScale = 1;



    }
}
