﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using PrefabUtility.InstantiatePrefab.

public class EnemyMain : MonoBehaviour
{
    //Enemy main variables
    public int maxHealth = 100;
    private int currentHealth;
    public float speed = 8;
    public float distance = 15;
    public int shootDamage = 50;
    public string EnemyType;
    public double delay = 0;
    float freezeDelay = 0;
    private bool hit = false;
    public float projectileSpeed = 15;
    public float projectileDropTime = 2f;
    int projCounter = 0;
    bool yes = true;
    public int dropRate;

    //gameobjects to refer too
    public SpriteRenderer SR;
    private Transform target;
    public GameObject projectilePrefab;
    public GameObject deathDrop;
    public GameObject coinDrop;

    void Start()
    {
        currentHealth = maxHealth; // set starting health of player
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //get player component for enemy to follow
    }

    void Update()
    {
        float distanceCurrent = Vector3.Distance(target.transform.position, this.transform.position);
        //enemy chases player after getting in range
        if (distanceCurrent <= distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //for second enemy has a different attack method
            if(EnemyType == "two")
            {
                if (yes)
                {
                    StartCoroutine(ProjectileDelay());
                    yes = false;
                }
            }
            

        }

        //if player is in ICE FORM freeze enemies for a short duration
        if (GlobalVarStore.Equipped == "ice")
        {
            if(freezeDelay > Time.time && hit == true)
            {
                SR.color = Color.blue; // freeze
                speed = 0;
                hit = false;
            }
            if (freezeDelay < Time.time) // unfreeze
            {
                SR.color = Color.white;
                speed = 8;
            }
        }

        else
        {
            if (delay > Time.time && hit == true) // enemy hit indicator
            {
                SR.color = Color.red;
                hit = false;
            }
            if (delay < Time.time) // back to normal
            {
                SR.color = Color.white;
            }
        }

    }
    public void ProjectileFire()
    {
        //instantiate projectile for second enemy
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();
        projGO.transform.position = transform.position;
        Destroy(projGO, 15);

    }
    IEnumerator ProjectileDelay()
    {
        ProjectileFire();
        while (projCounter < 5)
        {
            ProjectileFire();
            projCounter++;
            yield return new WaitForSeconds(2.0f);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if enemy is hit by player projectile take damage and die
        if (other.gameObject.tag == "ProjHero")
        {
            Destroy(other.gameObject);
            TakeDamage(GlobalVarStore.ProjDamage);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                
            }

        }
    }
    public void TakeDamage(int damage) //deal damage to enemy
    {
        hit = true;
        delay = Time.time + 0.5;
        freezeDelay = Time.time + 2;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
  
    }

    void Die() //destroy enemy and drop loot
    {      
        Instantiate(deathDrop, this.transform.position, transform.rotation);
        Instantiate(coinDrop, this.transform.position, transform.rotation); 
        Destroy(gameObject);
    }
}
