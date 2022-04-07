using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private BooleanVariable _inventoryHover;
    // Variables
    private bool _gameOver;
    private bool _invulnerable;
    private bool _inputLock;
    
    // Other Player Scripts
    private PlayerResources _playerResources;
    private PlayerActions _playerActions;
    private PlayerAudio _playerAudio;
    // Components
    private Animator _animator;

    void Start()
    {
        // Other Player Scripts
        _playerResources = GetComponent<PlayerResources>();
        _playerActions = GetComponent<PlayerActions>();
        _playerAudio = GetComponent<PlayerAudio>();
        // Variables
        _inputLock = false;
        _gameOver = false;
        // Components
        _animator = GetComponent<Animator>();
        
    }
    void Update()
    {
        if (!_gameOver)
        {
            if (!_inputLock)
            {
                if (Input.GetButtonDown("Block"))
                {
                    _playerActions.Block();
                }
                if (Input.GetButton("Sprint"))
                {
                    _playerActions.Sprint();
                }
                else
                {
                    _playerActions.Walk();
                }
                // After setting the speed with walk/sprint, move the player
                _playerActions.Move();
                if (Input.GetButtonDown("Attack0") && _inventoryHover.Value == false)
                {
                    _playerActions.Attack0();
                }
                if (Input.GetButtonDown("Attack1"))
                {
                    _playerActions.Attack1();
                }
                if (Input.GetAxis("Attack2") > 0)
                {
                    _playerActions.Attack2();
                } 
                if (Input.GetButtonDown("Jump"))
                {
                    _playerActions.Jump();
                }
            }
        }
        // Game over
        else
        {
            _animator.SetFloat("speed", 0);
        }
    }
    public void SetInputLock(bool locked)
    {
        _inputLock = locked;
    }
}
