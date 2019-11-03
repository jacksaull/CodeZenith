using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public GameObject player;
    private float playerX;
    private float offset = 3.7f;
    void Start()
    {

    }

    void LateUpdate()
    {
        playerX = player.transform.position.x;
        transform.position = new Vector3(playerX+offset, transform.position.y, transform.position.z);
    }
}