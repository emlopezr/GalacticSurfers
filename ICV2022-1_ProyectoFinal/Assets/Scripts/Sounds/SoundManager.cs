using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource controller;
    public AudioClip[] sounds;

    public void playAudio(int index, float volume)
    {
        controller.PlayOneShot(sounds[index], volume);
    }
}
