using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFix : MonoBehaviour
{
    public GameObject Character;
    public Camera Camera;
    public Vector3 CamAdjustment;

    public double DegreesToRadians(double degrees)
    {
        return (Math.PI / 180) * degrees;
    }

    // Start is called before the first frame update
    void Update()
    {
        double AngleFromZ = Character.transform.rotation.eulerAngles.y;
        Camera.transform.eulerAngles = new Vector3(Camera.transform.eulerAngles.x, Character.transform.eulerAngles.y, 0);

        Vector3 position = new Vector3((float)(Math.Sin(DegreesToRadians(AngleFromZ))* CamAdjustment.z),
            CamAdjustment.y, (float)(Math.Cos(DegreesToRadians(AngleFromZ))* CamAdjustment.z));
        Camera.transform.position = Character.transform.position+ position;
    }
}
