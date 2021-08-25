using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevelThree : MonoBehaviour
{
    // Checking if the finish of level two is reached and opening level three.
    public LevelManager LevelManager;
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.gameObject.name == "Player")
        {
            LevelManager.LevelTwoPassed = true;
        }
    }
}
