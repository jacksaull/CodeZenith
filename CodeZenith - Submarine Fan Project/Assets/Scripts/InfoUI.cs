using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour
{
    public Text fanSpeed;
    public Text playerSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void updateInfo(float Speed)
    {
        playerSpeed.text = Speed.ToString("f1");
    }
}
