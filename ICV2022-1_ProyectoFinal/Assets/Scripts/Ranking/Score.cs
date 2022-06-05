using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static int ScoreFinal;
    private float Scoremoment;
    public Transform player;
    public Text score;
    public Text Hscore;
    void Start()
    {
        Hscore.text = "Max: " + PlayerPrefs.GetInt("puntajeHSnum", 0).ToString();
    }
    void Update()
    {
        if (PlayerManager.gameStarted && !PlayerManager.gameOver)
        {
            Scoremoment += Movimiento.zspeed * Time.deltaTime;
            score.text = "Score: " + Scoremoment.ToString("0");
        }
        else
        {
            ScoreFinal = (int)Scoremoment+1;
            if (ScoreFinal > PlayerPrefs.GetInt("puntajeHSnum", 0))
            {
                PlayerPrefs.SetInt("puntajeHSnum", ScoreFinal);
                Hscore.text = "Max: " + ScoreFinal.ToString("0");
            }
        }
    }
}
