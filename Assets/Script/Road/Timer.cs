using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(this.gameObject, timer);
    }

}
