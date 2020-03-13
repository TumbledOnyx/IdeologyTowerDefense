using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeScale : MonoBehaviour
{
    public GameObject dropdown;

    public void onValueChange()
    {
        int choice;
        choice = dropdown.GetComponent<Dropdown>().value;
        switch (choice)
        {
            case 0:
                Time.timeScale = (float)0.5;
                break;
            case 1:
                Time.timeScale = 1;
                break;
            case 2:
                Time.timeScale = 2;
                break;
            case 3:
                Time.timeScale = 3;
                break;
        }
    }
}
