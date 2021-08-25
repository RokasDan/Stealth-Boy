using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    // Simple switch for doors.
    public Door1 DoorObject;
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
