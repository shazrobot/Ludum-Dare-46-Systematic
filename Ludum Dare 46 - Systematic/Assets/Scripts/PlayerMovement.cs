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
            //Vector3 Velocity = new Vector3((float)(Math.Sin(DegreesToRadians(AngleFromZ)) * MoveForce * Time.deltaTime), 0, (float)(Math.Cos(DegreesToRadians(AngleFromZ)) * MoveForce * Time.deltaTime));
            Character.AddForce(-transform.right*(float)MoveForce * Time.deltaTime);
            //Character.velocity += Velocity;
        }
        if (Input.GetKey("a")) {
            Vector3 Rotation = new Vector3(0, -(float)TurnRate*Time.deltaTime, 0);
            Character.transform.Rotate(Rotation);
            //Character.AddTorque(Rotation);
        }
        if (Input.GetKey("s")) {
            //Vector3 Velocity = new Vector3(-(float)(Math.Sin(DegreesToRadians(AngleFromZ)) * MoveForce * Time.deltaTime), 0, -(float)(Math.Cos(DegreesToRadians(AngleFromZ)) * MoveForce * Time.deltaTime));
            //Character.velocity += Velocity;
            Character.AddForce(transform.right*(float)MoveForce*Time.deltaTime);

        }
        if (Input.GetKey("d")) {
            Vector3 Rotation = new Vector3(0, (float)TurnRate * Time.deltaTime, 0);
            Character.transform.Rotate(Rotation);
            //Character.AddTorque(Rotation);
        }

        Character.freezeRotation = true;
    }
}
