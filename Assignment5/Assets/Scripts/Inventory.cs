using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;
    private const int _numSlots = 8;
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
                newSlot.transform.SetParent(gameObject.transform.GetChild(1).transform, false); // Set slot as child of SlotLayout
                _slots[i] = newSlot;
                _itemImages[i] = newSlot.transform.GetChild(1).GetComponent<Image>();
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
                Slot slotScript = _slots[i].gameObject.GetComponent<Slot>();
                Image qtyImage = slotScript.QtyImage;
                qtyImage.enabled = true;
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
                Slot slotScript = _slots[i].gameObject.GetComponent<Slot>();
                slotScript.Item = _items[i];
                return true;
            }
        }
        return false;
    }
    public void RemoveItem(ItemData itemToRemove)
    {
        for (int i = 0; i < _itemImages.Length; i++)
        {
            if (_items[i] != null && _items[i].Type == itemToRemove.Type)
            {
                _items[i].Quantity = _items[i].Quantity - 1; // decrease quantity
                Slot slotScript = _slots[i].gameObject.GetComponent<Slot>();
                if (_items[i].Quantity == 0) // if none left
                {
                    // Remove item from slot
                    _items[i] = null;
                    _itemImages[i].enabled = false;          
                    slotScript.Item = null;
                    // Disable image and text for quantity
                    slotScript.QtyImage.enabled = false;
                    slotScript.QtyText.enabled = false;
                }
                else
                {
                    // Update quantity text
                    Text quantityText = slotScript.QtyText;
                    quantityText.text = _items[i].Quantity.ToString();
                }
            }
        }
    }
}
