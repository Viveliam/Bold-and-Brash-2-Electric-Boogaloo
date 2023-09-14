using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject linkedObject;

    private MovingPlatform _movingPlatform;
    private bool _isPressed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _movingPlatform = linkedObject.GetComponent<MovingPlatform>();
    }

    private void FixedUpdate()
    {
        if (_isPressed)
        {
            _movingPlatform.HandleMovement();
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        _isPressed = true;
    }

    private void OnCollisionExit(Collision other)
    {
        _isPressed = false;
    }
}
