using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    // Script from the labs to move the player object and make it jump.
    public float Jumphight = 10f;
    public float movespeed = 5.0f;
    
    private float verticalVelocity = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwardspeed = Input.GetAxis("Vertical") * movespeed;
        float lateralSpeed = Input.GetAxis("Horizontal") * movespeed;

        CharacterController characterController = GetComponent<CharacterController>();

        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            verticalVelocity = Jumphight;
        }

        Vector3 speed = new Vector3(lateralSpeed, verticalVelocity, forwardspeed);
        speed = transform.rotation * speed;
        characterController.Move(speed * Time.deltaTime);
    }
}
