using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Simple switch for doors.
    public Door DoorObject;
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Key"))
        {
            DoorObject.Open();
        }
        
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.CompareTag("Key"))
        {
            DoorObject.Close();
        }
    }
}
