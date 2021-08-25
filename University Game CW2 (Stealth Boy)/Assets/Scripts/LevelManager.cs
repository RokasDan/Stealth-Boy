using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManagerData", menuName = "ScriptableObjects/LevelManager",order = 1)]
public class LevelManager : ScriptableObject
{
    // Scriptable object script for checking if the player has passed specific levels.
    public bool LevelOnePassed = false;
    public bool LevelTwoPassed = false;
    public bool LevelThreePassed = false;

    public void LevelOne()
    {
        LevelOnePassed = true;
    }
    
    public void LevelTwo()
    {
        LevelTwoPassed = true;
    }
    
    public void LevelThree()
    {
        LevelThreePassed = true;
    }
}
