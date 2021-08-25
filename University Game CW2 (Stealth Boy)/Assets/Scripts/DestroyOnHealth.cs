using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyOnHealth : MonoBehaviour
{
    // The Script which manages the health of the typical Enemy character. It also controls the sound when the enemy
    // gets hit.
    public AudioSource DamageSound;
    public float Health = 50f;
    public float Damage = 10f;
    public GameObject Death;
    public GameObject DamageBar;

    private void Start()
    {
        // Getting the sound source component of the boss Character.
        DamageSound = GetComponent<AudioSource>();
    }
    
    // Checking for sword collisions from the player sword attacks. If the tag from the collision is Sword then
    // the enemy is damaged and the damaged sound is played, also the damage tag is instantiated.
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Sword"))
        {
            DamageSound.Play();
            DestroyObject(col.gameObject);
            Health = Health - Damage;
            Instantiate(DamageBar, transform.position, Quaternion.identity);
            
            // If health is smaller or equal to zero the enemy dies.
            if (Health <= 0)
            {
                DestroyObject(col.gameObject);
                DestroyObject(gameObject);
                Instantiate(Death, transform.position, transform.rotation);
            }
        }
    }
}
