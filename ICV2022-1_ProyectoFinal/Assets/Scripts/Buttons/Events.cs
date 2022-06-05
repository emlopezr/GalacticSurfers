using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
