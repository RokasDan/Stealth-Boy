using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    // Door opening script for doors that require two keys to be opened.
    public bool button1 = false;
    public bool button2 = false;
    
    // Rotating the door.
    private IEnumerator DoorAnimation(int TragetAngle, int AnimationSpeed)
    {
        for (int r = 0; r < AnimationSpeed; r += 1)
        {
            transform.localEulerAngles = new Vector3(0,
                Mathf.LerpAngle(transform.localEulerAngles.y, TragetAngle, 5f / AnimationSpeed), 0);
            yield return null;
        }
    }
    
    // Functions for opening and closing the door. These are referenced within the switch scripts.
    public void Open()
    {
        StartCoroutine(DoorAnimation(90, 100));
    }

    public void Close()
    {
        StartCoroutine(DoorAnimation(0, 100));
    }
    
    // Functions which is checking if both switches are interacting with keys.
    void DoubleKeyDoor()
    {
        if (button1 == true && button2 == true)
        {
            StartCoroutine(DoorAnimation(90, 100));
        }
        else
        {
            StartCoroutine(DoorAnimation(0, 100));
        }
    }
    
    // Calling the function and checking for the two switch collisions.
    private void Update()
    {
        DoubleKeyDoor();
    }
}
