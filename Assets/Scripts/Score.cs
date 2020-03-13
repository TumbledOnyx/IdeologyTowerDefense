using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = "Score: " + UpgradesAndUnlocks.Instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
