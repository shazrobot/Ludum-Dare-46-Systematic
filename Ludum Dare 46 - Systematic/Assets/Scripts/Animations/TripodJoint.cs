using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripodJoint : MonoBehaviour
{
    public Vector3 Axis;
    public Vector3 StartOffset;
    public float Magnitude;

    public void SetMagintude(float angle)
    {
        Magnitude = angle;
        transform.localEulerAngles = new Vector3(Axis[0] * Magnitude, Axis[1] * Magnitude, Axis[2] * Magnitude);
        //Debug.Log(new Vector3(Axis[0] * Magnitude, Axis[1] * Magnitude, Axis[2] * Magnitude));
    }

    void Awake()
    {
        StartOffset = transform.localPosition;
    }
}
