using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    // Script that sees if the player is being damaged by small guns or spikes.
    // This script also instantiates the death of the player once the conditions are right ones.
    [Header("Visuals")]
    [SerializeField]
    private GameObject DamageBar;
    [SerializeField]
    private GameObject DeathSmoke;
    [SerializeField]
    private GameObject DeathExplosion;
    
    [Header("After Death")]
    [SerializeField]
    private GameObject DeathScreen;

    [Header("Player Stats")]
    [SerializeField]
    private float Health = 100f;
    
    [Header("Weapon Damage")]
    [SerializeField]
    private float Bullets = 40f;
    
    [SerializeField]
    private float Rockets = 100f;

    [SerializeField]
    private Transform characterBody;

    private CharacterController MyController;
    private PlayerMover MyMover;
    
    [Header("Weapon Damage")]
    public AudioSource DamageSound;
    private void Start()
    {
        DamageSound = GetComponent<AudioSource>();
        MyController = GetComponent<CharacterController>();
        MyMover = GetComponent<PlayerMover>();
    }
    
    private void OnTriggerEnter(Collider otherCollider)
    {
        // Checking for collisions with bullets.
        if (otherCollider.gameObject.CompareTag("Bullets"))
        {
            // Play the damage sound and removing health.
            DamageSound.Play();
            DestroyObject(otherCollider.gameObject);
            Health = Health - Bullets;
            Instantiate(DamageBar, transform.position, Quaternion.identity);
            {
                // if health lower or equal to 0 player dies.
                if (Health <= 0)
                {
                    Death();
                }
            }
        }
        
        if (otherCollider.gameObject.CompareTag("Spike"))
        {
            // If player is touched by a spice player dies.
            Death();
        }
    }

    public void ExplosionDestroy()
    {
        // Function used within the rocket script if the player is in the explosion radius.
        Death();
    }

    void Death()
    {
        // What happens to the player when he dies.
        // Instantiating the death menu, FX and sounds.
        // Turning off the other player objects.
        Instantiate(DeathSmoke, transform.position, transform.rotation);
        Instantiate(DeathExplosion, transform.position, transform.rotation);
        DeathScreen.SetActive(true);
        MyMover.enabled = false;
        MyController.enabled = false;
        characterBody.gameObject.SetActive(false);
    }
}
