using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public Transform SwordTransform;
    public GameObject Sword;
    public float AttackRate = 0.5f;
    public bool PlayerAttacked = false;
    public bool ItemPickedUp = false;

    private float nextSwing = 0.0f;
    private GameObject Weapon;

    private void Update()
    {
        UpdateRotation();
        UpdateAttack();
    }

    private void UpdateRotation()
    {
        // Tracking where the mouse is on the screen of the game. According to the mouse position we rotate
        // the player on the horizontal axis towards the mouse position.
        var playerTransform = transform;
        var playerPosition = playerTransform.position;

        var cameraPosition = cam.transform.position;

        var playerDistance = Vector3.Distance(cameraPosition, playerPosition);
        var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerDistance);

        var worldPosition = cam.ScreenToWorldPoint(mousePosition);
        worldPosition.y = playerPosition.y;

        var lookDirection = (worldPosition - playerPosition).normalized;
        var lookRotation = Quaternion.LookRotation(lookDirection);

        playerTransform.rotation = lookRotation;
    }

    private void UpdateAttack()
    {
        //Fire the sword attack
        if (Input.GetButtonDown("Fire1") && Time.time > nextSwing && PlayerAttacked == false && ItemPickedUp == false)
        {
            nextSwing = Time.time + AttackRate;
            Weapon = Instantiate(Sword, SwordTransform.position, SwordTransform.transform.rotation);

            // Making the Sword to stay with the player.
            Weapon.transform.SetParent(SwordTransform.transform);
        }
    }
}