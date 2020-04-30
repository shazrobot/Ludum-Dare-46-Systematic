using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody Character;
    public double AngleFromX;
    public double MoveForce;
    public double JumpModifier;
    public double TurnRate;
    public float SprintModifier;
    private double TrueMoveForce;
    private bool Jumped = false;
    
    public void JumpReset()
    {
        Jumped = false;
    }
    public double DegreesToRadians(double degrees)
    {
        return (Math.PI / 180) * degrees;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("left shift"))
        {
            TrueMoveForce = MoveForce * SprintModifier;
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
        if (Input.GetKey("space") & !Jumped){
            Character.AddForce(transform.up * (float)(JumpModifier));
            Jumped = true;
        }

            Character.freezeRotation = true;
    }
}
