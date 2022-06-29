using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movimiento : MonoBehaviour
{
    public Transform player;
    public Transform coinDetector;
    public static float zspeed = PlayerConfig.playerZSpeed;
    public static float xyspeed = PlayerConfig.playerXYSpeed;
    private float ScoreInstant = 0;
    private float ScoreReference = 100;
    private float ScoreReferenceIncrement = 100;
    private float increment = 0.1f;
    private int Xkey = 0; //0: Central, -1: Carril Izquierdo , 1: Carril Derecho
    private int Ykey = 0; //0: Central, -1: Abajo , 1: Arriba
    // Update is called once per frame
    void Update()
    {

        if (!PlayerManager.gameStarted || PlayerManager.gameOver)
        {
            return;
        }

        //Aumento de la velocidad
        ScoreInstant += zspeed*Time.deltaTime;
        
        if (ScoreInstant > ScoreReference)
        {
            zspeed += increment*zspeed; 
            ScoreReference += ScoreReferenceIncrement;
        }

        //Desplazamiento en el eje Z
        Vector3 _zdir = new Vector3(0,0,1);
        Vector3 pos = transform.position;
        Vector3 movement = zspeed * _zdir * Time.deltaTime;

        pos += movement;
        transform.position = pos;
        
        //Desplazamiento con casillas
        //Eje X
        if (Input.GetKeyDown("left"))
        {
            Xkey -= 1;
            if (Xkey < -1)
            {
                Xkey = -1;
            }
        } 
        else if (Input.GetKeyDown("right"))
        {
            Xkey += 1;
            if (Xkey > 1)
            {
                Xkey = 1;
            }
        } 
        
        if (Xkey == 0)
        {
            pos.x = 0;
        }
        else if (Xkey == 1)
        {
            pos.x= 3.5f;
        }
        else
        {
            pos.x = -3.5f;
        }

        if (Input.GetKeyDown("up"))
        {
            Ykey += 1;
            if (Ykey > 1)
            {
                Ykey = 1;
            }
        } 
        else if (Input.GetKeyDown("down"))
        {
            Ykey -= 1;
            if (Ykey < -1)
            {
                Ykey = -1;
            }
        } 

        
        if (Ykey == 0)
        {
            pos.y = 0;
        }
        else if (Ykey == 1)
        {
            pos.y= 2f;
        }
        else
        {
            pos.y = -2f;
        }

        pos += movement;
        transform.position = pos;
        coinDetector.transform.position = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Coin") && !collision.gameObject.CompareTag("Magnet") && !collision.gameObject.CompareTag("Double") && !collision.gameObject.CompareTag("Speed"))
        {
            PlayerManager.gameOver = true;
    
        }
    }
}
