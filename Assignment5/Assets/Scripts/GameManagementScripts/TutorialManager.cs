using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This is probably the worst way to do this, but it works lol.
public class TutorialManager : MonoBehaviour
{
    // Sounds
    private SoundManager _soundManager;
    // Fruits
    [SerializeField] private GameObject _apple;
    [SerializeField] private GameObject _banana;
    [SerializeField] private GameObject _orange;
    [SerializeField] private GameObject _strawberry;
    // Wizard
    private GameObject _wizard;
    private Wizard _wizardScript;
    [SerializeField] private GameObject _wizardPrefab;
    [SerializeField] private float _wizardSpeed = 20f;
    // Walls
    [SerializeField] private GameObject _rightWall;
    // Player
    private GameObject _player;
    private PlayerController _playerController;
    // Tutorial Steps
    private int _tutorialStep;
    private bool _stepActive;
    public bool StepActive
    {
        get { return _stepActive; }
        set { _stepActive = value; }
    }
    public int TutorialStep
    {
        get { return _tutorialStep; }
        set { _tutorialStep = value; }
    }
    private void NextStep()
    {
        _tutorialStep++;
        _stepActive = false;
        _soundManager.ButtonClick();
    }
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    void Start()
    {
        _playerController = _player.GetComponent<PlayerController>();
        _playerController.SetInputLock(true);
        _tutorialStep = 1;
        _stepActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_stepActive)
        {
            switch (_tutorialStep)
            {
                case 1:
                    Step1();
                    break;
                case 2:
                    Step2();
                    break;
                case 4:
                    Step4();
                    break;
                case 21:
                    Step21();
                    break;
                case 29:
                    Step29();
                    break;
                default:
                    NormalStep();
                    break;
            }
        }
        if (_stepActive && _tutorialStep < 30)
        {
            switch (_tutorialStep)
            {
                case 1:
                    break;
                case 4:
                    if (Input.GetAxis("Horizontal") != 0)
                    {
                        NextStep();
                    }
                    break;
                case 6:
                    if (Input.GetButtonDown("Jump"))
                    {
                        NextStep();
                    }
                    break;
                case 10:
                    if (Input.GetButtonDown("Attack0"))
                    {
                        NextStep();
                    }
                    break;
                case 11:
                    if (Input.GetButtonDown("Attack1"))
                    {
                        NextStep();
                    }
                    break;
                case 12:
                    if (Input.GetButtonDown("Attack2"))
                    {
                        NextStep();
                    }
                    break;
                case 23:
                    if (Input.GetButtonDown("Jump"))
                    {
                        NextStep();
                    }
                    break;
                case 25:
                    if (Input.GetAxis("Sprint") > 0)
                    {
                        NextStep();
                    }
                    break;
                case 27:
                    if (Input.GetButtonDown("Block"))
                    {
                        NextStep();
                    }
                    break;
                default:
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        NextStep();
                    }
                    break;
            }
        }
    }
    private void NormalStep()
    {
        _stepActive = true;
        Debug.Log($"Step {_tutorialStep}");
        _wizardScript.NextSentence();
    }
    private void Step1()
    {
        _stepActive = true;
        Debug.Log($"Step {_tutorialStep}");
        Vector3 wizardStartPos = new Vector3(15, -5, 0);
        _wizard = Instantiate(_wizardPrefab, wizardStartPos, Quaternion.identity);
        _wizardScript = _wizard.gameObject.GetComponent<Wizard>();
        Coroutine _wizardFirstMove = StartCoroutine(_wizardScript.Move(new Vector3(-5, -5, 0), _wizardSpeed, gameObject));
    }

    private void Step2()
    {
        _stepActive = true;
        Debug.Log($"Step {_tutorialStep}");
        _wizardScript.ToggleSpeechBubble(true);
        _wizardScript.NextSentence();
    }
    private void Step4()
    {
        _stepActive = true;
        Debug.Log($"Step {_tutorialStep}");
        _playerController.SetInputLock(false);
        _wizardScript.NextSentence();
    }
    private void Step21()
    {
        _stepActive = true;
        Debug.Log($"Step {_tutorialStep}");
        Instantiate(_strawberry, new Vector3(Random.Range(-5, 5), -5, 0), Quaternion.identity);
        Instantiate(_banana, new Vector3(Random.Range(-5, 5), -5, 0), Quaternion.identity);
        Instantiate(_orange, new Vector3(Random.Range(-5, 5), -5, 0), Quaternion.identity);
        Instantiate(_apple, new Vector3(Random.Range(-5, 5), -5, 0), Quaternion.identity);
        _wizardScript.NextSentence();
    }
    private void Step29()
    {
        _stepActive = true;
        //Debug.Log($"Step {_tutorialStep}");
        _rightWall.SetActive(false);
    }
}
