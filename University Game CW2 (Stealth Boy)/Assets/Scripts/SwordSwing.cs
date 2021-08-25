using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    // Sword swing script. This script rotates the sword object around the player character. 
    public float SwingSpeed = 5.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * SwingSpeed * Time.deltaTime);
    }
}
