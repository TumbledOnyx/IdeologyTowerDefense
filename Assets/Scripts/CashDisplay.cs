using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashDisplay : MonoBehaviour
{

    public Text text;

    private void Start()
    {
        GlobalVars.cash = 200;
    }
    void Update()
    {
        text.text = "Cash: " + GlobalVars.cash.ToString();
        if (GlobalVars.health < 100)
        {
            UpgradesAndUnlocks.Instance.score = GlobalVars.cash;
        }
        else if (GlobalVars.health < 200)
        {
            UpgradesAndUnlocks.Instance.score = Mathf.RoundToInt(GlobalVars.cash * 1.5F);
        }
        else if (GlobalVars.health < 400)
        {
            UpgradesAndUnlocks.Instance.score = Mathf.RoundToInt(GlobalVars.cash * 2);
        }
        else
        {
            UpgradesAndUnlocks.Instance.score = Mathf.RoundToInt(GlobalVars.cash * 3);
        }
    }
}
