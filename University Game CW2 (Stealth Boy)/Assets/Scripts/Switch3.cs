using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch3 : MonoBehaviour
{
    // Simple switch for a double key door. Instead for opening the door it sends a bool value telling a 
    // door that one key is on the switch.
    public Door2 DoorObject;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Key"))
        {
            DoorObject.button1 = true;
        }
        
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.CompareTag("Key"))
        {
            DoorObject.button1 = false;
        }
    }
}
