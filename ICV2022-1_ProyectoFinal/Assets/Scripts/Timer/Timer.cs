using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject TimerMagnet;
    public GameObject TimerSpeed;
    public GameObject TimerDouble;
    public Slider TimerDouble1;
    public Slider TimerMagnet1;
    public Slider TimerSpeed1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerUps.isActiveMagnet)
        {
            TimerMagnet.SetActive(true);
            float Duracion = PowerUps.timeAuxMagnet;
            TimerMagnet1.value = Duracion;
        } else
        {
            TimerMagnet.SetActive(false);
        }
        
        if (PowerUps.isActiveSpeed)
        {
            TimerSpeed.SetActive(true);
            float Duracion1 = PowerUps.timeAuxSpeed;
            TimerSpeed1.value = Duracion1;
        } else
        {
            TimerSpeed.SetActive(false);
        }

        if (PowerUps.isActiveDouble)
        {
            TimerDouble.SetActive(true);
            float Duracion2 = PowerUps.timeAuxDouble;
            TimerDouble1.value = Duracion2;
        } else
        {
            TimerDouble.SetActive(false);
        }
    }
}

