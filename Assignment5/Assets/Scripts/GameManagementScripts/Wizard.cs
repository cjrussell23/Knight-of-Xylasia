using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private Queue<string> _speechQueue;
    [SerializeField] private Image _speechBubble;
    [SerializeField] private Text _speechText;
    void Awake()
    {
        _speechQueue = Dialog();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    public IEnumerator Move(Vector3 target, float speed, GameObject tutorial = null)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            _anim.SetBool("Walking", true);
            Vector3 newpos = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            _rb.MovePosition(newpos);
            yield return null;
        }
        
        _anim.SetBool("Walking", false);
        if (tutorial != null){
            TutorialManager tm = tutorial.GetComponent<TutorialManager>();
            tm.TutorialStep++;
            tm.StepActive = false;
        }
        yield return new WaitForFixedUpdate();
    }
    public void ToggleSpeechBubble(bool active){
        _speechBubble.GetComponent<Image>().enabled = active;
        _speechText.GetComponent<Text>().enabled = active;
    }
    public void NextSentence(){
        _speechText.GetComponent<Text>().text = _speechQueue.Dequeue();
    }
    private Queue<string> Dialog()
    {
        Queue<string> dialog = new Queue<string>();
        dialog.Enqueue("Hello, I'm the Wizard! Press 'T' to talk to me!");
        dialog.Enqueue("I'm here to help you get started.");
        dialog.Enqueue("You can move around by pressing the arrow keys.");
        return dialog;
    }
}
