using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    public GameObject[] powerUps;
    private GameObject generatedPowerUp;

    private void Start()
    {
        GameObject selectedPowerUp = powerUps[Random.Range(0, powerUps.Length)];
        generatedPowerUp = Instantiate(selectedPowerUp, transform.position, transform.rotation);
    }

    private void Update()
    {
        if (PowerUps.isActive)
        {
            Destroy(generatedPowerUp);
        }
    }
}
