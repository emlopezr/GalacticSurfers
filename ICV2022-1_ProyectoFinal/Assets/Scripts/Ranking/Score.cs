using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static float ScoreFinal;
    private float Scoremoment;
    public Transform player;
    public Text score;
    public Text Hscore;
    void Start()
    {
        Hscore.text = PlayerPrefs.GetInt("puntajeHSnum", 0).ToString();
    }
    void Update()
    {
        Scoremoment = (player.position.z);
        score.text = "Score: " + Scoremoment.ToString("0");
    }
    public void Scores()
    {
        int ScoreFinal = Random.Range(101, 1000);
        //score.text = ScoreFinal.ToString();
        if (ScoreFinal > PlayerPrefs.GetInt("puntajeHSnum", 0))
        {
            PlayerPrefs.SetInt("puntajeHSnum", ScoreFinal);
            Hscore.text = ScoreFinal.ToString();
        }
    }
    public void reset()
    {
        PlayerPrefs.DeleteKey("puntajeHSnum");
        Hscore.text = "0";
    }
}
