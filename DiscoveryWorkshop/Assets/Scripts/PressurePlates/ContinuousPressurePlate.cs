using System;
using System.Collections;
using System.Collections.Generic;
using ActionScripts;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject linkedObject;

    private Action _action;
    private bool _isPressed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _action = linkedObject.GetComponent<Action>();
    }

    private void FixedUpdate()
    {
        if (_isPressed)
        {
            _action.DoAction();
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
