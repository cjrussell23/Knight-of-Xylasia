using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;
    private const int _numSlots = 5;
    private Image[] _itemImages = new Image[_numSlots];
    private ItemData[] _items = new ItemData[_numSlots];
    private GameObject[] _slots = new GameObject[_numSlots];
    public void Start()
    {
        CreateSlots();
    }
    public void CreateSlots()
    {
        if (_slotPrefab != null)
        {
            for (int i = 0; i < _numSlots; i++)
            {
                GameObject newSlot = Instantiate(_slotPrefab);
                newSlot.name = "ItemSlot_" + i;
                newSlot.transform.SetParent(gameObject.transform.
                GetChild(0).transform);
                _slots[i] = newSlot;
                _itemImages[i] =
                newSlot.transform.GetChild(1).GetComponent<Image>();
            }
        }
    }
    public bool AddItem(ItemData itemToAdd)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] != null && _items[i].Type == itemToAdd.Type && itemToAdd.IsStackable == true)
            {
                _items[i].Quantity = _items[i].Quantity + 1;
                Slot slotScript = _slots[i].gameObject.
                GetComponent<Slot>();
                Text quantityText = slotScript.QtyText;
                quantityText.enabled = true;
                quantityText.text = _items[i].Quantity.ToString();
                return true;
            }
            if (_items[i] == null)
            {
                _items[i] = Instantiate(itemToAdd);
                _items[i].Quantity = 1;
                _itemImages[i].sprite = itemToAdd.Sprite;
                _itemImages[i].enabled = true;
                return true;
            }
        }
        return false;
    }
}
