using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]
public class Wander : MonoBehaviour
{
    [SerializeField] private float _pursuitSpeed = 1.4f;
    [SerializeField] private float _wanderSpeed = 0.8f;
    private float _currentSpeed = 3;
    [SerializeField] private float _directionChangeInterval = 3;
    [SerializeField] private bool followPlayer = true;
    private bool flip;
    private Coroutine _moveCoroutine;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Transform _targetTransform = null;
    private Vector3 _endPosition;
    private float _currentAngle = 0;
    private CircleCollider2D _circleCollider; // debuging
    void Start()
    {
        _anim = GetComponent<Animator>();
        _currentSpeed = _wanderSpeed;
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WanderRoutine());
        _circleCollider = GetComponent<CircleCollider2D>();
    }
    public IEnumerator WanderRoutine()
    {
        while (true)
        {
            ChooseNewEndpoint();
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }
            _moveCoroutine = StartCoroutine(Move(_rb, _currentSpeed));
            yield return new WaitForSeconds(_directionChangeInterval);
        }
    }
    void ChooseNewEndpoint()
    {
        _currentAngle += Random.Range(0, 360);
        _currentAngle = Mathf.Repeat(_currentAngle, 360);
        _endPosition += Vector3FromAngle(_currentAngle);
        if(_endPosition.x < transform.position.x){
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    Vector3 Vector3FromAngle(float inputAngleDegrees)
    {
        float inputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(inputAngleRadians), Mathf.Sin(inputAngleRadians), 0);
    }
    public IEnumerator Move(Rigidbody2D rbToMove, float speed)
    {
        float remainingDistance = (transform.position - _endPosition).sqrMagnitude;
        while (remainingDistance > float.Epsilon)
        {
            if (_targetTransform != null)
            {
                _endPosition = _targetTransform.position;
            }
            if (rbToMove != null)
            {
                _anim.SetBool("isWalking", true);
                Vector3 newPosition = Vector3.MoveTowards(rbToMove.position, _endPosition, speed * Time.deltaTime);
                _rb.MovePosition(newPosition);
                remainingDistance = (transform.position - _endPosition).sqrMagnitude;
            }
            yield return new WaitForFixedUpdate();
        }
        _anim.SetBool("isWalking", false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
        followPlayer)
        {
            _currentSpeed = _pursuitSpeed;
            _targetTransform = collision.gameObject.transform;
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }
            _moveCoroutine = StartCoroutine(Move(_rb, _currentSpeed));
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _anim.SetBool("isWalking", false);
            _currentSpeed = _wanderSpeed;
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }
            _targetTransform = null;
        }
    }
    void OnDrawGizmos()
    {
        if (_circleCollider != null)
        {
            Gizmos.DrawWireSphere(transform.position, _circleCollider.radius);
            Debug.DrawLine(_rb.position, _endPosition, Color.red);
        }
    }
}