using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    public GameObject EndMenuPanel;
    public GameObject AudioSources;
    private float MusicVolume;
    private float SonarVolume;
    private float EngineVolume;
    private float AmbienceVolume;

    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI finalTime;
    public Health finalHealth;

    public string nextLevelName;
    private bool paused = false;
    void Start()
    {
        EndMenuPanel.SetActive(false);
        MusicVolume = AudioSources.GetComponents<AudioSource>()[0].volume;
        SonarVolume = AudioSources.GetComponents<AudioSource>()[1].volume;
        AmbienceVolume = AudioSources.GetComponents<AudioSource>()[3].volume;
    }

    void Update()
    {

    }

    public void FinishLevel()
    {
        Time.timeScale = 0;
        AudioSources.GetComponents<AudioSource>()[0].volume = 0.20f;
        AudioSources.GetComponents<AudioSource>()[1].volume = 0.10f;
        AudioSources.GetComponents<AudioSource>()[3].volume = 0.20f;
        EndMenuPanel.SetActive(true);
        finalScore.GetComponent<TMPro.TextMeshProUGUI>().text = ((finalHealth.health*25) + finalScore.text);
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
    }
}
