using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTag : MonoBehaviour
{
    // Script which raises the Damaged tag up in the air once something is damage.
    // Update is called once per frame
    void Update()
    {
        // Changing the transform Y axis of the Damage Tag Object.
        transform.Translate(Vector3.up * Time.deltaTime * 5f, Space.World);
    }
}