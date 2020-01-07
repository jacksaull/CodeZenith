using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    public GameObject DeathMenuPanel;
    public GameObject AudioSources;
    public Comms comms;
    private float MusicVolume;
    private float SonarVolume;
    private float EngineVolume;
    private float AmbienceVolume;
    public TextMeshProUGUI currentLevel;
    public UI ui;
    void Start()
    {
        DeathMenuPanel.SetActive(false);
        MusicVolume = AudioSources.GetComponents<AudioSource>()[0].volume;
        SonarVolume = AudioSources.GetComponents<AudioSource>()[1].volume;
        AmbienceVolume = AudioSources.GetComponents<AudioSource>()[3].volume;
    }

    void Update()
    {
     
    }

    public void Death()
    {
        ui.countDown = false;
        AudioSources.GetComponents<AudioSource>()[0].volume = 0.20f;
        AudioSources.GetComponents<AudioSource>()[1].volume = 0.10f;
        AudioSources.GetComponents<AudioSource>()[3].volume = 0.20f;
        DeathMenuPanel.SetActive(true);
    }
    public void QuitLevel()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void RetryLevel()
    {
        Time.timeScale = 1;
        AudioSources.GetComponents<AudioSource>()[0].volume = MusicVolume;
        AudioSources.GetComponents<AudioSource>()[1].volume = SonarVolume;
        AudioSources.GetComponents<AudioSource>()[3].volume = AmbienceVolume;
        SceneManager.LoadScene(currentLevel.text, LoadSceneMode.Single);
        comms.closePort();
    }
}
