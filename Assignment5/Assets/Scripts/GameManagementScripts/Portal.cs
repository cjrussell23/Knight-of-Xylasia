using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            SoundManager soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
            // TODO: Play more epic sound
            // And maybe a loading animation?
            soundManager.ButtonClick();
            SceneManager.LoadScene("Level1");
        }
    }
}
