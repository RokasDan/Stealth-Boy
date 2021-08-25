using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    // The gravity gun script which we did in in the labs.
    private GameObject heldObject = null;

    public GameObject Player;

    public LayerMask layerMask;

    public Transform holdposition;

    public bool Attacked = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ItemDrop();
    }

    private void FixedUpdate()
    {
        ItemUp();
    }

    void ItemDrop()
    {
        // Checking if the player is attacked. If so the gravity gun is not working anymore, also
        // Checking if the player is not pressing the item holding button. If not item is dropped.
        if (Input.GetMouseButtonUp(1) ^ Attacked == true)
        {
            if (heldObject != null)
            {
                heldObject.GetComponent<Rigidbody>().useGravity = true;
                heldObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                heldObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                heldObject.GetComponent<Rigidbody>().ResetInertiaTensor();
                heldObject = null;
                Player.GetComponent<PlayerController>().ItemPickedUp = false;
            }
        }
    }
    
    void ItemUp()
    {
        // Picking the item up.
        if (Input.GetMouseButton(1) & Attacked == false)
        {
            if (heldObject == null)
            {
                RaycastHit colliderHit;

                if (Physics.Raycast(transform.position, transform.forward, out colliderHit, 3.0f, layerMask))
                {
                    heldObject = colliderHit.collider.gameObject;
                    heldObject.GetComponent<Rigidbody>().useGravity = false;
                    Player.GetComponent<PlayerController>().ItemPickedUp = true;
                }
            }
            
        }

        if (heldObject != null)
        {
            heldObject.GetComponent<Rigidbody>().MovePosition(holdposition.position);
            heldObject.GetComponent<Rigidbody>().MoveRotation(holdposition.rotation);
        }
    }
}

