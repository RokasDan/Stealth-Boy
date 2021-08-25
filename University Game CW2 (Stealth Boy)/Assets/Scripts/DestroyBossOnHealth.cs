using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyBossOnHealth : MonoBehaviour
{
    // The Script which manages the health of the Boss Enemy character. It also controlles the sound when the character
    // gets hit. It also keeps track of the health and send the information to a canvas. It also disables the player
    // objects when the player wins. The script also activates the finish screen.

    public Text BossHealth;
    public float Health = 50f;
    public float Damage = 10f;
    public GameObject Death;
    public GameObject DamageBar;
    public GameObject Player;
    public GameObject FinishScreen;
    public GameObject Teleport;
    public AudioSource DamageSound;

    private void Start()
    {
        // Getting the sound source component of the boss Character.
        DamageSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Keeping track of boss health and printing it on the canvas screen.
        BossHealth.text = "Boss Health " + Health + " %";
    }

    // Checking for sword collisions from the player sword attacks. If the tag from the collision is Sword then
    // the boss is damaged and the damaged sound is played, also the damage tag is instantiated.
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Sword"))
        {
            DamageSound.Play();
            DestroyObject(col.gameObject);
            Health = Health - Damage;
            Instantiate(DamageBar, transform.position, Quaternion.identity);

            // If health is smaller or equal to zero the boss dies. Player win screen is active and the player objects
            // are deactivated.
            if (Health <= 0)
            {
                Instantiate(Teleport, Player.transform.position, Player.transform.rotation);
                FinishScreen.SetActive(true);
                Player.GetComponent<CharacterController>().enabled = false;
                Player.GetComponent<PlayerMover>().enabled = false;
                Player.transform.GetChild(0).gameObject.SetActive(false);

                BossHealth.enabled = false;
                DestroyObject(col.gameObject);
                DestroyObject(gameObject);
                Instantiate(Death, transform.position, transform.rotation);
            }
        }
    }
}