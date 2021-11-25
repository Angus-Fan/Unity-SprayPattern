using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class CharacterMovement : MonoBehaviour
{
    private CharacterController characterController;
    private void start()
    {
        try
        {
            characterController = GetComponent<CharacterController>();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public void playerJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Jump Pressed");
        }
    }
}
