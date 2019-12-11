using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuPanel;
    public GameObject AudioSources;
    private float MusicVolume;
    private float SonarVolume;
    private float EngineVolume;
    private float AmbienceVolume;
    private bool paused = false;
    void Start()
    {
        PauseMenuPanel.SetActive(false);
        MusicVolume = AudioSources.GetComponents<AudioSource>()[0].volume;
        SonarVolume = AudioSources.GetComponents<AudioSource>()[1].volume;
        AmbienceVolume = AudioSources.GetComponents<AudioSource>()[3].volume;
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (paused == false)
            {
                PauseMenuPanel.SetActive(true);
                paused = true;
            }
            else if (paused == true)
            {
                PauseMenuPanel.SetActive(false);
                paused = false;
            }
        }
        if (paused == true)
        {
            Time.timeScale = 0;
            AudioSources.GetComponents<AudioSource>()[0].volume = 0.20f;
            AudioSources.GetComponents<AudioSource>()[1].volume = 0.10f;
            AudioSources.GetComponents<AudioSource>()[3].volume = 0.20f;
        }
        else if (paused == false)
        {
            Time.timeScale = 1;
            AudioSources.GetComponents<AudioSource>()[0].volume = MusicVolume;
            AudioSources.GetComponents<AudioSource>()[1].volume = SonarVolume;
            AudioSources.GetComponents<AudioSource>()[3].volume = AmbienceVolume;
        }
    }

    public void QuitLevel()
    {
       SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void ContinueLevel()
    {
        PauseMenuPanel.SetActive(false);
        paused = false;
    }
}
