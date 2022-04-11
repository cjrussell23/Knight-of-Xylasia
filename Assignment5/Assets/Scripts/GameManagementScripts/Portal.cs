using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private Vector3 _spawnPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            LoadScene();
        }
    }
    public void LoadScene()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (_spawnPoint != null)
        {
            player.transform.position = _spawnPoint;
        }
        SoundManager soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        // TODO: Play more epic sound
        // And maybe a loading animation?
        soundManager.ButtonClick();
        SceneManager.LoadScene(_sceneName);
    }
}
