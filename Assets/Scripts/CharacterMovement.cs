using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class CharacterMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Camera fpsCamera;
    private FPSPlayerActions fpsPlayerActions;

    //Player Variables
    public int health = 100;
    public float moveSpeed = 2;
    public float jumpStrength = 5;

    //Player Movement Variables
    private float gravity = -9.81f;
    private float playerVerticalVelocity;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        fpsCamera = GetComponentInChildren<Camera>();
        fpsPlayerActions = new FPSPlayerActions();
        fpsPlayerActions.FPSActor.Enable();
    }

    private void Update()
    {
        playerMovement();

    }
    public float playerJump()
    {
        float jumpValue = fpsPlayerActions.FPSActor.Jump.ReadValue<float>();
        bool jumpPressed = Convert.ToBoolean(jumpValue);
        //If we're not moving down just set it to 0
        //We don't want to build up our gravity if we're grounded
        if (characterController.isGrounded && playerVerticalVelocity < 0)
        {
            playerVerticalVelocity = -characterController.stepOffset * Time.deltaTime;
        }
        else
        {
            playerVerticalVelocity += gravity * Time.deltaTime;
        }

        if (characterController.isGrounded && jumpPressed)
        {
            playerVerticalVelocity = jumpStrength;
        }

        return playerVerticalVelocity;
    }

    public void playerMovement()
    {
        Vector2 inputDir = fpsPlayerActions.FPSActor.Movement.ReadValue<Vector2>();
        float inputVertical = playerJump();
        Vector3 forwardVector = transform.right * inputDir.x + characterController.transform.forward * inputDir.y;
        forwardVector.y = inputVertical;
        characterController.Move(forwardVector * moveSpeed * Time.deltaTime);
    }
}
