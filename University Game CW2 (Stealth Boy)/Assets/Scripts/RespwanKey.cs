using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespwanKey : MonoBehaviour
{
    // Script for respawning pickable objects when they fall in to the trap object.
    [SerializeField]
    private GameObject Respwan;

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.name == "Trap")
        {
            transform.position = Respwan.transform.position;
        }
    }
}
