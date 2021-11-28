using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float cameraSensitivity;
    private Camera fpsCam;
    private Transform bodyTransform;
    private FPSPlayerActions fpsPlayerActions;
    private float xRotation = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        fpsPlayerActions = new FPSPlayerActions();
        fpsPlayerActions.FPSActor.Enable();
    }
    void Start()
    {
        hideCursor();
        getCamera();
        getBody();
    }

    // Update is called once per frame
    void Update()
    {
        //updateCamera();
    }

    private void hideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
    //Grab camera from current object
    private void getCamera()
    {
        try
        {
            fpsCam = GetComponentInChildren<Camera>();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }
    private void getBody()
    {
        try
        {
            bodyTransform = gameObject.transform;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }

    private void updateCamera()
    {
        Vector2 mousePositions = fpsPlayerActions.FPSActor.CameraControls.ReadValue<Vector2>() * Time.deltaTime * cameraSensitivity;
        xRotation -= mousePositions.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        fpsCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        bodyTransform.Rotate(Vector3.up * mousePositions.x);
    }
}
