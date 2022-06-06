using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private bool animationInstanced = false;
    
    public GameObject explosionPrefab;
    public GameObject playerModel;

    private void Update()
    {
        if (PlayerManager.gameOver && !animationInstanced)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            playerModel.SetActive(false);
            animationInstanced = true;

            Movimiento.zspeed = 0;
            Movimiento.xyspeed = 0;
        }
    }
}
