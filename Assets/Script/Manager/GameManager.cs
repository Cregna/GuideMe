using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
  public Transform next_road_position;
    public GameObject straight;
    public GameObject right45;
    public GameObject right90;
    public GameObject left45;
    public GameObject left90;


    private void Awake()
    {
        ObjectPoolingManager.Instance.CreatePool(straight, 10, 15);
        ObjectPoolingManager.Instance.CreatePool(right45, 10, 15);
        ObjectPoolingManager.Instance.CreatePool(right90, 10, 15);
        ObjectPoolingManager.Instance.CreatePool(left45, 10, 15);
        ObjectPoolingManager.Instance.CreatePool(left90, 10, 15);

    }
    //    ObjectPoolingManager.Instance.CreatePool(m_bullet, 50, 50);
    //ObjectPoolingManager.Instance.CreatePool(m_grunt, 50, 50);
    //ObjectPoolingManager.Instance.CreatePool(m_grunt_explosion, 50, 50);
    //ObjectPoolingManager.Instance.CreatePool(m_hulk, 50, 50);
    // Update is called once per frame
    private void Start()
    {
      
    }
    void Update()
    {

    }

    public void Lose()
    {
        
    }

    public void spaceKey() {
    
        //Sroad.transform.position = vector3;
    }
}
