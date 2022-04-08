using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This is probably the worst way to do this, but it works lol.
public class TutorialManager : MonoBehaviour
{
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
    private void TalkForNextStep()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _tutorialStep++;
            _stepActive = false;
        }
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
                case 3:
                    Step3();
                    break;
                case 4:
                    Step4();
                    break;
                case 5:
                    Step5();
                    break;
                case 6:
                    Step6();
                    break;
                case 7:
                    Step7();
                    break;
                case 8:
                    Step8();
                    break;
                case 9:
                    Step9();
                    break;
                case 10:
                    Step10();
                    break;
                case 11:
                    Step11();
                    break;
                case 12:
                    Step12();
                    break;
                case 13:
                    Step13();
                    break;
                case 14:
                    Step14();
                    break;
                case 15:
                    Step15();
                    break;
                case 16:                
                    Step16();
                    break;
                case 17:
                    Step17();
                    break;
                case 18:
                    Step18();
                    break;
                case 19:
                    Step19();
                    break;
                case 20:
                    Step20();
                    break;
                case 21:
                    Step21();
                    break;
                case 22:
                    Step22();
                    break;
                case 23:
                    Step23();
                    break;
                case 24:
                    Step24();
                    break;
                case 25:
                    Step25();
                    break;
                case 26:                
                    Step26();
                    break;
                case 27:
                    Step27();
                    break;
                case 28:
                    Step28();
                    break;
                case 29:
                    Step29();
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
                    if (Input.GetAxis("Horizontal") != 0)
                    {
                        _stepActive = false;
                        _tutorialStep++;
                    }
                    break;
                case 5:
                    TalkForNextStep();
                    break;
                case 6:
                    if (Input.GetButtonDown("Jump"))
                    {
                        _stepActive = false;
                        _tutorialStep++;
                    }
                    break;
                case 7:
                    TalkForNextStep();
                    break;
                case 8:
                    TalkForNextStep();
                    break;
                case 9:
                    TalkForNextStep();
                    break;
                case 10:
                    if (Input.GetButtonDown("Attack0"))
                    {
                        _stepActive = false;
                        _tutorialStep++;
                    }
                    break;
                case 11:
                    if (Input.GetButtonDown("Attack1"))
                    {
                        _stepActive = false;
                        _tutorialStep++;
                    }
                    break;
                case 12:
                    if (Input.GetButtonDown("Attack2"))
                    {
                        _stepActive = false;
                        _tutorialStep++;
                    }
                    break;
                case 13:
                    TalkForNextStep();
                    break;
                case 14:
                    TalkForNextStep();
                    break;
                case 15:
                    TalkForNextStep();
                    break;
                case 16:
                    TalkForNextStep();
                    break;
                case 17:
                    TalkForNextStep();
                    break;
                case 18:
                    TalkForNextStep();
                    break;
                case 19:
                    TalkForNextStep();
                    break;
                case 20:
                    TalkForNextStep();
                    break;
                case 21:
                    TalkForNextStep();
                    break;
                case 22:
                    TalkForNextStep();
                    break;
                case 23:
                    if (Input.GetButtonDown("Jump"))
                    {
                        _stepActive = false;
                        _tutorialStep++;
                    }
                    break;
                case 24:
                    TalkForNextStep();
                    break;
                case 25:
                    if (Input.GetAxis("Sprint") > 0)
                    {
                        _stepActive = false;
                        _tutorialStep++;
                    }
                    break;
                case 26:
                    TalkForNextStep();
                    break;
                case 27:
                    if (Input.GetButtonDown("Block"))
                    {
                        _stepActive = false;
                        _tutorialStep++;
                    }
                    break;
                case 28:
                    TalkForNextStep();
                    break;
                case 29:
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
        _playerController.SetInputLock(false);
    }
    private void Step5()
    {
        _stepActive = true;
        Debug.Log("Step 5");
        _wizardScript.NextSentence();
    }
    private void Step6()
    {
        _stepActive = true;
        Debug.Log("Step 6");
        _wizardScript.NextSentence();
    }
    private void Step7()
    {
        _stepActive = true;
        Debug.Log("Step 7");
        _wizardScript.NextSentence();
    }
    private void Step8()
    {
        _stepActive = true;
        Debug.Log("Step 8");
        _wizardScript.NextSentence();
    }
    private void Step9()
    {
        _stepActive = true;
        Debug.Log("Step 9");
        _wizardScript.NextSentence();
    }
    private void Step10()
    {
        _stepActive = true;
        Debug.Log("Step 10");
        _wizardScript.NextSentence();
    }
    private void Step11()
    {
        _stepActive = true;
        Debug.Log("Step 11");
        _wizardScript.NextSentence();
    }
    private void Step12()
    {
        _stepActive = true;
        Debug.Log("Step 12");
        _wizardScript.NextSentence();
    }
    private void Step13()
    {
        _stepActive = true;
        Debug.Log("Step 13");
        _wizardScript.NextSentence();
    }
    private void Step14()
    {
        _stepActive = true;
        Debug.Log("Step 14");
        _wizardScript.NextSentence();
    }
    private void Step15()
    {
        _stepActive = true;
        Debug.Log("Step 15");
        _wizardScript.NextSentence();
    }
    private void Step16()
    {
        _stepActive = true;
        Debug.Log("Step 16");
        _wizardScript.NextSentence();
    }
    private void Step17()
    {
        _stepActive = true;
        Debug.Log("Step 17");
        _wizardScript.NextSentence();
    }
    private void Step18()
    {
        _stepActive = true;
        Debug.Log("Step 18");
        _wizardScript.NextSentence();
    }
    private void Step19()
    {
        _stepActive = true;
        Debug.Log("Step 19");
        _wizardScript.NextSentence();
    }
    private void Step20()
    {
        _stepActive = true;
        Debug.Log("Step 20");
        _wizardScript.NextSentence();
    }
    private void Step21()
    {
        _stepActive = true;
        Instantiate(_strawberry, new Vector3(Random.Range(-5,5), -5, 0), Quaternion.identity);
        Instantiate(_banana, new Vector3(Random.Range(-5, 5), -5, 0), Quaternion.identity);
        Instantiate(_orange, new Vector3(Random.Range(-5, 5), -5, 0), Quaternion.identity);
        Instantiate(_apple, new Vector3(Random.Range(-5, 5), -5, 0), Quaternion.identity);
        Debug.Log("Step 21");
        _wizardScript.NextSentence();
    }
    private void Step22()
    {
        _stepActive = true;
        Debug.Log("Step 22");
        _wizardScript.NextSentence();
    }
    private void Step23()
    {
        _stepActive = true;
        Debug.Log("Step 23");
        _wizardScript.NextSentence();
    }
    private void Step24()
    {
        _stepActive = true;
        Debug.Log("Step 24");
        _wizardScript.NextSentence();
    }
    private void Step25()
    {
        _stepActive = true;
        Debug.Log("Step 25");
        _wizardScript.NextSentence();
    }
    private void Step26()
    {
        _stepActive = true;
        Debug.Log("Step 26");
        _wizardScript.NextSentence();
    }
    private void Step27()
    {
        _stepActive = true;
        Debug.Log("Step 27");
        _wizardScript.NextSentence();
    }
    private void Step28()
    {
        _stepActive = true;
        Debug.Log("Step 28");
        _wizardScript.NextSentence();
    }
    private void Step29()
    {
        _stepActive = true;
        Debug.Log("Step 29");
        _wizardScript.NextSentence();
        _rightWall.SetActive(false);
    }
}
