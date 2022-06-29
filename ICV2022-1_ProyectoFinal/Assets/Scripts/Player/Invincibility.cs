using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    public float InvincibilityTime;
    public float InvincibilityLength;
    public float PowerUpSpeed;
    public float RegularSpeed;
    private int Contador = 0;
    public GameObject player;
    public Renderer PlayerRenderer;
    private float DuracionRender;
    public float TiempoRender = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        PowerUpSpeed = 30;
        DuracionRender = TiempoRender;
        InvincibilityLength = 5f;
        InvincibilityTime = InvincibilityLength - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Contador == 0)
        {
            RegularSpeed = Movimiento.zspeed;
            Contador += 1;
        }
        if (InvincibilityTime > 0)
        {
            PlayerRenderer.enabled = false;
            player.layer = 7;
            InvincibilityTime -= Time.deltaTime;
            DuracionRender -= Time.deltaTime;
            if (DuracionRender <= 0)
            {
               PlayerRenderer.enabled = true;
               DuracionRender = TiempoRender; 
            }
            Movimiento.zspeed = PowerUpSpeed;
            
            

        }
        else if (InvincibilityTime <= 0)
        {
            player.layer = 0;
            PlayerRenderer.enabled = true;
            DuracionRender = TiempoRender;
            Movimiento.zspeed = RegularSpeed;
            InvincibilityTime = InvincibilityLength - 1;
            Contador = 0;
            PowerUps.isActiveSpeed = false;
        }
    }
}
