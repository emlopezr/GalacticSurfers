using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public static int currentRecord;
    public TextMeshProUGUI coinsGameOver;
    public TextMeshProUGUI pointsGameOver;
    public GameObject recordText;

    private int currentCoins;
    private int currentPoints;

    private void Update()
    {
        currentPoints = Score.ScoreFinal;
        currentCoins = PlayerPrefs.GetInt("monedas", 0);
        coinsGameOver.text = "Monedas: " + currentCoins.ToString("0");
        pointsGameOver.text = "Puntos: " + currentPoints.ToString("0");

        if (Score.newRecord)
        {
            recordText.SetActive(true);
        }
    }
}
