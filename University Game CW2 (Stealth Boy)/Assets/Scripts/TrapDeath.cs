using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDeath : MonoBehaviour
{
    // Player death script which activates when the player touches the trap. 
    [SerializeField]
    private GameObject DeathScreen;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject Death;

    private void OnTriggerEnter(Collider hit)
    {
        // Instantiating the FX for the player death. Turning on the death screen and turning of the player objects.
        if (hit.transform.gameObject.name == "Player")
        {
            Instantiate(Death, Player.transform.position, Player.transform.rotation);
            DeathScreen.SetActive(true);
            Player.GetComponent<CharacterController>().enabled = false;
            Player.GetComponent<PlayerMover>().enabled = false;
            Player.transform.GetChild(0).gameObject.SetActive(false);
            
        }
        
    }
}
