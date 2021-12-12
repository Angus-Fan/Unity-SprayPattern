using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float additive;
    public float cameraSensitivity;
    private Camera fpsCam;
    private Transform bodyTransform;
    private FPSPlayerActions fpsPlayerActions;
    public float verticalOffset = 0;
    private float modifiedVertical = 0;
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
        xRotation = xRotation - mousePositions.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        fpsCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        bodyTransform.Rotate(Vector3.up * mousePositions.x);
    }

    private void returnToCenter(float recoil)
    {
        StopAllCoroutines();
        StartCoroutine(Lerp(recoil));
    }
    public void setCameraRecoil(float recoil)
    {
        //If you do not plan on using degrees than use the code block below
        // which kicks up the camera by some value (recoil)
        // additive = recoil;
        // modifiedVertical = recoil;
        // Vector2 mousePositions = fpsPlayerActions.FPSActor.CameraControls.ReadValue<Vector2>() * Time.deltaTime * cameraSensitivity;
        // xRotation = xRotation - mousePositions.y - additive;
        // xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        // fpsCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // bodyTransform.Rotate(Vector3.up * mousePositions.x);


        //Need it to be negative or it will go down isntead.
        Quaternion newAngle = Quaternion.Euler(-recoil, 0, 0);
        fpsCam.transform.localRotation = newAngle;
        returnToCenter(recoil);
    }

    float lerpDuration = 1f;
    float valueToLerp;

    IEnumerator Lerp(float value)
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(value, 0, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            Quaternion updateAngle = Quaternion.Euler(-valueToLerp, 0, 0);
            fpsCam.transform.localRotation = updateAngle;
            yield return null;
        }


        //Want to ensure that the lerp actual returns zero
        //When finished, then go ahead and set the value to 0
        valueToLerp = 0;
        Quaternion endAngle = Quaternion.Euler(-valueToLerp, 0, 0);
        fpsCam.transform.localRotation = endAngle;
    }

}
