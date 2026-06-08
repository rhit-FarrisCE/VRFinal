using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ProgressionManager : MonoBehaviour
{
    // Start is called before the first frame update
    private double diffMulti = 1.5;
    private int minScore = 10;
    private int gameTotal = 0;
    private int highScore;

    public TextMeshProUGUI end;
    public Canvas menu;
    public GameObject endMenu;
    public GameObject sk;

    //Powerup menu important fields
    [Header("Powerup UI important fields")]
    public GameObject powerupUI;

    public void Progress(int totalScore)
    {
        
        gameTotal = gameTotal + totalScore;
        if (totalScore >= minScore)
        {
            minScore = (int)Math.Round(minScore * diffMulti);
            //Initiate powerup selecton
            powerupUI.SetActive(true);
            PowerupManager.Instance.GeneratePowerups();
        } else if (minScore == 10 && totalScore == 0)
        {
            gameTotal = 0;
        } else
        {
            if (highScore < gameTotal)
            {
                highScore = gameTotal;
            }
            minScore = 10;
            gameTotal = 0;
            if (!menu.enabled)
            {
                sk.SetActive(false);
                menu.enabled = true;
                endMenu.SetActive(true);
                end.text = "Game Over!\nHigh Score: " + highScore.ToString() + "\nWould you like to restart?";
            }
            PowerupManager.Instance.RemovePowerups();
        }
    }
}
