using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class WaveManager : MonoBehaviour
{
    public List<SpawnerManager> spawners = new();
    public List<GameObject> enemyObjects = new();
    public int wave = 0;
    public int enemyNumber = 0;

    private List<GameObject> _enemies = new();
    private List<GameObject> _temporaryList = new();
    private float _timer;
    private float _spawnTimer;
    void FixedUpdate()
    {
        while (_enemies.Remove(null)) ;

        if (_enemies.Count == 0)
        {
            _timer += Time.deltaTime;
            if (_timer >= 10)
            {
                wave += 1;
                enemyNumber = wave * 5;
                GenerateEnemies();
                _timer = 0;
            }
        }

        if (_temporaryList.Count != 0)
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= 5)
            {   
                SpawnEnemies();
                _spawnTimer = 0;
            }
        }
    }

    private void GenerateEnemies()
    {
        for (var i = 0; i < enemyNumber; i += 1)
        {
            var randomEnemy = Random.Range(0, enemyObjects.Count);
            _temporaryList.Add(enemyObjects[randomEnemy]);
        }
    }

    private void SpawnEnemies()
    {
        var randomSpawner = Random.Range(0, spawners.Count);
        var spawnedEnemy = spawners[randomSpawner].SpawnEnemy(_temporaryList.First());
        _temporaryList.RemoveAt(0);
        _enemies.Add(spawnedEnemy);
    }
}
