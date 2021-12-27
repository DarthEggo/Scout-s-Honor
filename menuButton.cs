using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuButton : MonoBehaviour
{
    public ability ability;

    public Text abilityName;
    public void StartGame()
    {
        SceneManager.LoadScene("Scene");
    }

    public void powerSwitch()
    {
        switch (ability.abilityID)
        {
            case 1: 
            ability.abilityID = 2;
            abilityName.text = "Slow Fall";
            break;
            case 2:
            ability.abilityID = 3;
            abilityName.text = "Bomb Jump";
            break;
            case 3:
            ability.abilityID = 4;
            abilityName.text = "Dash";
            break;
            case 4:
            ability.abilityID = 1;
            abilityName.text = "Double Jump";
            break;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    
}
