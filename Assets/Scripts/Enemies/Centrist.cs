using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Centrist : MonoBehaviour
{
    public PathCreator pathcreator;
    public EndOfPathInstruction end;

    public float speed = 0;
    public float atk = 1;
    public float distance;
    public float health;
    public int cashOnKill;
    public bool canKill;
    public bool canSlow;

    private Vector3 lastTransform;
    private float timeStamp;

    private void Start()
    {
        pathcreator = GameObject.FindGameObjectWithTag("Path").GetComponent<PathCreator>();
        transform.position = pathcreator.path.GetPointAtDistance(distance);
        health = health * (GlobalVars.EnemyHealthPercent / 100);
    }

    void Update()
    {
        MoveForward();
        if (health <= 0)
        {
            death();
        }
    }

    void MoveForward()
    { 
        distance += speed * Time.deltaTime;
        transform.position = pathcreator.path.GetPointAtDistance(distance, end);
        if (pathcreator.path.GetPointAtDistance(1000, end) == transform.position)
        {
            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + atk;
                GlobalVars.health -= 1;
                health -= 1;
            }
        }
    }

    void death()
    {
            GlobalVars.cash += cashOnKill;
            Waves.enemyKilled += 1;
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (collision.gameObject.GetComponent<Projectile>().pierce >= 0)
            {
                health -= collision.gameObject.GetComponent<Projectile>().damage;
            }
        }
    }
}
