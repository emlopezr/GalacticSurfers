using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static string ScoreFinal;
    public Transform player;
    public Text score;
    void Update()
    {
        ScoreFinal = (player.position.z).ToString("0");
        score.text= "Score: " + ScoreFinal;
    }
}

