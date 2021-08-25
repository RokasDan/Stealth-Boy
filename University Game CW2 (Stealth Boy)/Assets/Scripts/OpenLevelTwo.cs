using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevelTwo : MonoBehaviour
{
    // Checking if level one finish is reached if so level two is opened.
    public LevelManager LevelManager;
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.gameObject.name == "Player")
        {
            LevelManager.LevelOnePassed = true;
        }
    }
}
