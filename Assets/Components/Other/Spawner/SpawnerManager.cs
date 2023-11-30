using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject SpawnEnemy(GameObject enemy)
    {
        enemy = Instantiate(enemy, transform.position, Quaternion.identity);
        return enemy;
    }
}
