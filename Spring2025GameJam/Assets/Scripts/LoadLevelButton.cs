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
        Debug.Log(buttonNameNumber);
        levels = GameObject.Find("LobbyManager").GetComponent<MainMenuButtons>().levels;
        foreach (string level in levels)
        {
            Debug.Log(level.Substring(5));
            if (level.Substring(6) == buttonNameNumber)
            {
                SceneManager.LoadScene(level);
            }
        }
    }
}
