using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; //Sorting algorithim is in this 

public class Tower : MonoBehaviour
{
    public int maxHealth; //These hold initial tower Stats
    public int cost;
    public float attackCooldown;
    public float attackDamage;
    public float range;
    public float healRate;
    public float defense;


    public int health;                       //These hold tower stats
    public float currentAttackCooldown;
    public float currentAttackDamage;
    public float currentRange;
    public float currentHealRate;
    public float currentDefense;
    public int topPath;
    public int bottomPath;
    public float pierce;
    public float projectileSpeed;
    public bool homing;
    public float explosiveRadius;
    public int cashPerHit;
    public float healthPerHit;


    public string targetSelectMethod;


    public Vector2 targetPos;

    public bool currentlyTargeting;


    //These determine how much boost each stat is getting 
    public float syndAmount; //Damage boost
    public float accelAmount; //Attack speed boost
    public float mutualAmount; //Shield
    public float platAmount;  //Range
    public float posadAmount; //Heal rate boost

    List<Detector> collidingBodies = new List<Detector>();


    public float attackBoost;
    public float speedBoost;
    public float defenseBoost;
    public float rangeBoost;
    public float healRateBoost;

    public float healthPercent;

    public string TowerType;
    public string TowerName;


    public string TierITopDescription;
    public string TierIITopDescription;
    public string TierIIITopDescription;

    public int TierITopCost;
    public int TierIITopCost;
    public int TierIIITopCost;

    public string TierIBottomDescription;
    public string TierIIBottomDescription;
    public string TierIIIBottomDescription;

    public int TierIBottomCost;
    public int TierIIBottomCost;
    public int TierIIIBottomCost;

    public GameObject TowerUIPrefab;
    public GameObject ProjectilePrefab;

    GameObject towerUI;

    public List<GameObject> inRange;

    float healthPercentcalc;
    public float prevTime;



    public void OnClick()
    {
        GameObject oldUI = GameObject.FindWithTag("TowerUpgradeMenu");
        if (oldUI != null)
        {

            TowerUIManager toweruimanager = oldUI.GetComponent<TowerUIManager>();  //Takes the old tower range and sets it invisible again
            GameObject tower = toweruimanager.tower;
            GameObject range = tower.transform.GetChild(0).gameObject;
            range.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
        }

        Destroy(oldUI);
        GameObject canvas = GameObject.Find("Canvas");
        towerUI = Instantiate(TowerUIPrefab, canvas.transform);
        towerUI.transform.position = new Vector2((float)7.4, 0);
        towerUI.transform.GetChild(0).GetComponent<Text>().text = TowerName;
        towerUI.GetComponent<TowerUIManager>().tower = gameObject;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(92, 197, 224, 156);
    }

    private void Awake()   //Called before the inherited scripts "start()" function
    {

    }

    public void OnHealthChange()
    {
        healthPercentcalc = ((float)health / (float)maxHealth) * 100;
        healthPercentcalc = (healthPercentcalc - 100) * -1;
        healthPercent = healthPercentcalc;
    }

    public void StatCheck()
    {
        currentAttackCooldown = attackCooldown * Mathf.Pow(Mathf.Sqrt((float)(accelAmount + 1)), -1);  //Multiplier gets smaller as Accelerationists amount increases
        currentAttackDamage = attackDamage * Mathf.Sqrt(syndAmount + 1);
        currentHealRate = healRate * Mathf.Sqrt(posadAmount + 1);           //Square root function helps prevent values from becoming too large - Diminishing Returns
        currentRange = range * Mathf.Sqrt(platAmount + 1);
        currentDefense = Mathf.Pow(defense + 1, -1);
    }

    public Vector2 DetermineTarget(List<GameObject> inRange)
    {
        Vector2 enemyPos;
        if (inRange.Count == 0)
        {
            return new Vector2(0, 404);     //If the target can not be found, it will return a vector that tells the shoot function not to fire.
        }
        if (targetSelectMethod == "First")       //Shoots enemy closest to the base (good for general defense of base)
        {
            inRange = inRange.OrderBy(c => c.GetComponent<Centrist>().distance).ToList(); //Sorting code provided courtesy of Kishotta
            inRange.Reverse();
            enemyPos = inRange[0].transform.position;
        }
        else if (targetSelectMethod == "Last")     //Shoots enemy farthest from the base (good for piercing shots)
        {
            inRange = inRange.OrderBy(c => c.GetComponent<Centrist>().distance).ToList();
            enemyPos = inRange[0].transform.position;
        }
        else if (targetSelectMethod == "Strong")      //Shoots enemy with most health (good for high damage towers)
        {
            inRange = inRange.OrderBy(c => c.GetComponent<Centrist>().health).ToList();
            inRange.Reverse();
            enemyPos = inRange[0].transform.position;
        }
        else if (targetSelectMethod == "Weak")       //Shoots enemy with lowest health (good for picking off weak enemies)
        {
            inRange = inRange.OrderBy(c => c.GetComponent<Centrist>().health).ToList();
            enemyPos = inRange[0].transform.position;
        }
        else if (targetSelectMethod == "Horseshoe")     //Prioritizes shooting horseshoe centrists (to keep DPS of towers up)
        {
            inRange = inRange.OrderBy(c => c.GetComponent<Centrist>().canSlow).ToList();
            inRange.Reverse();
            enemyPos = inRange[0].transform.position;
        }
        else if (targetSelectMethod == "AntiExtremist")     //Prioritizes shooting Anti-Extremists (to keep tower health high)
        {
            inRange = inRange.OrderBy(c => c.GetComponent<Centrist>().canKill).ToList();
            inRange.Reverse();
            enemyPos = inRange[0].transform.position;
        }
        else if (targetSelectMethod == "Close")
        {
            //Implement later if neccessary
            enemyPos = new Vector2(0, 0);
        }
        else
        {
            enemyPos = new Vector2(0, 0);
            Debug.Log("Error");
        }
        return enemyPos;
    }

    public void Shoot()
    {
        GameObject Projectile = Instantiate(ProjectilePrefab);
        Projectile.transform.position = transform.position;
        Projectile.GetComponent<Projectile>().damage = currentAttackDamage;
        Projectile.GetComponent<Projectile>().speed = projectileSpeed;
        Projectile.GetComponent<Projectile>().pierce = pierce;
        Projectile.GetComponent<Projectile>().explosiveRadius = explosiveRadius;
        Projectile.GetComponent<Projectile>().homing = homing;
        Projectile.GetComponent<Projectile>().cashPerHit = cashPerHit;
        Projectile.GetComponent<Projectile>().healthPerHit = healthPerHit;
        if (DetermineTarget(inRange).y != 404 && DetermineTarget(inRange).y >= -5 && DetermineTarget(inRange).y <= 5)     //These clauses prevent null targets and targets outside of the viewing area.
        {
            Projectile.GetComponent<Projectile>().target = DetermineTarget(inRange);
        }
        else
        {
            Destroy(Projectile);
        }
    }
    public virtual void CheckUpgrades()     //Virtual keyword allows it to be overriden by inherited script
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.GetChild(0) != null)
        {
            if (collision.gameObject.transform.GetChild(0).GetComponent<Detector>().isBoost == true)
            {
                collidingBodies.Add(collision.gameObject.transform.GetChild(0).GetComponent<Detector>());
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.transform.GetChild(0) != null)
        {
            if (collision.gameObject.transform.GetChild(0).GetComponent<Detector>().isBoost == true)
            {
                collidingBodies.Remove(collision.gameObject.transform.GetChild(0).GetComponent<Detector>());
            }
        }
    }

}
