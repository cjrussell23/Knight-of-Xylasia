using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Text _qtyText;
    public Text QtyText {
        get {
            return _qtyText;
        }
    }
}
