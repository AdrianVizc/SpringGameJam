using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject WinScreenPanel;
    [SerializeField] private GameObject GrayStar;
    [SerializeField] private GameObject GoldStar;
    [SerializeField] private Transform starManager;
    [SerializeField] private float firstStarRequirement;
    [SerializeField] private float secondStarRequirement;
    [SerializeField] private float thirdStarRequirement;

    [HideInInspector] public float scrapPercentage;


    private void Start()
    {
        WinScreenPanel.SetActive(false);
    }
    public void CheckScrapPercentage()
    {
        if (scrapPercentage == thirdStarRequirement)
        {
            Instantiate(GoldStar, starManager);
            Instantiate(GoldStar, starManager);
            Instantiate(GoldStar, starManager);
        }
        else if (scrapPercentage < thirdStarRequirement && scrapPercentage >= secondStarRequirement)
        {
            Instantiate(GoldStar, starManager);
            Instantiate(GoldStar, starManager);
            Instantiate(GrayStar, starManager);
        }
        else if (scrapPercentage < secondStarRequirement && scrapPercentage >= firstStarRequirement)
        {
            Instantiate(GoldStar, starManager);
            Instantiate(GrayStar, starManager);
            Instantiate(GrayStar, starManager);
        }
        else if (scrapPercentage < 50)
        {
            Instantiate(GrayStar, starManager);
            Instantiate(GrayStar, starManager);
            Instantiate(GrayStar, starManager);
        }
    }

    public void CheckAnimtionFinished()
    {
        WinScreenPanel.SetActive(true);
    }
}
