using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    private void Awake() {     
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public PlayerManager GetInstance() {
        return instance;
    }
}
