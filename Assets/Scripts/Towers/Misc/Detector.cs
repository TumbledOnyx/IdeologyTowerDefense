using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public List<GameObject> inRange = new List<GameObject>();
    public Tower tower;

    public bool isBoost;

    public float attackBoost;
    public float speedBoost;
    public float defenseBoost;
    public float rangeBoost;
    public float healRateBoost;


    private void Start()
    {
        tower = transform.GetComponentInParent<Tower>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            inRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange.Remove(collision.gameObject);
    }

    private void Update()
    {
        transform.parent.GetComponent<Tower>().inRange = inRange;
        if (inRange.Count != 0)
        {
            transform.parent.GetComponent<Tower>().currentlyTargeting = true;
        }
        else
        {
            transform.parent.GetComponent<Tower>().currentlyTargeting = false;
        }

        transform.localScale = new Vector3(tower.range, tower.range, 1);
        attackBoost = tower.attackBoost;
        speedBoost = tower.speedBoost;
        defenseBoost = tower.defenseBoost;
        rangeBoost = tower.rangeBoost;
        healRateBoost = tower.healRateBoost;
    }
}
