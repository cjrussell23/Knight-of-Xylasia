using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private GameObject _player;
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private GameObject _attackPrefab;
    private GameObject attack;
    private Vector3 _endPosition;
    Coroutine move;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        move = StartCoroutine(Move());
    }
    private void FixedUpdate() {
        _endPosition = _player.transform.position;
        if (_endPosition.x < transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    public IEnumerator Move()
    {   
        float remainingDistance = (transform.position - _endPosition).sqrMagnitude;
        while (remainingDistance > float.Epsilon)
        {
            _animator.SetBool("isWalking", true);
            Vector3 newPosition = Vector3.MoveTowards(_rb.position, _endPosition, _speed * Time.deltaTime);
            _rb.MovePosition(newPosition);
            remainingDistance = (transform.position - _endPosition).sqrMagnitude;

            yield return new WaitForFixedUpdate();
        }
        _animator.SetBool("isWalking", false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            if (move != null)
            {
                StopCoroutine(move);
                move = null;
            }
            Debug.Log("attack");
            _animator.SetBool("attack0", true);
            Invoke(nameof(StartAttack), 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            Invoke(nameof(StopAttack), 1f);
        }
        if (move == null)
        {
            move = StartCoroutine(Move());
        }
    }
    private void StartAttack(){
        if(attack == null)
            attack = Instantiate(_attackPrefab, transform.position + new Vector3(2.4183f * Mathf.Sign(transform.localScale.x), 0.1895f, 0 ), Quaternion.identity, transform);
    }
    private void StopAttack(){
        _animator.SetBool("attack0", false);
        if(attack != null)
            Destroy(attack);
    }
}
