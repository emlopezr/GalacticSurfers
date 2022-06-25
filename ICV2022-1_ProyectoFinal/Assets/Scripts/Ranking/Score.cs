using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static int ScoreFinal;
    public float Scoremoment;
    public Transform player;
    public Text score;
    public Text Hscore;
    public Text cointext;
    public int coin;
    void Start()
    {
        Hscore.text = "Max: " + PlayerPrefs.GetInt("puntajeHSnum", 0).ToString();
        coin = PlayerPrefs.GetInt("monedas", 0);
        cointext.text = "Coins: " + coin.ToString("0");
    }
    void Update()
    {
        if (PlayerManager.gameStarted && !PlayerManager.gameOver)
        {
            if(!PowerUps.isActiveDouble)
            {
                Scoremoment += Movimiento.zspeed * Time.deltaTime;
                score.text = "Score: " + Scoremoment.ToString("0");
            }
            else
            {
                Scoremoment += 10*(Movimiento.zspeed * Time.deltaTime);
                score.text = "Score: " + Scoremoment.ToString("0");
            }
        }
        else
        {
            ScoreFinal = (int)Scoremoment+1;
            if (ScoreFinal > PlayerPrefs.GetInt("puntajeHSnum", 0))
            {
                PlayerPrefs.SetInt("puntajeHSnum", ScoreFinal);
                Hscore.text = "Max: " + ScoreFinal.ToString("0");
            }
            PlayerPrefs.SetInt("monedas", coin);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            coin += 1;
            cointext.text = "Coins: " + coin.ToString("0");
            collision.gameObject.SetActive(false);
        }    
    }
}
