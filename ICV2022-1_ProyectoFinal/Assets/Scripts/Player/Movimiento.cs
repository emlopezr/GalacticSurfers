using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movimiento : MonoBehaviour
{
    public Transform player;
    [SerializeField] public static float zspeed = 30;
    [SerializeField] private float xyspeed = 10;

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.gameStarted)
        {
            return;
        }
        
        //Desplazamiento en el eje Z
        Vector3 _zdir = new Vector3(0,0,1);
        Vector3 pos = transform.position;
        Vector3 movement = zspeed * _zdir * Time.deltaTime;

        pos += movement;
        transform.position = pos;
        
        //Desplazamiento en el eje x,y
        float horizontal= Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");

        Vector3 _xydir = new Vector3(horizontal,vertical,0);
        _xydir.Normalize();

        Vector3 xypos = transform.position;
        Vector3 xymovement = xyspeed * _xydir * Time.deltaTime;

        xypos += xymovement;
        transform.position = xypos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerManager.gameOver = true;
    }
}
