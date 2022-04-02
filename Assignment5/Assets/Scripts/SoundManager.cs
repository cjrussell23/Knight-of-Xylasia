using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _fireBall;
    [SerializeField] private AudioClip _explosion;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void FireBall()
    {
        _audioSource.PlayOneShot(_fireBall);
    }
    public void Explosion()
    {
        _audioSource.PlayOneShot(_explosion);
    }
}
