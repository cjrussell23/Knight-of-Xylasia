using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _fireBall;
    [SerializeField] private AudioClip _explosion;
    [SerializeField] private AudioClip _buttonClick;
    // Goblin Sounds
    [SerializeField] private AudioClip _goblinAttack0;
    [SerializeField] private AudioClip _goblinAttack1;
    [SerializeField] private AudioClip _goblinAttack2;
    [SerializeField] private AudioClip _goblinAttack3;
    [SerializeField] private AudioClip _goblinHurt0;
    [SerializeField] private AudioClip _goblinHurt1;
    [SerializeField] private AudioClip _goblinHurt2;
    [SerializeField] private AudioClip _goblinDeath;
    // Demon sounds
    [SerializeField] private AudioClip _demonAttack0;
    [SerializeField] private AudioClip _demonAttack1;
    [SerializeField] private AudioClip _demonAttack2;
    [SerializeField] private AudioClip _demonHurt0;
    [SerializeField] private AudioClip _demonHurt1;
    [SerializeField] private AudioClip _demonDeath;
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
    public void GoblinAttack(){
        int random = Random.Range(0,4);
        switch (random){
            case 0:
                _audioSource.PlayOneShot(_goblinAttack0);
                break;
            case 1:
                _audioSource.PlayOneShot(_goblinAttack1);
                break;
            case 2:
                _audioSource.PlayOneShot(_goblinAttack2);
                break;
            case 3:
                _audioSource.PlayOneShot(_goblinAttack3);
                break;
        }
    }
    public void GoblinHurt(){
        int random = Random.Range(0,3);
        switch (random){
            case 0:
                _audioSource.PlayOneShot(_goblinHurt0);
                break;
            case 1:
                _audioSource.PlayOneShot(_goblinHurt1);
                break;
            case 2:
                _audioSource.PlayOneShot(_goblinHurt2);
                break;
        }
    }
    public void GoblinDeath(){
        _audioSource.PlayOneShot(_goblinDeath);
    }
    public void DemonAttack(){
        int random = Random.Range(0,3);
        switch (random){
            case 0:
                _audioSource.PlayOneShot(_demonAttack0);
                break;
            case 1:
                _audioSource.PlayOneShot(_demonAttack1);
                break;
            case 2:
                _audioSource.PlayOneShot(_demonAttack2);
                break;
        }
    }
    public void DemonHurt(){
        int random = Random.Range(0,2);
        switch (random){
            case 0:
                _audioSource.PlayOneShot(_demonHurt0);
                break;
            case 1:
                _audioSource.PlayOneShot(_demonHurt1);
                break;
        }
    }
    public void DemonDeath(){
        _audioSource.PlayOneShot(_demonDeath);
    }
}
