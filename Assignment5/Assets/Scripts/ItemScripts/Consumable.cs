using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] private ItemData _item;
    private Animator _animator;
    private CircleCollider2D _collider;
    private void Awake() {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CircleCollider2D>();
    }
    public ItemData Item
    {
        get
        {
            return _item;
        }
    }
    public void Collected(){
        _animator.SetTrigger("collected");
        _collider.enabled = false;
        Invoke(nameof(DestroyItem), .5f); // Destroy after animation plays
    }
    private void DestroyItem(){
        Destroy(gameObject);
    }
}
