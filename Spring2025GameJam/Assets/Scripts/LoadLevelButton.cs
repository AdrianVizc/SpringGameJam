using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class LoadLevelButton : MonoBehaviour
{
    private List<string> levels;

    public void LoadLevel()
    {
        string buttonName = gameObject.name;
        string buttonNameNumber = buttonName.Substring(9);
        levels = GameObject.Find("LobbyManager").GetComponent<MainMenuButtons>().levels;
        foreach (string level in levels)
        {
            if (level.Substring(6) == buttonNameNumber)
            {
                SceneManager.LoadScene(level);
            }
        }
    }
}
