using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevelFour : MonoBehaviour
{
    // Checking if level three finish is reached and opening the boss level.
    public LevelManager LevelManager;
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.gameObject.name == "Player")
        {
            LevelManager.LevelThreePassed = true;
        }
    }
}
