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
    private double TrueMoveForce;

    public double DegreesToRadians(double degrees)
    {
        return (Math.PI / 180) * degrees;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("left shift"))
        {
            TrueMoveForce = MoveForce * 2;
        }
        else
        {
            TrueMoveForce = MoveForce;
        }
        AngleFromX = Character.transform.rotation.eulerAngles.y;
        if (Input.GetKey("w")) {
            Character.AddForce(-transform.right*(float)TrueMoveForce * Time.deltaTime);
        }
        if (Input.GetKey("a")) {
            Vector3 Rotation = new Vector3(0, -(float)TurnRate*Time.deltaTime, 0);
            Character.transform.Rotate(Rotation);
        }
        if (Input.GetKey("s")) {
            Character.AddForce(transform.right*(float)TrueMoveForce * Time.deltaTime);

        }
        if (Input.GetKey("d")) {
            Vector3 Rotation = new Vector3(0, (float)TurnRate * Time.deltaTime, 0);
            Character.transform.Rotate(Rotation);
        }
        if (Input.GetKey("q")) {
            Character.AddForce(-transform.forward * (float)TrueMoveForce * Time.deltaTime);
        }
        if (Input.GetKey("e")) {
            Character.AddForce(transform.forward * (float)TrueMoveForce * Time.deltaTime);
        }

            Character.freezeRotation = true;
    }
}
