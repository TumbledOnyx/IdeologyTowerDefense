using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemSoc : Tower
{
    void Start()
    {
        TowerType = "DemSoc";
        TowerName = "Democratic Socialist";
        demSocStats();
        CheckUpgrades();
        prevTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        OnHealthChange();
        if (Time.time >= prevTime + currentAttackCooldown && currentlyTargeting == true)
        {
            Shoot();
            prevTime = Time.time;
        }
    }

    public override void CheckUpgrades()  //Replaces tower's base CheckUpgrades() function to give each tower unique functionality.  Override is the keyword that lets me do this.
    {
        demSocStats();
        StatCheck();
        if (topPath == 1)
        {
            currentAttackDamage *= (float)1.3;
        }
        else if (topPath == 2)
        {
            currentAttackDamage *= (float)1.6;
        }
        else if (topPath == 3)
        {
            currentAttackDamage *= (float)1.6;
            pierce = 2;
        
        }
        if (bottomPath == 1)
        {
            currentAttackCooldown *= (float)0.8;
        }
        else if (bottomPath == 2)
        {
            currentAttackCooldown *= (float)0.6;
        }
        else if (bottomPath == 3)
        {
            currentAttackCooldown *= (float)0.4;
        }
    }

    private void demSocStats()
    {
        maxHealth = UpgradesAndUnlocks.Instance.DemSocHealth;
        health = maxHealth;
        attackCooldown = UpgradesAndUnlocks.Instance.DemSocSpeed;
        attackDamage = UpgradesAndUnlocks.Instance.DemSocAttackDamage;
        range = 50;
        cost = UpgradesAndUnlocks.Instance.DemSocCost;
        pierce = 1;
    }
}
