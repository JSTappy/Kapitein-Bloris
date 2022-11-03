using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{  
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject quitButton;

    void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        quitButton.SetActive(false);
    }

    public void GameOverScreen()
    {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
    }
}