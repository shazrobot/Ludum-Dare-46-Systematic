using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody Character;
    public double AngleFromX;
    public double MoveForce;
    public double TurnRate;

    public double DegreesToRadians(double degrees)
    {
        return (Math.PI / 180) * degrees;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AngleFromX = Character.transform.rotation.eulerAngles.y;
        if (Input.GetKey("w")) {
            Character.AddForce(-transform.right*(float)MoveForce * Time.deltaTime);
        }
        if (Input.GetKey("a")) {
            Vector3 Rotation = new Vector3(0, -(float)TurnRate*Time.deltaTime, 0);
            Character.transform.Rotate(Rotation);
        }
        if (Input.GetKey("s")) {
            Character.AddForce(transform.right*(float)MoveForce*Time.deltaTime);

        }
        if (Input.GetKey("d")) {
            Vector3 Rotation = new Vector3(0, (float)TurnRate * Time.deltaTime, 0);
            Character.transform.Rotate(Rotation);
        }
        if (Input.GetKey("q")) {
            Character.AddForce(-transform.forward * (float)MoveForce * Time.deltaTime);
        }
        if (Input.GetKey("e")) {
            Character.AddForce(transform.forward * (float)MoveForce * Time.deltaTime);
        }

            Character.freezeRotation = true;
    }
}
