using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    // Prefabs
    [SerializeField] private GameObject _fireballPrefab;
    [SerializeField] private GameObject _shieldPrefab;
    [SerializeField] private GameObject _attack0Prefab;
    [SerializeField] private GameObject _attack1Prefab;
    // GameObjects
    private GameObject _shield;
    private GameObject _attack0;
    private GameObject _attack1;
    // Components
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    // Movement Variables
    private bool _isGrounded;
    private int _jumps;
    private float _jumpForce;
    private float _speed;
    [SerializeField] private float DEFAULTSPEED = 4.5f;
    [SerializeField] private float SPRINTMODIFIER = 2f;
    [SerializeField] private float DEFAULTJUMPFORCE = 64f;
    [SerializeField] private float JUMPMODIFIER = 1.5f;
    // Player Scripts
    private PlayerResources _playerResources;
    private PlayerAudio _playerAudio;
    private PlayerController _playerController;
    private void Start()
    {
        // Get Components
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        // Other Player Scripts
        _playerResources = GetComponent<PlayerResources>();
        _playerAudio = GetComponent<PlayerAudio>();
        _playerController = GetComponent<PlayerController>();
        // Movement Variables
        _jumpForce = DEFAULTJUMPFORCE;
        _speed = DEFAULTSPEED;
    }
    ////////////////////////////////////////////////////////////////////////////////
    // Movement Control
    ////////////////////////////////////////////////////////////////////////////////
    public void Jump()
    {
        bool canJump = true;
        // Jumps resets to 2 when grounded
        if (_jumps == 2) // Player has not jumped yet 
        {
            _jumpForce = DEFAULTJUMPFORCE;
            _playerAudio.Play("jump0");
        }
        // Player has jumped once
        // Second Jump requires mana
        else if (_jumps == 1 && _playerResources.GetMana() > _playerResources.GetJumpMana())
        {
            _jumpForce = DEFAULTJUMPFORCE * JUMPMODIFIER;
            _playerAudio.Play("jump1");
            _playerResources.AdjustMana(_playerResources.GetJumpMana() * -1);
        }
        else
        {
            canJump = false;
        }
        // Common jump code
        if (_jumps > 0 && canJump)
        {
            _jumps--;
            _animator.SetTrigger("jump");
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
    public void Sprint()
    {
        // Only allow sprinting if the player is grounded and has enough mana
        if (_isGrounded && _playerResources.GetMana() > _playerResources.GetSprintMana())
        {
            _speed = DEFAULTSPEED * SPRINTMODIFIER;
            _playerResources.AdjustMana(_playerResources.GetSprintMana() * -1);
        }
    }
    public void Walk()
    {
        _speed = DEFAULTSPEED;
    }
    public void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        Vector2 movement = new Vector2(deltaX, _rb.velocity.y);
        _animator.SetFloat("speed", Mathf.Abs(deltaX));
        _rb.velocity = movement;
        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
    }
    ////////////////////////////////////////////////////////////////////////////////
    // Movement utility methods - private
    ////////////////////////////////////////////////////////////////////////////////
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
            _jumps = 2;
        }
    }
    ////////////////////////////////////////////////////////////////////////////////
    // Start Attacks - public
    ////////////////////////////////////////////////////////////////////////////////
    public void Attack0()
    {
        _playerController.SetInputLock(true);
        _playerAudio.Play("attack0");
        _animator.SetTrigger("attack0");
        _attack0 = Instantiate(_attack0Prefab, transform.position + new Vector3(transform.localScale.x * 1.3f, -1.1f, 0), Quaternion.identity);
        // Stop horizontal movement during attack
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        Invoke(nameof(StopAttack0), .5f);
    }
    public void Attack1()
    {
        // Attack1 is only available if the player has enough mana
        if (_playerResources.GetMana() > _playerResources.GetAttack1Mana())
        {
            _attack1 = Instantiate(_attack1Prefab, transform.position + new Vector3(transform.localScale.x * 1f, -1f, 0), Quaternion.identity);
            _playerAudio.Play("attack1");
            _playerController.SetInputLock(true);
            _playerResources.AdjustMana(_playerResources.GetAttack1Mana() * -1);
            _animator.SetTrigger("attack1");
            // Thrust player forward during attack
            Vector2 velocity = new Vector2(transform.localScale.x * _speed * 1.5f, _rb.velocity.y);
            _rb.velocity = velocity;
            AttackOne attack = _attack1.GetComponent<AttackOne>();
            attack.move(velocity);
            Invoke(nameof(StopAttack1), .5f);
        }
    }
    public void Attack2()
    {
        // Attack2 is only available if the player has enough mana
        if (_playerResources.GetMana() > _playerResources.GetAttack2Mana())
        {
            _playerController.SetInputLock(true);
            _playerAudio.Play("attack2");
            _animator.SetTrigger("attack2");
            _playerResources.AdjustMana(_playerResources.GetAttack2Mana() * -1);
            // Stop horizontal movement during attack
            Invoke(nameof(ShootFireBall), .5f);
            Invoke(nameof(StopAttack2), 1f);
        }
    }
    public void ShootFireBall()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        Vector2 pos = transform.position;
        GameObject fireball = Instantiate(_fireballPrefab, pos + new Vector2(0, -1), Quaternion.identity);
        fireball.transform.GetComponent<fireball>().Shoot(transform.localScale.x);
    }
    public void Block()
    {
        if (_shield == null)
        {
            _playerAudio.Play("Block");
            Vector3 shieldpos = new Vector3(transform.localScale.x, -1, 0);
            _shield = Instantiate(_shieldPrefab, transform.position + shieldpos, Quaternion.Euler(new Vector3(0, 0, 20f * transform.localScale.x)));
            _animator.SetBool("block", true);
            Invoke(nameof(StopBlock), 0.5f);
        }
    }
    ////////////////////////////////////////////////////////////////////////////////
    // Stop Attacks - private
    ////////////////////////////////////////////////////////////////////////////////
    private void StopBlock()
    {
        Destroy(_shield);
        _animator.SetBool("block", false);
    }
    private void StopAttack0()
    {
        Destroy(_attack0);
        _playerController.SetInputLock(false);
    }
    private void StopAttack1()
    {
        Destroy(_attack1);
        _playerController.SetInputLock(false);
    }
    private void StopAttack2()
    {
        _playerController.SetInputLock(false);
    }
}