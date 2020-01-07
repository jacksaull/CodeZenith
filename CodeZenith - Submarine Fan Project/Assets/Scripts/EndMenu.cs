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
    public PlayerMovement playerMovement;
    public CameraTrack cameraTrack;
    public UI ui;
    public Comms comms;

    private int timeScore;
    private int healthScore;
    private int sumScore;
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
        healthScore = finalHealth.health * 25;
        int.TryParse(finalTime.text, out timeScore);
        sumScore = healthScore + timeScore;
        Time.timeScale = 0;
        AudioSources.GetComponents<AudioSource>()[0].volume = 0.20f;
        AudioSources.GetComponents<AudioSource>()[1].volume = 0.10f;
        AudioSources.GetComponents<AudioSource>()[3].volume = 0.20f;
        EndMenuPanel.SetActive(true);
        finalScore.GetComponent<TMPro.TextMeshProUGUI>().text = sumScore.ToString();
        playerMovement.acceptInput = false;
        cameraTrack.track = false;
        ui.countDown = false;
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
        comms.closePort();    
    }
}
