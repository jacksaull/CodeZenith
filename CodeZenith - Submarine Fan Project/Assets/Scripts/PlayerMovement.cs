﻿using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public GameObject Rotor;
    private Quaternion rotation;
    private float rotationX = 0;
    private Rigidbody go_rigidBody;
    private float speed = 3.5f;
    private float smagnitude;

    private float currentRotation = 0;

    private float rotorSpeed = 0;
    private float rotorRate = 5f;
    private float currentRotorRotation;
    public InfoUI ScriptUI;
    private Comms arduino; //Added

    void Start()
    {
        go_rigidBody = this.gameObject.GetComponent<Rigidbody>();
        go_rigidBody.useGravity = false;
        Rotor.transform.localRotation = Quaternion.Euler(-180, 0, 0);
        arduino = GetComponent<Comms>(); // added
    }

    void Update()
    {
        rotorSpeed = rotorRate * smagnitude;
        Rotor.transform.Rotate(0, 0, rotorSpeed, Space.Self);
    }

    private void FixedUpdate()
    {
        go_rigidBody.AddForce(transform.forward * 2);
        smagnitude = go_rigidBody.velocity.magnitude;

        //if (this.transform.position.y > 6.5)
        //{
        //    this.transform.position = new Vector3(transform.position.x, 6.5f, transform.position.z);
        //}

        //if (Input.GetMouseButton(0))
        //{
        //    if (currentRotation == -30)
        //    {
        //        rotation = Quaternion.Euler(-30, 90, 180);
        //        this.gameObject.transform.rotation = rotation;
        //    }
        //    else
        //    {
        //        rotationX -= 0.5f;
        //        currentRotation -= 0.5f;
        //        rotation = Quaternion.Euler(rotationX, 90, 180);
        //        this.gameObject.transform.rotation = rotation;
        //    }
        //}
        //else if (Input.GetMouseButton(1))
        //{
        //    if (currentRotation == 30)
        //    {
        //        rotation = Quaternion.Euler(30, 90, 180);
        //        this.gameObject.transform.rotation = rotation;
        //    }
        //    else
        //    {
        //        rotationX += 0.5f;
        //        currentRotation += 0.5f;
        //        rotation = Quaternion.Euler(rotationX, 90, 180);
        //        this.gameObject.transform.rotation = rotation;
        //    }
        //}


        if (arduino.readString == "Submarine going up")
        {
            if (currentRotation == -30)
            {
                rotation = Quaternion.Euler(-30, 90, 180);
                this.gameObject.transform.rotation = rotation;
            }
            else
            {
                rotationX -= 0.5f;
                currentRotation -= 0.5f;
                rotation = Quaternion.Euler(rotationX, 90, 180);
                this.gameObject.transform.rotation = rotation;
            }
        }
        else if (arduino.readString == "Submarine going down")
        {
            if (currentRotation == 30)
            {
                rotation = Quaternion.Euler(30, 90, 180);
                this.gameObject.transform.rotation = rotation;
            }
            else
            {
                rotationX += 0.5f;
                currentRotation += 0.5f;
                rotation = Quaternion.Euler(rotationX, 90, 180);
                this.gameObject.transform.rotation = rotation;
            }
        }
        else if (arduino.readString == "Submarine is level")
        {
            if (currentRotation < 0)
            {
                rotationX += 0.5f;
                currentRotation += 0.5f;
                rotation = Quaternion.Euler(rotationX, 90, 180);
                this.gameObject.transform.rotation = rotation;
            }
            else if (currentRotation > 0)
            {
                rotationX -= 0.5f;
                currentRotation -= 0.5f;
                rotation = Quaternion.Euler(rotationX, 90, 180);
                this.gameObject.transform.rotation = rotation;
            }
        }

        /*------------------------------------------------------------
         * ----------------------------------------------------------
         */
        if (Input.GetKey("w"))
        {
            go_rigidBody.AddForce(transform.forward * speed);
            smagnitude = go_rigidBody.velocity.magnitude;

            ScriptUI.updateInfo(smagnitude);
        }

        if (smagnitude > 0)
        {
            go_rigidBody.drag = 1.4f;
            smagnitude = go_rigidBody.velocity.magnitude;

            ScriptUI.updateInfo(smagnitude);
        }
        else
        {
            go_rigidBody.drag = 1;
            return;
        }
    }
}
