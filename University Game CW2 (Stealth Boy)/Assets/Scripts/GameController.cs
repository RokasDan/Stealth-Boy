using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Game controller which tracks how many enemies are attacking or searching for the player.
    // Also from here the player can use the pause menu from this script
    public GameObject SpottedLight;
    public GameObject SearchingLight;
    public GameObject ShadowLight;
    public GameObject PlayerCharacter;
    public GameObject PauseMenu;

    private int spottedCount;
    private int searchingCount;
    private bool PauseOff = true;

    // Keeping track of how many enemies are attacking.
    public void IncrementSpotted()
    {
        spottedCount++;
    }
    // Keeping track of number of enemies who stopped attacking.
    public void DecrementSpotted()
    {
        spottedCount--;
    }
    // Keeping track of number of enemies who just entered the search state.
    public void IncrementSearching()
    {
        searchingCount++;
    }
    // Keeping the track how many enemies stopped the search or went in to attack state again.
    public void DecrementSearching()
    {
        searchingCount--;
    }


    // Start is called before the first frame update
    private void Awake()
    {
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGameMenu();
        }
    }

    void FixedUpdate()
    {
        // Calling all of the functions which are checking all of the enemies states.
        PlayerLost();
        PlayerSearch();
        PlayerAttacked();
    }

    void PlayerAttacked()
    {
        // If some one is attacking the player red spot light is on.
        if (spottedCount > 0)
        {
            SearchLightOff();
            SpottedLightOn();
        }
    }
    
    void PlayerSearch()
    {
        // If no one is attacking the player the search spot light is on.
        if (spottedCount == 0 && searchingCount > 0)
        {
            SpottedLightOff();
            SearchLightOn();
        }
    }

    void PlayerLost()
    {
        // If no one can see the player all of the lights are off apart from the typical white light.
        if (spottedCount == 0 && searchingCount == 0)
        {
            SearchLightOff();
        }
    }
    
    // When a single enemy spots player red light turns on and the player can't attack and pick up items.
    void SpottedLightOn()
    {
        ShadowLight.SetActive(false);
        SpottedLight.SetActive(true);
        SearchingLight.SetActive(false);
        PlayerCharacter.GetComponent<PlayerController>().PlayerAttacked = true;
        PlayerCharacter.GetComponent<GravityGun>().Attacked = true;
    }

    // When all enemies don't see the player the red light is off notifying the player of a search cool down.
    void SpottedLightOff()
    {
        SpottedLight.SetActive(false);
        SearchLightOn();
    }

    void SearchLightOn()
    {
        PlayerCharacter.GetComponent<PlayerController>().PlayerAttacked = true;
        PlayerCharacter.GetComponent<GravityGun>().Attacked = true;
        SearchingLight.SetActive(true);
    }

    void SearchLightOff()
    {
        SearchingLight.SetActive(false);
        ShadowLight.SetActive(true);
        PlayerCharacter.GetComponent<PlayerController>().PlayerAttacked = false;
        PlayerCharacter.GetComponent<GravityGun>().Attacked = false;
    }
    public void RestartScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void ExitLevel()
    {
        SceneManager.LoadScene(0);
    }

    void PauseGameMenu()
    {
        // Turning on the pause or the option canvas.
        if (PauseOff)
        {
            PauseMenu.SetActive(true);
            PauseOff = false;
        }
        else
        {
            PauseMenu.SetActive(false);
            PauseOff = true;
        }
    }
}