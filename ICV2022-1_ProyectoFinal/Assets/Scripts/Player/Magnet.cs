using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public Transform player;
    public float magneticSpeed;
    public static List<GameObject> coinsList;

    private void Start()
    {
        coinsList = new List<GameObject>();
    }

    private void Update()
    {
        foreach(GameObject coin in coinsList)
        {     
            coin.transform.position = Vector3.Lerp(coin.transform.position, player.transform.position, magneticSpeed);
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
