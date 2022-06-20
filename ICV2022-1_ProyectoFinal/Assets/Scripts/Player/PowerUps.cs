using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject coinDetector;
    public float maxTime;

    private float timeAuxMagnet;
    private bool isActiveMagnet = false;

    public static bool isActive;
    public static float publicMaxTimePowerUps;

    private void Start()
    {
        isActive = false;
        coinDetector.SetActive(false);
        timeAuxMagnet = maxTime;
        publicMaxTimePowerUps = maxTime;
    }

    private void Update()
    {
        if(isActiveMagnet && timeAuxMagnet >= 0)
        {
            coinDetector.SetActive(true);
            timeAuxMagnet -= Time.deltaTime;
        }
        else
        {
            coinDetector.SetActive(false);
            isActive = false;
            timeAuxMagnet = maxTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Magnet") || collision.gameObject.CompareTag("Double") || collision.gameObject.CompareTag("Speed"))
        {
            isActive = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Magnet"))
        {
            isActiveMagnet = true;
        }
    }
}
