using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   [SerializeField] private float speed = 11f;
   [SerializeField] private CharacterController controller;
   private Vector2 horizontalInput;

   [SerializeField] private float gravity = -30f;
   private Vector3 verticalVelocity = Vector3.zero;
   [SerializeField] private LayerMask groundMask;
   private bool isGrounded;

   public void ReceiveInput(Vector2 _horizontalInput)
   {
      horizontalInput = _horizontalInput;
   }

   private void Update()
   {
      isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
      if (isGrounded) {
         verticalVelocity.y = 0;
      }
      
      Vector3 horizontalVelocity =
         (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
      controller.Move(horizontalVelocity * Time.deltaTime);
      
      verticalVelocity.y -= gravity * Time.deltaTime;
      controller.Move(verticalVelocity * Time.deltaTime);
   }
}
