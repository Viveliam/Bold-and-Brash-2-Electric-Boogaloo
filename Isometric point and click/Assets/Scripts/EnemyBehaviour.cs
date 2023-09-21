using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float activationDistance = 5;
    [SerializeField] private float moveSpeed = 2;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        IdleOnEnter();
    }

    public void IdleOnEnter()
    {
        //Do nothing
        IdleOnUpdate();
    }
    
    public void IdleOnUpdate()
    {
        //Do nothing, until player is near
        if (Vector3.Distance(transform.position, player.position) <= activationDistance)
        {
            IdleOnExit();
        }
    }
    
    public void IdleOnExit()
    {
        //Placeholder
        FollowOnEnter();
    }

    public void FollowOnEnter()
    {
        print("Follow!");
        FollowOnUpdate();
    }

    public void FollowOnUpdate()
    {
        var positionDifference = player.position - transform.position;
        var angle = Quaternion.LookRotation(positionDifference * Time.deltaTime);
        
        //Rotate to player
        _rb.MoveRotation(angle);
        
        _rb.MovePosition(transform.position + positionDifference.normalized * (moveSpeed * Time.deltaTime));
        if (Vector3.Distance(transform.position, player.position) > activationDistance)
        {
            FollowOnExit();
        }
    }

    public void FollowOnExit()
    {
        IdleOnEnter();
    }
}
