using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplode : MonoBehaviour
{
    // Rocket Explotion script
    [SerializeField]
    private GameObject Explosion;
    
    [SerializeField]
    private float BlastRadius = 5f;
    
    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    void Explode()
    {
        // Instantiating explosion fx.
        Instantiate(Explosion, transform.position, transform.rotation);
        
        // Creating a Sphere collider and checking all of the colliders with in it.
        Collider[] colliders = Physics.OverlapSphere(transform.position, BlastRadius);
        
        // Checking for the player damage script from the list of colliders.
        foreach (Collider nearbyObject in colliders)
        {
            // If the object has the script activate the player explosion script.
            PlayerDamage player = nearbyObject.GetComponent<PlayerDamage>();
            if (player != null)
            {
                player.ExplosionDestroy();
            }
        }
        
        // Destroying the rocket.
        DestroyObject(gameObject);
    }
}
