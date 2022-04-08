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
        dialog.Enqueue("Hello, Walcome to Xylesia! I'm the Wizard! Press 'T' to talk to me!\n..."); // Step 2
        dialog.Enqueue("I'm here to help you get started.\n..."); // Step 3
        dialog.Enqueue("You can move around by pressing the arrow keys.\n..."); // Step 4
        dialog.Enqueue("Wow, looking alive!\n..."); // Step 5
        dialog.Enqueue("You can also jump by pressing the spacebar.\n..."); // Step 6
        dialog.Enqueue("That's great!\n..."); // Step 7
        dialog.Enqueue("Now, this world can be very dangerous so you will need to defend yourself\n..."); // Step 8
        dialog.Enqueue("You have 3 different attacks.\n..."); // Step 9
        dialog.Enqueue("The first is a basic attack. Press 'Left Click'.\n..."); // Step 10
        dialog.Enqueue("The second is a special attack. Press 'Right Click'.\n..."); // Step 11
        dialog.Enqueue("The third is your magic. Press 'F'.\n..."); // Step 12
        dialog.Enqueue("Some of you abilities cost mana.\n..."); // Step 13
        dialog.Enqueue("You can see your mana (blue bar) in the top left corner.\n..."); // Step 14
        dialog.Enqueue("Above you mana is your health (red bar).\n..."); // Step 15
        dialog.Enqueue("Mana is a magical resource that comes from all around!\n..."); // Step 16
        dialog.Enqueue("It will slowly return to you over time.\n..."); // Step 17
        dialog.Enqueue("This world is also full of magical fruits!\n..."); // Step 18 
        dialog.Enqueue("Some enemies will drop fruit that they are hoarding.\n..."); // Step 19
        dialog.Enqueue("You can eat the fruit by clicking them in your Inventory.\n..."); // Step 20
        dialog.Enqueue("Here are some fruits that you can eat.\n..."); // Step 21
        dialog.Enqueue("Now, you can also use your mana to jump higher!\n..."); // Step 22
        dialog.Enqueue("Press jump again while in the air to mana jump!\n..."); // Step 23
        dialog.Enqueue("You can also use your mana to run faster!\n..."); // Step 24
        dialog.Enqueue("Press 'Shift' mana run!\n..."); // Step 25
        dialog.Enqueue("Ok, I think thats all...\nOh wait one last thing!\n..."); // Step 26
        dialog.Enqueue("You can also block enemy attacks! Press 'R' to block.\n..."); // Step 27
        dialog.Enqueue("Alrighty! Thats all I can teach you for now.\n..."); // Step 28
        dialog.Enqueue("Go to the right to start your adventure. Good luck!\n..."); // Step 29
        return dialog;
    }
}
