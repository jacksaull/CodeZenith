using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class Comms : MonoBehaviour
{
    [SerializeField]
    internal string readString;
    private int portNum;

        SerialPort stream;
    // Start is called before the first frame update
    void Start()
    {
        //Initialise the serial port
        for (int i = 0; i < 10; i++)
        {
            portNum = i;
            stream = new SerialPort("COM" + portNum, 9600);

            if (!stream.IsOpen)
            {
                try
                {
                    Debug.Log("Trying to open serial port: " + "COM" + i);
                    stream.Open();

                    Debug.Log("Serial Port Open");

                    break;
                }
                catch (Exception ex)  // If serial port is not open send error message
                {
                    Debug.Log("Failed to open port. Error: " + ex);
                }
            }


        }


    }

    // Update is called once per frame
    void Update()
    {
        readString = stream.ReadLine();
    }
}
