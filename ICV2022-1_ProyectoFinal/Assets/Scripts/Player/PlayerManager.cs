using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool gameStarted;

    public GameObject gameOverPanel;
    public GameObject startGamePanel;

    void Start()
    {
        gameStarted = false;
        gameOver = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (gameOver) {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            startGamePanel.SetActive(false);
        }
    }
}
