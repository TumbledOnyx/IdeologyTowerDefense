using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUIManager : MonoBehaviour
{
    public GameObject tower; //Holds data for what tower is being upgraded/examined
    public GameObject towerhealth;  //Holds the Tower Health UI element that is being changed by this script
    public GameObject upgradeTopPathText;
    public GameObject upgradeBottomPathText;
    public GameObject upgradeCostTop;
    public GameObject upgradeCostBottom;
    public GameObject dropdownBox;

    Tower towerScript;




    void Start()
    {
        towerScript = tower.GetComponent<Tower>();
        towerhealth.GetComponent<TowerHealth>().tower = tower;   //Gives health bar the tower object, so it can get its health
        UpdateText();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            OnExit();
        }
    }

    public void UpgradeOne()
    {
        if (towerScript.topPath == 0)
        {
            if (towerScript.TierITopCost <= GlobalVars.cash)
            {
                GlobalVars.cash -= towerScript.TierITopCost;
                towerScript.topPath += 1;
            }
        }
        else if (towerScript.topPath == 1)
        {
            if (towerScript.TierIITopCost <= GlobalVars.cash)
            {
                GlobalVars.cash -= towerScript.TierIITopCost;
                towerScript.topPath += 1;
            }
        }
        else if (towerScript.topPath == 2 && towerScript.bottomPath != 3)
        {
            if (towerScript.TierIIITopCost <= GlobalVars.cash)
            {
                GlobalVars.cash -= towerScript.TierIIITopCost;
                towerScript.topPath += 1;
            }
        }
        UpdateText();
        towerScript.CheckUpgrades();
    }

    public void UpgradeTwo()
    {
        if (towerScript.bottomPath == 0)
        {
            if (towerScript.TierIBottomCost <= GlobalVars.cash)
            {
                GlobalVars.cash -= towerScript.TierIBottomCost;
                towerScript.bottomPath += 1;
            }
        }
        else if (towerScript.bottomPath == 1)
        {
            if (towerScript.TierIIBottomCost <= GlobalVars.cash)
            {
                GlobalVars.cash -= towerScript.TierIIBottomCost;
                towerScript.bottomPath += 1;
            }
        }
        else if (towerScript.bottomPath == 2 && towerScript.topPath != 3)
        {
            if (towerScript.TierIIIBottomCost <= GlobalVars.cash)
            {
                GlobalVars.cash -= towerScript.TierIIIBottomCost;
                towerScript.bottomPath += 1;
            }
        }
        UpdateText();
        towerScript.CheckUpgrades();
    }

    public void UpdateTargetMethod()
    {
        switch (dropdownBox.GetComponent<Dropdown>().value)
        {
            case 0:
                towerScript.targetSelectMethod = "First";
                break;
            case 1:
                towerScript.targetSelectMethod = "Last";
                break;
            case 2:
                towerScript.targetSelectMethod = "Strong";
                break;
            case 3:
                towerScript.targetSelectMethod = "Weak";
                break;
            case 4:
                towerScript.targetSelectMethod = "Horseshoe";
                break;
            case 5:
                towerScript.targetSelectMethod = "Anti Extremist";
                break;
            case 6:
                towerScript.targetSelectMethod = "Close";
                break;
        }
    }

    public void UpdateText()
    {
        if (towerScript.topPath == 0)
        {
            upgradeTopPathText.GetComponent<Text>().text = towerScript.TierITopDescription;
            upgradeCostTop.GetComponent<Text>().text = towerScript.TierITopCost.ToString();
        }
        else if (towerScript.topPath == 1)
        {
            upgradeTopPathText.GetComponent<Text>().text = towerScript.TierIITopDescription;
            upgradeCostTop.GetComponent<Text>().text = towerScript.TierIITopCost.ToString();

        }
        else if (towerScript.topPath == 2 && towerScript.bottomPath != 3)
        {
            upgradeTopPathText.GetComponent<Text>().text = towerScript.TierIIITopDescription;
            upgradeCostTop.GetComponent<Text>().text = towerScript.TierIIITopCost.ToString();

        }
        else if (towerScript.topPath == 3)
        {
            upgradeTopPathText.GetComponent<Text>().text = "All upgrades on this path have been bought.";
            upgradeCostTop.GetComponent<Text>().text = "";
        }
        else if (towerScript.bottomPath == 3)
        {
            upgradeTopPathText.GetComponent<Text>().text = "Bottom path already has a tier III upgrade.";
            upgradeCostTop.GetComponent<Text>().text = "";
        }
        if (towerScript.bottomPath == 0)
        {
            upgradeBottomPathText.GetComponent<Text>().text = towerScript.TierIBottomDescription;
            upgradeCostBottom.GetComponent<Text>().text = towerScript.TierIBottomCost.ToString();
        }
        else if (towerScript.bottomPath == 1)
        {
            upgradeBottomPathText.GetComponent<Text>().text = towerScript.TierIIBottomDescription;
            upgradeCostBottom.GetComponent<Text>().text = towerScript.TierIIBottomCost.ToString();
        }
        else if (towerScript.bottomPath == 2 && towerScript.topPath != 3)
        {
            upgradeBottomPathText.GetComponent<Text>().text = towerScript.TierIIIBottomDescription;
            upgradeCostBottom.GetComponent<Text>().text = towerScript.TierIIIBottomCost.ToString();
        }
        else if (towerScript.bottomPath == 3)
        {
            upgradeBottomPathText.GetComponent<Text>().text = "All upgrades on this path have been bought.";
            upgradeCostBottom.GetComponent<Text>().text = "";
        }
        else if (towerScript.topPath == 3)
        {
            upgradeBottomPathText.GetComponent<Text>().text = "Top path already has a tier III upgrade.";
            upgradeCostBottom.GetComponent<Text>().text = "";
        }
    }

    public void OnExit()
    {
        GameObject range = tower.transform.GetChild(0).gameObject;
        range.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
        Destroy(gameObject);
    }
}