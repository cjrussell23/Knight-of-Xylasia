using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPrefab;
    [SerializeField] private GameObject _healthBarPrefab;
    [SerializeField] private GameObject _manaBarPrefab;
    private GameObject _gameOverText;
    private GameObject _mainMenuButton;
    private GameObject _inventory;
    private GameObject _healthBar;
    private GameObject _manaBar;
    void Awake()
    {
        // Instantiate
        _inventory = Instantiate(_inventoryPrefab);
        _healthBar = Instantiate(_healthBarPrefab);
        _manaBar = Instantiate(_manaBarPrefab);
        // Set parent
        _inventory.transform.SetParent(gameObject.transform, false);
        _healthBar.transform.SetParent(gameObject.transform, false);
        _manaBar.transform.SetParent(gameObject.transform, false);
        // Change names
        _healthBar.name = "PlayerHealthBar";
        _manaBar.name = "PlayerManaBar";
        //
        _gameOverText = transform.GetChild(0).gameObject;
        _mainMenuButton = transform.GetChild(1).gameObject;
        _gameOverText.SetActive(false);
        _mainMenuButton.SetActive(false);
    }
    public void GameOverScreen(bool active)
    {
        _gameOverText.SetActive(active);
        _mainMenuButton.SetActive(active);
        _inventory.SetActive(!active);
        _healthBar.SetActive(!active);
        _manaBar.SetActive(!active);
    }
}
