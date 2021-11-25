using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
        getCamera();
    }

    // Update is called once per frame
    void Update()
    {

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
}
