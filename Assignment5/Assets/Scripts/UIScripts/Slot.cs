using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Text _qtyText;
    [SerializeField] private Image _qtyImage;
    private ItemData _item;
    public Text QtyText {
        get {
            return _qtyText;
        }
    }
    public Image QtyImage {
        get {
            return _qtyImage;
        }
    }
    public ItemData Item {
        get {
            return _item;
        }
        set {
            _item = value;
            Debug.Log(_item);
        }
    }
}
