using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Manager : MonoBehaviour
{
    public GameObject PauseCanvas;
    bool Paused = false;

    void Start()
    {
        PauseCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Paused == true)
            {
                Time.timeScale = 1.0f;
                PauseCanvas.gameObject.SetActive(false);
                Paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                PauseCanvas.gameObject.SetActive(true);
                Paused = true;
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        PauseCanvas.gameObject.SetActive(false);
    
    }

    public void Quit()
    {
        Application.Quit();
    }
}
