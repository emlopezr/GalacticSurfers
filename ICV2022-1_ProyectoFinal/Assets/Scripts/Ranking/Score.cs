using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Score : MonoBehaviour
{
    public static int ScoreFinal;
    public float Scoremoment;
    public Transform player;
    public TextMeshProUGUI score;
    public TextMeshProUGUI Hscore;
    public TextMeshProUGUI cointext;
    public int coin;
    public static bool newRecord;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Start()
    {
        Hscore.text = PlayerPrefs.GetInt("puntajeHSnum", 0).ToString();
        coin = PlayerPrefs.GetInt("monedas", 0);
        cointext.text = coin.ToString("0");
        newRecord = false;
    }
    void Update()
    {
        if (PlayerManager.gameStarted && !PlayerManager.gameOver)
        {
            if(!PowerUps.isActiveDouble)
            {
                Scoremoment += Movimiento.zspeed * Time.deltaTime;
                score.text = Scoremoment.ToString("0");
            }
            else
            {
                Scoremoment += 10*(Movimiento.zspeed * Time.deltaTime);
                score.text = Scoremoment.ToString("0");
            }
        }
        else
        {
            ScoreFinal = (int)Scoremoment+1;
            if (ScoreFinal > PlayerPrefs.GetInt("puntajeHSnum", 0))
            {
                newRecord = true;
                PlayerPrefs.SetInt("puntajeHSnum", ScoreFinal);
                Hscore.text = ScoreFinal.ToString("0");
            }
            PlayerPrefs.SetInt("monedas", coin);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            coin += 1;
            cointext.text = coin.ToString("0");
            collision.gameObject.SetActive(false);
            soundManager.playAudio(1, 0.05f);
        }    
    }
}
