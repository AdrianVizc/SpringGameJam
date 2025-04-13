using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject loseScreenPanel;

    private void Start()
    {
        loseScreenPanel.SetActive(false);
    }

    public void CheckIfLostGame()
    {
        Time.timeScale = 0f;
        loseScreenPanel.SetActive(true);
  
    }
}
