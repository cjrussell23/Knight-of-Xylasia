using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private SoundManager _soundManager;
    private void Awake()
    {
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Shoot(float direction)
    {
        _soundManager.FireBall();
        Vector3 scale = transform.localScale;
        Vector3 newScale = new Vector3(scale.x * direction, scale.y, scale.z);
        transform.localScale = newScale;
        _rb.AddForce(new Vector2(.1f * direction, 0));
        Invoke(nameof(DestroyFireBall), 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            _soundManager.Explosion();
            _rb.velocity = Vector3.zero;
            _animator.SetTrigger("hit");
            Invoke(nameof(DestroyFireBall), .6f);
        }
        
    }
    private void DestroyFireBall()
    {
        Destroy(gameObject);
    }
}
