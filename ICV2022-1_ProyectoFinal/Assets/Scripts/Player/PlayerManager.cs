using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;

    void Start()
    {
        gameOver = false;
    }

    void Update()
    {
        if (gameOver) {
            Time.timeScale = 0;
        }
    }
}
