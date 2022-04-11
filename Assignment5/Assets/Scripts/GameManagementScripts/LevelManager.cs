using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Vector3 _spawnPoint;
    private void Awake() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null) {
            Instantiate(_playerPrefab, _spawnPoint, Quaternion.identity);
        }
    }
}
