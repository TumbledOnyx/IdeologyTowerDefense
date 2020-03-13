using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthDisplay : MonoBehaviour
{
    public Text text;
    void Start()
    {
        GlobalVars.health = 400;
    }

    void Update()
    {
        text.text = "Health: " + GlobalVars.health.ToString();
        if (GlobalVars.health <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
