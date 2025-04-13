using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAnimationHandler : MonoBehaviour
{
    [HideInInspector] public bool animationFinished;

    public void AlertObservers(string message)
    {
        animationFinished = message.Equals("animationEnded");
    }
}
