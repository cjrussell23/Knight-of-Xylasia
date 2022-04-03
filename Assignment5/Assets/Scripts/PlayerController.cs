using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool _gameOver;
    private float _speed;
    private float DEFAULTSPEED = 4.5f;
    private float _jumpForce;
    [SerializeField] private float DEFAULTJUMPFORCE = 16f;
    private bool _isGrounded;
    private int _jumps;
    private bool _invulnerable;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _inputLock;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _fireballPrefab;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _manaSlider;
    [SerializeField] private float _attack1Mana = 5;
    [SerializeField] private float _attack2Mana = 10;
    [SerializeField] private float _sprintMana = 0.01f;
    [SerializeField] private float _manaRegen = 0.05f;
    [SerializeField] private float _jumpMana = 5f;
    [SerializeField] private AudioClip _attack0Audio;
    [SerializeField] private AudioClip _attack1Audio;
    [SerializeField] private AudioClip _attack2Audio;
    [SerializeField] private AudioClip _jumpAudio;
    [SerializeField] private AudioClip _secondJumpAudio;

    void Start()
    {
        _inputLock = false;
        _gameOver = false;
        _speed = DEFAULTSPEED;
        _jumpForce = DEFAULTJUMPFORCE;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        _manaSlider.value += _manaRegen;
    }
    void Update()
    {
        if (!_gameOver && !_inputLock)
        {
            if (_isGrounded && Input.GetButton("Sprint") && _manaSlider.value > _sprintMana)
            {
                _speed = DEFAULTSPEED * 2;
                _manaSlider.value -= _sprintMana;
            }
            else
            {
                _speed = DEFAULTSPEED;
            }
            float deltaX = Input.GetAxis("Horizontal") * _speed;
            Vector2 movement = new Vector2(deltaX, _rb.velocity.y);
            _animator.SetFloat("speed", Mathf.Abs(deltaX));
            if (Input.GetButtonDown("Attack0"))
            {
                Attack0();
            }
            else if (Input.GetButtonDown("Attack1") && _manaSlider.value > _attack1Mana)
            {
                Attack1();
            }
            else if (Input.GetAxis("Attack2") > 0 && _manaSlider.value > _attack2Mana)
            {
                Attack2();
            }

            else
            {
                _rb.velocity = movement;
            }
            if (!Mathf.Approximately(deltaX, 0))
            {
                transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
            }
            // Reset Jumps after touching the ground
            if (_isGrounded)
            {
                _jumps = 2;
            }
            // First Jump
            if (_jumps == 2 && Input.GetButtonDown("Jump"))
            {
                _audioSource.PlayOneShot(_jumpAudio);
                Jump();
            }
            // Second jump requires mana
            else if (_jumps == 1 && Input.GetButtonDown("Jump") && _manaSlider.value > _jumpMana)
            {
                _audioSource.PlayOneShot(_secondJumpAudio);
                _manaSlider.value -= _jumpMana;
                Jump();
            }
        }
        // Game over
        else
        {
            _animator.SetFloat("speed", 0);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
    private void StopInputLock()
    {
        _inputLock = false;
    }
    private void Jump()
    {
        _jumps--;
        _animator.SetTrigger("jump");
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
    private void Attack0()
    {
        _audioSource.PlayOneShot(_attack0Audio);
        _inputLock = true;
        _animator.SetTrigger("attack0");
        // Stop horizontal movement during attack
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        Invoke(nameof(StopInputLock), .5f);
    }
    private void Attack1()
    {
        _audioSource.PlayOneShot(_attack1Audio);
        _inputLock = true;
        _manaSlider.value -= _attack1Mana;
        _animator.SetTrigger("attack1");
        // Thrust player forward during attack
        _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * _speed * 1.5f, _rb.velocity.y);
        Invoke(nameof(StopInputLock), .5f);
    }
    private void Attack2()
    {
        _audioSource.PlayOneShot(_attack2Audio);
        _inputLock = true;
        _animator.SetTrigger("attack2");
        _manaSlider.value -= _attack2Mana;
        // Stop horizontal movement during attack
        Invoke(nameof(ShootFireBall), .5f);
        Invoke(nameof(StopInputLock), 1f);

    }
    public void DamagePlayer(float damage)
    {
        _healthSlider.value -= damage;
    }
    private void ShootFireBall()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        Vector2 pos = transform.position;
        GameObject fireball = Instantiate(_fireballPrefab, pos + new Vector2(0, -1), Quaternion.identity);
        fireball.transform.GetComponent<fireball>().Shoot(transform.localScale.x);
    }
    public IEnumerator DamagePlayer(int damage, float interval)
    {
        while (true)
        {
            _healthSlider.value -= damage;
            if (_healthSlider.value <= float.Epsilon)
            {
                KillPlayer();
                break;
            }
            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }
    private void KillPlayer(){
        _animator.SetTrigger("Dead");
        Debug.Log("Dead");
    }
}
