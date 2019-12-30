using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public GameObject player;
    private float playerX;
    private float offset = 5.8f;
    public bool track;
    void Start()
    {
        track = true;
    }

    void LateUpdate()
    {
        if (track == true)
        {
            playerX = player.transform.position.x;
            transform.position = new Vector3(playerX + offset, transform.position.y, transform.position.z);
        }
        else if (track == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}