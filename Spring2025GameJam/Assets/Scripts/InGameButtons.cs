using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtons : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuObject;
    [SerializeField] private GameObject loseScreenPanel;
    [SerializeField] private GameObject winScreenPanel;
    [SerializeField] private string nextLevel;

    private bool isPaused;

    private void Start()
    {
        pauseMenuObject.SetActive(false);

        isPaused = false;
    }

    private void Update()
    {
        PauseButton();
    }

    public void MainMenuButton()
    {
        if (Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene("MainMenu");
    }

    private void PauseButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused && !loseScreenPanel.activeSelf && !winScreenPanel.activeSelf)
            {
                pauseMenuObject.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
            else if (isPaused)
            {
                pauseMenuObject.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }            
        }       
    }

    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene();
        
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
