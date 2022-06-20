using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public Transform player;
    public float magneticSpeed;
    public static List<GameObject> coinsList;

    public float clearTime;
    private float auxClearTime;

    private void Start()
    {
        coinsList = new List<GameObject>();
        auxClearTime = clearTime;
    }

    private void Update()
    {
        magneticSpeed = Movimiento.zspeed/100;


        foreach (GameObject coin in coinsList)
        {     
            coin.transform.position = Vector3.Lerp(coin.transform.position, player.transform.position, magneticSpeed);
        }

        if(auxClearTime >= 0)
        {
            auxClearTime -= Time.deltaTime;
        }
        else
        {
            coinsList.Clear();
            auxClearTime = clearTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin") && !coinsList.Contains(collision.gameObject))
        {
            coinsList.Add(collision.gameObject);
        }
    }
}
