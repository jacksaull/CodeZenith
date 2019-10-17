using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Quaternion rotation;
    private float rotationX = 0;
    private Rigidbody go_rigidBody;
    private float speed = 10;
    private float smagnitude;

    public InfoUI ScriptUI;
    // Start is called before the first frame update
    void Start()
    {
        go_rigidBody = this.gameObject.GetComponent<Rigidbody>();
        go_rigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {

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
