using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireArm : MonoBehaviour
{
    // Start is called before the first frame update
    private FPSPlayerActions weaponActor;
    public LayerMask rayCastIgnore;
    [Header("Fire Arm Stats")]
    public float fireRate;
    public int maxRounds;
    public int clipSize;
    public float reloadTime;
    public int currentClip;
    [Header("Accuracy")]
    public float accuracyDecayTime;
    public float currentGunAccuracy;
    public float maxGunInnaccuracy;
    public float firstShotAccuracy;
    private int bulletIndex = 0;
    public float maxKickUp;
    public float cameraKick = 0f;
    private float nextTimeToFire = 0f;
    private float lastShotTime = 0;
    private float timeBetweenLastShot;
    private float cameraOffset = 0f;

    public float[] bulletRecoil;
    public float[] bulletCameraKick;

    private Camera fpsCam;
    private CameraControls cameraControls;

    private void Awake()
    {
        weaponActor = new FPSPlayerActions();
        weaponActor.WeaponActor.Enable();
        fpsCam = GetComponentInChildren<Camera>();
        cameraControls = GetComponent<CameraControls>();
        currentGunAccuracy = firstShotAccuracy;

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

        if (currentClip > 0 && fireHeld && (Time.time > nextTimeToFire))
        {

            //Was shot fired above the accuracy innacuracy?
            accuracyCalculator();
            //First Shot Accuracy Code
            currentClip--;
            nextTimeToFire = Time.time + 1f / fireRate;
            lastShotTime = Time.time;
            castRay();
            cameraKickCalculator();

        }

    }
    private void accuracyCalculator()
    {
        bulletIndex++;

        //If we waited long enough reset our gun to the default
        if (Time.time - lastShotTime > accuracyDecayTime)
        {
            resetAccuracy();
        }
        else
        {
            // bulletInnacuracyIndex++;
            // if (bulletInnacuracyIndex < bulletRecoil.Length)
            // {
            //     currentGunAccuracy += bulletRecoil[bulletInnacuracyIndex];
            // }
            // Mathf.Clamp(currentGunAccuracy, firstShotAccuracy, maxGunInnaccuracy);
        }
    }
    private void cameraKickCalculator()
    {
        if (bulletIndex < bulletCameraKick.Length)
        {
            cameraKick += bulletCameraKick[bulletIndex];

        }
        Mathf.Clamp(cameraKick, 0, maxKickUp);

        kickCamera(cameraKick);

    }


    public void resetAccuracy()
    {
        currentGunAccuracy = firstShotAccuracy;
        cameraKick = 0;
        bulletIndex = 0;
    }

    private Vector3 nextShotVector(float accuracy)
    {
        float shotX = UnityEngine.Random.Range(-accuracy, accuracy);
        float shotY = UnityEngine.Random.Range(-accuracy, firstShotAccuracy);
        return Quaternion.Euler(0, shotX, shotY) * fpsCam.transform.forward;
    }

    private void castRay()
    {
        RaycastHit hit;
        //Using the screenPointToRay gave some strange innacurate results using forward isntead.
        //Ray ray = fpsCam.ScreenPointToRay(weaponActor.WeaponActor.MousePosition.ReadValue<Vector2>());


        Vector3 nextShotVectorValue = nextShotVector(currentGunAccuracy);

        Ray ray = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        Ray ray2 = new Ray(fpsCam.transform.position, nextShotVectorValue);
        Color color = new Color(0, 0, 0, 1);
        Color color2 = new Color(0, 1, 0, 1);


        // if (Physics.Raycast(ray, out hit))
        // {
        //     Debug.DrawLine(fpsCam.transform.position, hit.point, color, 2);

        // }
        if (Physics.Raycast(ray2, out hit, 10000, ~rayCastIgnore))
        {
            Debug.DrawLine(fpsCam.transform.position, hit.point, color2, 2);

        }

    }

    private void kickCamera(float kick)
    {
        cameraControls.setCameraRecoil(kick);
    }
}
