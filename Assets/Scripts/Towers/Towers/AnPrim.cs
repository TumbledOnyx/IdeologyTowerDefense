using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnPrim : Tower
{

    private void Start()
    {
        TowerType = "AnPrim";
        TowerName = "Anarcho Primitivist";
        anPrimStats();
        CheckUpgrades();
        prevTime = 0;
    }

    private void Update()
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
        anPrimStats();
        StatCheck();
        if (topPath == 1)
        {
            pierce = 3;
        }
        else if (topPath == 2)
        {
            pierce = 5;
        }
        else if (topPath == 3)
        {
            pierce = 5;
            currentAttackCooldown /= (float)1.5;
        }
        if (bottomPath == 1)
        {
            cashPerHit = 1;
        }
        else if (bottomPath == 2)
        {
            cashPerHit = 1;
            healthPerHit = (float)0.25;
        }
        else if (bottomPath == 3)
        {
            cashPerHit = 2;
            healthPerHit = (float)0.5;
        }
    }

    private void anPrimStats()
    {
        maxHealth = UpgradesAndUnlocks.Instance.AnPrimHealth;
        health = maxHealth;
        attackCooldown = UpgradesAndUnlocks.Instance.AnPrimSpeed;
        attackDamage = UpgradesAndUnlocks.Instance.AnPrimAttackDamage;
        range = UpgradesAndUnlocks.Instance.AnPrimRange;
        cost = UpgradesAndUnlocks.Instance.AnPrimCost;
        pierce = 2;
    }
}
