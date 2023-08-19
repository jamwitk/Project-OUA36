using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemys : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawners;
    private int initialEnemyCount;
    public static bool spawned = true;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start()
    {
        initialEnemyCount = spawners.Length;
        spawned = true;
    }

    void Update()
    {
        if (spawned)
        {
            DestroyPreviousEnemies();

            for (int i = 0; i < initialEnemyCount; i++)
            {
                GameObject newEnemy = Instantiate(enemy, spawners[i].transform.position, Quaternion.identity);
                spawnedEnemies.Add(newEnemy);
            }

            spawned = false;
        }
    }

    private void DestroyPreviousEnemies()
    {
        foreach (GameObject enemyss in spawnedEnemies)
        {
            Destroy(enemyss);
        }

        spawnedEnemies.Clear();
    }
}