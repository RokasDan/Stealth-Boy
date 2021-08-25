using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    // Script for opening the win screen when the player reaches the finish switch object.
    // Script also disables player object so the game can't interact with it anymore.
    [SerializeField]
    private GameObject FinishScreen;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject Teleport;

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.gameObject.name == "Player")
        {
            Instantiate(Teleport, Player.transform.position, Player.transform.rotation);
            FinishScreen.SetActive(true);
            Player.GetComponent<CharacterController>().enabled = false;
            Player.GetComponent<PlayerMover>().enabled = false;
            Player.transform.GetChild(0).gameObject.SetActive(false);
            
        }
        
    }
}
