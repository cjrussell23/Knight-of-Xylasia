using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOne : MonoBehaviour
{
    private Rigidbody2D _rb;
    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void move(Vector2 velocity){
        _rb.velocity = velocity;
    }
}
