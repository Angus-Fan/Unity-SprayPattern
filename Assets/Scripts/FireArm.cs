using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireArm : MonoBehaviour
{
    // Start is called before the first frame update
    public float testvaluesX;
    public float testvaluesY;
    public float testvaluesZ;
    private FPSPlayerActions weaponActor;
    public float fireRate;
    public float accuracyDecayTime;
    public float currentGunAccuracy;
    public float maxGunInnaccuracy;
    public float firstShotAccuracy;
    private float nextTimeToFire = 0f;
    private float lastShotTime = 0;
    public int maxRounds;
    public int clipSize;
    private int currentClip;
    private float timeBetweenLastShot;

    private Camera fpsCam;

    private void Awake()
    {
        weaponActor = new FPSPlayerActions();
        weaponActor.WeaponActor.Enable();
        fpsCam = GetComponentInChildren<Camera>();
    }
    void Start()
    {
        currentClip = clipSize;
    }

    // Update is called once per frame
    void Update()
    {
        fire();
    }

    private void fire()
    {
        float fireValue = weaponActor.WeaponActor.Fire.ReadValue<float>();
        bool fireHeld = Convert.ToBoolean(fireValue);

        // if (currentClip > 0 && fireHeld && Time.time > nextTimeToFire)
        // {
        currentClip--;
        nextTimeToFire = Time.time + 1f / fireRate;
        lastShotTime = Time.time;
        castRay();
        //}

    }
    private void checkAccuracyReset()
    {
        if (Time.time - lastShotTime > accuracyDecayTime)
        {
            currentGunAccuracy = firstShotAccuracy;
        }

    }

    private Vector3 nextShotVector()
    {
        float shotX = UnityEngine.Random.Range(-.4f, .4f);
        float shotY = UnityEngine.Random.Range(-.4f, .4f);
        return Quaternion.Euler(0, shotX, shotY) * fpsCam.transform.forward;
    }

    private void castRay()
    {
        RaycastHit hit;
        //Using the screenPointToRay gave some strange innacurate results using forward isntead.
        //Ray ray = fpsCam.ScreenPointToRay(weaponActor.WeaponActor.MousePosition.ReadValue<Vector2>());


        Vector3 nextShotVectorValue = nextShotVector();

        Ray ray = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        Ray ray2 = new Ray(fpsCam.transform.position, nextShotVectorValue);
        Color color = new Color(0, 0, 0, 1);
        Color color2 = new Color(0, 1, 0, 1);


        // if (Physics.Raycast(ray, out hit))
        // {
        //     Debug.DrawLine(fpsCam.transform.position, hit.point, color, 2);

        // }
        if (Physics.Raycast(ray2, out hit))
        {
            Debug.DrawLine(fpsCam.transform.position, hit.point, color2, 2);

        }

    }
}
