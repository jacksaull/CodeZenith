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
    public bool countDown;

    void Start()
    {
        countDown = true;
        LevelName.GetComponent<TMPro.TextMeshProUGUI>().text = SceneManager.GetActiveScene().name;
        InvokeRepeating("Time", 0, 1.0f);
    }

    
    void Update()
    {
        
    }

    void Time()
    {
        if (countDown == true)
        {
            timeleft -= 1;
            Timer.text = timeleft.ToString();
        }
        else if (countDown == false)
        {

        }
    }
}
