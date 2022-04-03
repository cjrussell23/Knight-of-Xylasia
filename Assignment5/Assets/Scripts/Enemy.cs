using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _hitPoints;
    [SerializeField] protected float _startingHitPoints = 5;
    [SerializeField] private int _damageStrength;
    private Coroutine _damageCoroutine;
    public IEnumerator DamageEnemy(int damage, float interval)
    {
        while (true)
        {
            StartCoroutine(FlickerEnemy());
            _hitPoints = _hitPoints - damage;
            if (_hitPoints <= float.Epsilon)
            {
                KillEnemy();
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
    public virtual void KillEnemy()
    {
        Destroy(gameObject);
    }
    public virtual IEnumerator FlickerEnemy()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void ResetEnemy()
    {
        _hitPoints = _startingHitPoints;
    }
    private void OnEnable()
    {
        ResetEnemy();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (_damageCoroutine == null)
            {
                _damageCoroutine = StartCoroutine(player.DamagePlayer(_damageStrength, 1.0f));
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_damageCoroutine != null)
            {
                StopCoroutine(_damageCoroutine);
                _damageCoroutine = null;
            }
        }
    }
}
