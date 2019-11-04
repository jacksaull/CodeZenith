using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Rotor;
    private Quaternion rotation;
    private float rotationX = 0;
    private Rigidbody go_rigidBody;
    private float speed = 5;
    private float smagnitude;

    private float currentRotation = 0;

    private float rotorSpeed = 0;
    private float rotorRate = 5f;
    private float currentRotorRotation;
    public InfoUI ScriptUI;

    //SerialPort stream = new SerialPort(DEVICE NAME, 9600); 
    void Start()
    {
        go_rigidBody = this.gameObject.GetComponent<Rigidbody>();
        go_rigidBody.useGravity = false;
        Rotor.transform.localRotation = Quaternion.Euler(-180, 0, 0);

        //stream.Open();
    }

    void Update()
    {
        //string controllerValue = stream.ReadLine();
        rotorSpeed = rotorRate * smagnitude;
        Rotor.transform.Rotate(0, 0, rotorSpeed, Space.Self);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
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
        else if (Input.GetMouseButton(1))
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

            if (this.transform.rotation.x >= 30)
            {
                rotation = Quaternion.Euler(30, 90, 180);
                this.gameObject.transform.rotation = rotation;
            }
        }

        if (Input.GetKey("w"))
        {
            go_rigidBody.AddForce(transform.forward * speed);
            smagnitude = go_rigidBody.velocity.magnitude;

            ScriptUI.updateInfo(smagnitude);
        }

        if (smagnitude > 0)
        {
            go_rigidBody.drag = 1.7f;
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
