using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed;
    public float pierce;
    public float explosiveRadius;
    public bool homing;
    public int cashPerHit;
    public float healthPerHit;
    public Vector2 target;


    float currentTime;


    private void Start()
    {
        currentTime = Time.time;
        Vector3 targetVec3 = new Vector3(target.x, target.y, 0);
        gameObject.GetComponent<Rigidbody2D>().AddForce(((targetVec3 - transform.position).normalized) * speed * 100);
    }

    void Update()
    {
        Move();
        if (Time.time >= 5 + currentTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pierce -= 1;
        GlobalVars.cash += cashPerHit; //Used for AnPrim tower's upgrades
        if (healthPerHit == 0.25)
        {
            int h = Random.Range(1, 5);
            if (h == 4)
            {
                GlobalVars.health += 1;
            }
        }
        else if (healthPerHit == 0.5)
        {
            int h = Random.Range(1, 3);
            if (h == 2)
            {
                GlobalVars.health += 1;
            }
        }
        if (pierce <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        if (homing == true)
        {
            Vector3 targetVec3 = new Vector3(target.x, target.y, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(((targetVec3 - transform.position)).normalized * 100);

        }
    }
}
