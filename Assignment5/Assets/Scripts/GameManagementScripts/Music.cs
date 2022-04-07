using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    public void PlayMusic()
    {
        GetComponent<AudioSource>().Play();
    }
    public void PauseMusic()
    {
        GetComponent<AudioSource>().Pause();
    }
}
