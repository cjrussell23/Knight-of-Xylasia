using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] private ItemData _item;
    public ItemData Item
    {
        get
        {
            return _item;
        }
    }
}
