using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField] private int enemyCountInWave;
    [SerializeField] private float _enemyHp;
    [SerializeField] private float _enemyDamage;
    
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private TextMeshProUGUI _wavesText;
    [SerializeField] private TextMeshProUGUI _enemiesCountText;
    
    public int waveID;
    public int _enemiesCount;
    
    public bool canMove = true;
    
    
    
    private void Start()
    {
        StartCoroutine(DelaySpawn());
        canMove = true;
    }

    private void Update()
    {
        _wavesText.text = "Wave: " + waveID;
        _enemiesCountText.text = "Enemies least: " + _enemiesCount;
    }

    
    private void NextWave()
    {
        
        waveID += 1;
        enemyCountInWave += 5 + waveID ^ 2;
        _enemiesCount += enemyCountInWave;
        _enemyHp = _enemyHp * 1.15f + 2;
        _enemyDamage = _enemyDamage * 1.13f + 2;

        if (_timeBetweenSpawn >= 0.15f)
        {
            _timeBetweenSpawn -= 0.1f;
        }
    }
    
    private void Spawn()
    {
        if (canMove)
        {
            GameObject enemy = Instantiate(_enemy, _spawnPoints[Random.Range(0, _spawnPoints.Count)].position, _spawnPoints[Random.Range(0, _spawnPoints.Count)].rotation );
            enemy.GetComponent<Enemy>().SetStats(_enemyHp, _enemyDamage);
        }

        
    }

    private IEnumerator DelaySpawn()
    {
        while (true)
        {
            for (int i = 0; i < enemyCountInWave; i++)
            {
                Spawn();
                yield return new WaitForSeconds(_timeBetweenSpawn);
            }
            yield return new WaitForSeconds(_timeBetweenWaves);
            NextWave();
        }
        
    }
}
