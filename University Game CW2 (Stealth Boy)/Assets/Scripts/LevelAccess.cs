using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAccess: MonoBehaviour
{
    // Script which controls the buttons in the menu for level access. 
    [SerializeField]
    private GameObject Level1Button;
    [SerializeField]
    private Button Level2Button;
    [SerializeField]
    private Button Level3Button;

    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        Level1Button.GetComponent<Button>().interactable = false;
        Level2Button.GetComponent<Button>().interactable = false;
        Level3Button.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Turning on the buttons according to the bool values withing the scriptable object.
        if (levelManager.LevelOnePassed)
        {
            Level1Button.GetComponent<Button>().interactable = true;
        }
        
        if (levelManager.LevelTwoPassed)
        {
            Level2Button.GetComponent<Button>().interactable = true;
        }
        
        if (levelManager.LevelThreePassed)
        {
            Level3Button.GetComponent<Button>().interactable = true;
        }
    }
}
