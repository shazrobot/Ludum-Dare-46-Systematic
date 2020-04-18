using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpotlightMouseFocus : MonoBehaviour
{
    public Light spotlight;
    public Camera Camera;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 WorldPoint = Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000));

        
        //Vector3 initialRot = spotlight.transform.eulerAngles;

        Vector3 Direction = WorldPoint - spotlight.transform.position;
        Debug.Log(WorldPoint);

        spotlight.transform.rotation = Quaternion.LookRotation(Direction);
        //Vector3.RotateTowards(initialRot, MousePoint, 10, 10);
        //spotlight.transform.eulerAngles = initialRot;

        // Draw a ray pointing at our target in
        //Debug.DrawRay(spotlight.transform.position, new Vector3(0, 0, 0), Color.red, 10);
    }
}
