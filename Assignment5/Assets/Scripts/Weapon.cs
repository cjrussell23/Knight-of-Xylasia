using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Coroutine _damageCoroutine;
    [SerializeField] private int _weaponDamage;
    private void OnCollisionEnter2D(Collision2D collison) {
        if(collison.gameObject.CompareTag("Enemy")){
            Enemy enemy = collison.gameObject.GetComponent<Enemy>();
            if (_damageCoroutine == null)
            {
                _damageCoroutine = StartCoroutine(enemy.DamageEnemy(_weaponDamage, 1.0f));
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (_damageCoroutine != null)
            {
                StopCoroutine(_damageCoroutine);
                _damageCoroutine = null;
            }
        }
    }
}
