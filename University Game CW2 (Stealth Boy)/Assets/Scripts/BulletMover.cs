using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    // A Script witch moves the bullet ones it is instantiated.
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Applying velocity to the rigidBody of the bullet.
        Rigidbody r = GetComponent<Rigidbody>();
        r.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }
}