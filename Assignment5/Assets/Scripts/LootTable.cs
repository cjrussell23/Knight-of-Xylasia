using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    [SerializeField] private GameObject _apple;
    [SerializeField] private GameObject _banana;
    [SerializeField] private GameObject _cherries;
    [SerializeField] private GameObject _kiwi;
    [SerializeField] private GameObject _melon;
    [SerializeField] private GameObject _orange;
    [SerializeField] private GameObject _pineapple;
    [SerializeField] private GameObject _strawberry;
    private GameObject[] _rarity1;
    private GameObject[] _rarity2;
    private GameObject[] _rarity3;
    private void Start() {
        _rarity1 = new GameObject[] { _banana, _strawberry };
        _rarity2 = new GameObject[] { _apple, _orange };
        _rarity3 = new GameObject[] { _cherries, _kiwi, _melon, _pineapple };
    }
    public GameObject[] GetLoot(int rarity) {
        switch (rarity) {
            case 1:
                return _rarity1;
            case 2:
                return _rarity2;
            case 3:
                return _rarity3;
            default:
                return null;
        }
    }
}
