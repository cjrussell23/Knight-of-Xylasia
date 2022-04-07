using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _fireBall;
    [SerializeField] private AudioClip _explosion;
    [SerializeField] private AudioClip _buttonClick;
    [SerializeField] private AudioClip _mainMusic;
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
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
    public void ButtonClick()
    {
        _audioSource.PlayOneShot(_buttonClick);
    }
    public void MainMusic()
    {
        _audioSource.PlayOneShot(_mainMusic);
    }
}
