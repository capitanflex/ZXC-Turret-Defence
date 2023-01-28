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
    
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private TextMeshProUGUI _wavesText;
    [SerializeField] private TextMeshProUGUI _enemiesCountText;
    
    public int waveID;
    public int _enemiesCount;
    
    
    private void Start()
    {
        StartCoroutine(DelaySpawn());
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

        if (_timeBetweenSpawn >= 0.2f)
        {
            _timeBetweenSpawn -= 0.1f;
        }
    }
    
    private void Spawn()
    {
        
        Instantiate(_enemy, _spawnPoints[Random.Range(0, _spawnPoints.Count)].position, _spawnPoints[Random.Range(0, _spawnPoints.Count)].rotation );
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
