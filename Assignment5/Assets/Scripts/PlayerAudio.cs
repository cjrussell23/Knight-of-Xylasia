using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _attack0Audio;
    [SerializeField] private AudioClip _attack1Audio;
    [SerializeField] private AudioClip _attack2Audio;
    [SerializeField] private AudioClip _jumpAudio;
    [SerializeField] private AudioClip _secondJumpAudio;
    [SerializeField] private AudioClip _hurtAudio;
    [SerializeField] private AudioClip _deathAudio;
    [SerializeField] private AudioClip _blockAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(string audio){
        switch (audio){
            case "attack0":
                _audioSource.PlayOneShot(_attack0Audio);
                break;
            case "attack1":
                _audioSource.PlayOneShot(_attack1Audio);
                break;
            case "attack2":
                _audioSource.PlayOneShot(_attack2Audio);
                break;
            case "jump0":
                _audioSource.PlayOneShot(_jumpAudio);
                break;
            case "jump1":
                _audioSource.PlayOneShot(_secondJumpAudio);
                break;
            case "hurt":
                _audioSource.PlayOneShot(_hurtAudio);
                break;
            case "death":
                _audioSource.PlayOneShot(_deathAudio);
                break;
            case "block":
                _audioSource.PlayOneShot(_blockAudio);
                break;
        }
    }
}
