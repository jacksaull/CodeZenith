using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI LevelName;
    private int timeleft = 100;

    void Start()
    {
        LevelName.GetComponent<TMPro.TextMeshProUGUI>().text = SceneManager.GetActiveScene().name;
        InvokeRepeating("Time", 0, 1.0f);
    }

    
    void Update()
    {
        
    }

    void Time()
    {
        timeleft -= 1;
        Timer.text = timeleft.ToString();
    }
}
