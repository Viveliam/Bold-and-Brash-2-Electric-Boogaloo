using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] Mouselook mouseLook;
    
    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;

    private Vector2 horizontalInput;
    private Vector2 mouseInput;
    
    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
        
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }
    
}
