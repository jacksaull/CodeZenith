using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Comms comms;
    private Toggle inputControls;
    void Start()
    {
        PlayerPrefs.SetInt("Input", 1);
        Time.timeScale = 1;
        inputControls.isOn = false;
    }

    void Update()
    {
        playerMovement.acceptInput = false;
    }

    public void toggleInput()
    {
        if(PlayerPrefs.GetInt("Input") == 0)
        {
            PlayerPrefs.SetInt("Input", 1);
        }
        else if (PlayerPrefs.GetInt("Input") == 1)
        {
            PlayerPrefs.SetInt("Input", 0);
        }

        inputControls.isOn = !inputControls.isOn;
    }

    public void StartBut()
    {
        SceneManager.LoadScene("Sunlight Zone - 1", LoadSceneMode.Single);
        Debug.Log("Change Scene");
        comms.closePort();
    }

    public void QuitBut()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
