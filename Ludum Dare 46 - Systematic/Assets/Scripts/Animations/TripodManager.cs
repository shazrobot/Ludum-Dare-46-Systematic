using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TripodManager : MonoBehaviour
{
    private float SamplingDistance = 1f;
    private float LearningRate = 20f;
    public float[] Angles = { 0f, 0f, 0f, 0f};
    public List<TripodJoint> Leg1;
    public List<TripodJoint> Leg2;
    public List<TripodJoint> Leg3;
    public GameObject Character;
    public GameObject TargetBall;

    public Vector3 ForwardKinematics(float[] angles, List<TripodJoint> Joints)
    {
        Vector3 prevPoint = Joints[0].transform.position;
        //Vector3 rotation = new Vector3(1, 1, 1);
        Quaternion rotation = Quaternion.identity;
        rotation *= Character.transform.rotation;
        for (int i = 1; i < Joints.Count; i++)
        {
            // Rotates around a new axis
            rotation *= Quaternion.AngleAxis(angles[i - 1], Joints[i - 1].Axis);
            //Debug.Log(rotation* Joints[i].StartOffset);
            Vector3 nextPoint = prevPoint + (rotation * Joints[i].StartOffset);

            prevPoint = nextPoint;
        }
        return prevPoint;
    }
    public float DistanceFromTarget(Vector3 target, float[] angles, List<TripodJoint> Joints)
    {
        Vector3 point = ForwardKinematics(angles, Joints);
        return Vector3.Distance(point, target);        
    }

    public float PartialGradient(Vector3 target, float[] angles, int i, List<TripodJoint> Joints)
    {
        //Saves the angle,
        //it will be restored later
        float angle = angles[i];

        // Gradient : [F(x+SamplingDistance) - F(x)] / h
        float f_x = DistanceFromTarget(target, angles, Joints);

        angles[i] += SamplingDistance;
        float f_x_plus_d = DistanceFromTarget(target, angles, Joints);

        float gradient = (f_x_plus_d - f_x) / SamplingDistance;

        // Restores
        angles[i] = angle;
        return gradient;
    }


    public void InverseKinematics (Vector3 target, float[] angles, List<TripodJoint> Joints)
    {
        for (int i = 0; i < Joints.Count; i++)
        {
            // Gradient descent
            // Update : Solution -= LearningRate * Gradient
            float gradient = PartialGradient(target, angles, i, Joints);
            //Debug.Log(gradient);
            angles[i] -= LearningRate * gradient;
            Joints[i].SetMagintude(angles[i]);
        }
    }

    public float[] ReturnAngles(List<TripodJoint> Joints)
    {
        int i = 0;
        foreach (TripodJoint Joint in Joints)
        {
            Angles[i] = (Joint.Magnitude);
            Debug.Log(Angles[i]);
            i++;
        }
        return Angles;
    }

    public float[] SetAngles(List<TripodJoint> Joints, float[] Angles)
    {
        int i = 0;
        foreach (TripodJoint Joint in Joints)
        {
            Joint.SetMagintude(Angles[i]);
            i++;
        }
        //Debug.Log(Angles[0]);
        return Angles;
    }



    void FixedUpdate()
    {
        InverseKinematics(TargetBall.transform.position, ReturnAngles(Leg3) , Leg3);
        //SetAngles(Leg3, Angles);
        //Debug.Log(ForwardKinematics(ReturnAngles(Leg3), Leg3));


    }
}
