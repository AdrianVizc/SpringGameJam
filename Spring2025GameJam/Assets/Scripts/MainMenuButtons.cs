using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private string gameScene;
    [SerializeField] private string level1;
    [SerializeField] private string level2;
    [SerializeField] private string level3;
    [SerializeField] private string level4;
    [SerializeField] private string level5;
    [SerializeField] private string level6;
    [Space]
    [SerializeField] private GameObject mainRivePanel;
    [SerializeField] private GameObject secondRivePanel;

    [HideInInspector]
    public List<string> levels = new List<string>();

    private void Awake()
    {   
        mainRivePanel.SetActive(true);
        secondRivePanel.SetActive(false);

        levels.Add(level1);
        levels.Add(level2);
        levels.Add(level3);
        levels.Add(level4);
        levels.Add(level5);
        levels.Add(level6);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowLevelSelectPanelButton()
    {
        mainRivePanel.SetActive(false);
        secondRivePanel.SetActive(true);
    }

    public void BackButton()
    {
        mainRivePanel.SetActive(true);
        secondRivePanel.SetActive(false);
    }
}
