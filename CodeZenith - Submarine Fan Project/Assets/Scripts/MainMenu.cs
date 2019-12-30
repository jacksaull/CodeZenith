﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public PlayerMovement playerMovement;
    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        playerMovement.acceptInput = false;
    }

    public void StartBut()
    {
        SceneManager.LoadScene("Sunlight Zone - 1", LoadSceneMode.Single);
        Debug.Log("Change Scene");
    }

    public void QuitBut()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
