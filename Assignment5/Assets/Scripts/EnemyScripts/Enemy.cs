using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float _startingHitPoints = 5;
    [SerializeField] private int _damageStrength;
    [SerializeField] private float _damageInterval = 1f;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private int _maxLootRarity = 0;
    [SerializeField] private int _maxLootQty = 0;
    private Coroutine _damageCoroutine;
    private Coroutine _attackSoundCoroutine;
    private EnemySounds _enemySounds;
    private void Start()
    {
        _healthSlider.maxValue = _startingHitPoints;
        _healthSlider.value = _startingHitPoints;
        _enemySounds = gameObject.GetComponent<EnemySounds>();
    }
    public IEnumerator DamageEnemy(float damage, float interval)
    {
        while (true)
        {
            StartCoroutine(FlickerEnemy());
            _healthSlider.value -= damage;
            if (_healthSlider.value <= float.Epsilon)
            {
                if (_enemySounds != null)
                {
                    _enemySounds.Play("death");
                }
                KillEnemy();
                break;
            }
            if (interval > float.Epsilon)
            {
                if (_enemySounds != null)
                {
                    _enemySounds.Play("hurt");
                }
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
        SpawnLoot();
        Destroy(gameObject);
    }
    public virtual IEnumerator FlickerEnemy()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerResources player = collision.gameObject.GetComponent<PlayerResources>();
            if (_damageCoroutine == null)
            {
                _damageCoroutine = StartCoroutine(player.DamagePlayer(_damageStrength, _damageInterval));
                if(_enemySounds != null)
                {
                    _attackSoundCoroutine = StartCoroutine(attackSound(_damageInterval));
                } 
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
            if (_attackSoundCoroutine != null)
            {
                StopCoroutine(_attackSoundCoroutine);
                _attackSoundCoroutine = null;
            }
        }
    }
    private void SpawnLoot()
    {
        int lootRarity = Random.Range(1, _maxLootRarity + 1);
        int lootQty = Random.Range(0, _maxLootQty);
        Debug.Log("Spawning loot: " + lootRarity + " " + lootQty);
        LootTable lootTable = GameObject.Find("LootTable").GetComponent<LootTable>();
        for (int i = 0; i < lootQty; i++)
        {
            GameObject[] item = lootTable.GetLoot(lootRarity);
            int index = Random.Range(0, item.Length);
            Instantiate(item[index], transform.position, Quaternion.identity);
        }
    }
    private IEnumerator attackSound(float interval)
    {
        while (true)
        {
            _enemySounds.Play("attack");
            yield return new WaitForSeconds(interval);
        }
    }
}
