using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Entities;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float health = 10;
    [SerializeField] private EntityStats entityStats;

    // Update is called once per frame
    private void Update()
    {
        health = Mathf.Clamp(health, 0, entityStats.maxHealth);
        
        //Die
        if (health <= 0)
        {
            //Play die animation first, then die
            Destroy(gameObject);
        }
    }
    
    
    //Take damage
    private void OnTriggerEnter(Collider other)
    {
        //Hit by weapon of player
        if (other.CompareTag("Weapon"))
        {
            var damage = other.GetComponent<Weapon>().WeaponStats.damage;
            health -= damage;
        } 
        //Hit by enemy
        else if (other.CompareTag("Enemy"))
        {
            //Need enemy attack script for this
            // var damage = other.GetComponent<Attackable>().Entity.damage;
            // _self.Health -= damage;
        }
    }

    public float Health
    {
        get => health;
        set => health = value;
    }

    public EntityStats EntityStats => entityStats;
}
