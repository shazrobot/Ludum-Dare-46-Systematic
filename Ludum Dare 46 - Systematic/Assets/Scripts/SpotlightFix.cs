using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpotlightFix : MonoBehaviour
{
    public Light Spotlight;
    public GameObject Character;
    public Vector3 LightAdjustment;
    public double DegreesToRadians(double degrees)
    {
        return (Math.PI / 180) * degrees;
    }

    void FixedUpdate()
    {
        double AngleFromZ = Character.transform.rotation.eulerAngles.y;
        //Spotlight.transform.eulerAngles = new Vector3(Spotlight.transform.eulerAngles.x, Character.transform.eulerAngles.y, 0);

        Vector3 position = new Vector3((float)(Math.Sin(DegreesToRadians(AngleFromZ)) * LightAdjustment.z),
            LightAdjustment.y, (float)(Math.Cos(DegreesToRadians(AngleFromZ)) * LightAdjustment.z));
        Spotlight.transform.position = Character.transform.position + position;
    }
}
