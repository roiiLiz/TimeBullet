using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    private bool isPaused = false;
    private float currentTimeScale = 1f;
    public bool IsPaused { get { return isPaused; } }

    public static PauseManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        ActivatePause(isPaused);
    }

    private void ActivatePause(bool isPaused)
    {
        if (isPaused)
        {
            currentTimeScale = Time.timeScale;
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = currentTimeScale;
        }

        pauseMenu.SetActive(isPaused);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}
