using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    [SerializeField] private float zSpeed;
    [SerializeField] private float xySpeed;

    public static float playerZSpeed;
    public static float playerXYSpeed;

    private void Update()
    {
        playerZSpeed = zSpeed;
        playerXYSpeed = xySpeed;
    }
}
