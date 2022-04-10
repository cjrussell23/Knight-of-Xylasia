using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField] private string _enemyName;
    private SoundManager _soundManager;
    private void Awake() {
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    public void Play(string sound){
        switch(_enemyName){
            case "goblin":
                switch(sound){
                    case "attack":
                        _soundManager.GoblinAttack();
                        break;
                    case "hurt":
                        _soundManager.GoblinHurt();
                        break;
                    case "death":
                        _soundManager.GoblinDeath();
                        break;
                }
                break;
        }
    }
}
