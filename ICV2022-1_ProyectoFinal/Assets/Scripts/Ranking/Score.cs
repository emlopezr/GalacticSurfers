using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text score;
    
    void Update()
    {
        score.text= "Score: " + player.position.z.ToString("0");
    }
}
