using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerHealth : MonoBehaviour
{

    public GameObject tower;



    void Start()
    {
        
    }

    void Update()
    {
        if (tower != null)
        {
            GetComponent<Slider>().value = tower.GetComponent<Tower>().healthPercent;
        }
    }

}
