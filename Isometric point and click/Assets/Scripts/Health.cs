using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 5;

    // Update is called once per frame
    void Update()
    {
        if (HealthVal <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float HealthVal
    {
        get => health;
        set => health = value;
    }
}
