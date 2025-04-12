using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour
{
    private List<string> levels;

    public void LoadLevel()
    {
        string buttonName = gameObject.name;
        string buttonNameNumber = buttonName.Substring(buttonName.Length - 1);
        levels = GameObject.Find("LobbyManager").GetComponent<MainMenuButtons>().levels;
        foreach (string level in levels)
        {
            if (level.Substring(level.Length - 1) == buttonNameNumber)
            {
                SceneManager.LoadScene(level);
            }
        }
    }
}
