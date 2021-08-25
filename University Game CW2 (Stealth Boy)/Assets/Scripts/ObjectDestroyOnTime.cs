using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script used for destroying game objects after a certain amount of time.
//The script is specifically utilized for destruction of a sword which the 
//main player char uses. After each swing the sword need to disapear hence i made this script.
public class ObjectDestroyOnTime : MonoBehaviour
{
    
    public float TimeTillDestroy = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(TimeTillDestroy);
        Destroy(gameObject);
    }
  
}
