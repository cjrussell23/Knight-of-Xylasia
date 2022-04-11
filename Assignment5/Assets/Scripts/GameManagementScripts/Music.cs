using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public void PlayMusic()
    {
        GetComponent<AudioSource>().Play();
    }
    public void PauseMusic()
    {
        GetComponent<AudioSource>().Pause();
    }
}
