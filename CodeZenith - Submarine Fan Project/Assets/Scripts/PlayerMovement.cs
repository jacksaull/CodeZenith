using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Quaternion rotation;
    private float rotationX = 0;
    private Rigidbody go_rigidBody;
    private float speed = 10;
    private float smagnitude;

    public InfoUI ScriptUI;

    //SerialPort stream = new SerialPort(DEVICE NAME, 9600); 
    void Start()
    {
        go_rigidBody = this.gameObject.GetComponent<Rigidbody>();
        go_rigidBody.useGravity = false;

        //stream.Open();
    }

    void Update()
    {
        //string controllerValue = stream.ReadLine();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            rotationX -= 1;
            rotation = Quaternion.Euler(rotationX, 90, 90);
            this.gameObject.transform.rotation = rotation;

            Debug.Log("1");
        }
        else if (Input.GetMouseButton(1))
        {
            rotationX += 1;
            rotation = Quaternion.Euler(rotationX, 90, 90);
            this.gameObject.transform.rotation = rotation;

            Debug.Log("2");
        }

        if (Input.GetKey("w"))
        {
            go_rigidBody.AddForce(transform.forward * speed);
            smagnitude = go_rigidBody.velocity.magnitude;

            ScriptUI.updateInfo(smagnitude);
        }

        if (smagnitude > 0)
        {
            go_rigidBody.drag = 1.5f;
            smagnitude = go_rigidBody.velocity.magnitude;

            ScriptUI.updateInfo(smagnitude);
        }
        else
        {
            go_rigidBody.drag = 0;
            return;
        }
    }
}
