using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPrefab;
    [SerializeField] private GameObject _healthBarPrefab;
    [SerializeField] private GameObject _manaBarPrefab;
    void Awake()
    {
        // Instantiate
        GameObject _inventory = Instantiate(_inventoryPrefab);
        GameObject _healthBar = Instantiate(_healthBarPrefab);
        GameObject _manaBar = Instantiate(_manaBarPrefab);
        // Set parent
        _inventory.transform.SetParent(gameObject.transform, false);
        _healthBar.transform.SetParent(gameObject.transform, false);
        _manaBar.transform.SetParent(gameObject.transform, false);
        // Change names
        _healthBar.name = "PlayerHealthBar";
        _manaBar.name = "PlayerManaBar";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
