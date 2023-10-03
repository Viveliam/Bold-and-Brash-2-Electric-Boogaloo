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
    void Update()
    {
        health = Mathf.Clamp(health, 0, entityStats.maxHealth);
        
        //Die
        if (health <= 0)
        {
            //Play die animation first, then die
            Destroy(gameObject);
        }
    }

    public float Health
    {
        get => health;
        set => health = value;
    }
}
