using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionScript : MonoBehaviour
{
    // Script used to show and stop showing training canvases to players when they enter the question switch.
    [SerializeField]
    private GameObject TrainingScreen;
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.gameObject.name == "Player")
        {
            TrainingScreen.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.transform.gameObject.name == "Player")
        {
            TrainingScreen.SetActive(false);
        }
    }
}
