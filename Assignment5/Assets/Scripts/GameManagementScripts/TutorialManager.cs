using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // Wizard
    private GameObject _wizard;
    private Wizard _wizardScript;
    [SerializeField] private GameObject _wizardPrefab;
    [SerializeField] private float _wizardSpeed = 10f;
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
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");


    }
    void Start()
    {
        _playerController = _player.GetComponent<PlayerController>();
        _playerController.SetInputLock(true);
        _tutorialStep = 1;
        _stepActive = false;
    }

    // Update is called once per frame
    void FixedUpdate()
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
                case 3:
                    Step3();
                    break;
            }
        }
        if (_stepActive)
        {
            switch (_tutorialStep)
            {
                case 2:
                    TalkForNextStep();
                    break;
                case 3:
                    TalkForNextStep();
                    break;
                case 4:
                    TalkForNextStep();
                    break;
            }
        }
    }

    private void Step1()
    {
        _stepActive = true;
        Debug.Log("Step 1");
        Vector3 wizardStartPos = new Vector3(15, -5, 0);
        _wizard = Instantiate(_wizardPrefab, wizardStartPos, Quaternion.identity);
        _wizardScript = _wizard.gameObject.GetComponent<Wizard>();
        Coroutine _wizardFirstMove = StartCoroutine(_wizardScript.Move(new Vector3(-5, -5, 0), _wizardSpeed, gameObject));
    }
    private void Step2()
    {
        _stepActive = true;
        Debug.Log("Step 2");
        _wizardScript.ToggleSpeechBubble(true);
        _wizardScript.NextSentence();
    }
    private void Step3()
    {
        _stepActive = true;
        Debug.Log("Step 3");
        _wizardScript.NextSentence();
    }
    private void Step4()
    {
        _stepActive = true;
        Debug.Log("Step 4");
        _wizardScript.NextSentence();
    }
    private void TalkForNextStep()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _tutorialStep++;
            _stepActive = false;
        }
    }
}
