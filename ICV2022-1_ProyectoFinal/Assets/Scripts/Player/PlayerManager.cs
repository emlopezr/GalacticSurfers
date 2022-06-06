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
    }

    void Update()
    {
        if (gameOver) {
            gameOverPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            startGamePanel.SetActive(false);
            Movimiento.zspeed = 30;
            Movimiento.xyspeed = 10;
        }
    }
}
