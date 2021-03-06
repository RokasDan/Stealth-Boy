using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Door opening script for doors that are already rotated 90 degrees.
    
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
        StartCoroutine(DoorAnimation(0, 100));
    }

    public void Close()
    {
        StartCoroutine(DoorAnimation(90, 100));
    }
}
