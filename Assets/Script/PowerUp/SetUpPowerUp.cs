using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpPowerUp : MonoBehaviour
{
    public float pushforce;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        var heading  = transform.parent.GetChild(3).position - transform.parent.GetChild(2).position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        Debug.Log("CAR ENTER");
        GameObject go = GameObject.FindGameObjectWithTag("Player"); 
        go.GetComponent<Rigidbody>().AddForce(direction * pushforce, ForceMode.Acceleration);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
