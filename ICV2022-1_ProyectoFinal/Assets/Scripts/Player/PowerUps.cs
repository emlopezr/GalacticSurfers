using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject coinDetector;
    public float maxTime;
    private bool isActive;
    private float timeAux;

    public static float publicMaxTimePowerUps;

    private void Start()
    {
        coinDetector.SetActive(false);
        isActive = false;
        timeAux = maxTime;
        publicMaxTimePowerUps = maxTime;
    }

    private void Update()
    {
        if(isActive && timeAux >= 0)
        {
            coinDetector.SetActive(true);
            timeAux -= Time.deltaTime;
        }
        else
        {
            coinDetector.SetActive(false);
            isActive = false;
            timeAux = maxTime;
        }

        // Borrar lista de monedas del iman
        if (!coinDetector.activeSelf)
        {
            Magnet.coinsList.Clear();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Magnet"))
        {
            isActive = true;
            Destroy(collision.gameObject);
        }
    }
}
