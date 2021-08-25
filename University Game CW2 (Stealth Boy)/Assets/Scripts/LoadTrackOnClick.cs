using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTrackOnClick : MonoBehaviour
{
    public void LoadLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
    }
}
