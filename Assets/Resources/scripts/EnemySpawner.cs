using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameOver script;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] spawnPoints;

    private float spawnInterval = 10f;
    private int enemyPerWave = 2;
    private float timeBetweenWaves = 15f;

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        float currentSpawnInterval = spawnInterval;

        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            for (int i = 0; i < enemyPerWave; i++)
            {
                int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
                GameObject spawnPoint = spawnPoints[randomSpawnPointIndex];

                int strengthLevel = Mathf.FloorToInt(currentWave / 2f);
                strengthLevel = Mathf.Clamp(strengthLevel, 0, enemyPrefabs.Length - 1);

                List<GameObject> availableEnemies = new List<GameObject>();
                for (int j = 0; j <= strengthLevel; j++)
                {
                    if (j == 0)
                    {
                        availableEnemies.Add(enemyPrefabs[0]);
                        availableEnemies.Add(enemyPrefabs[0]);
                        availableEnemies.Add(enemyPrefabs[0]);
                        availableEnemies.Add(enemyPrefabs[0]);
                        availableEnemies.Add(enemyPrefabs[0]);
                        availableEnemies.Add(enemyPrefabs[0]);
                        availableEnemies.Add(enemyPrefabs[0]);
                        availableEnemies.Add(enemyPrefabs[0]);
                    }
                    else if (j == 1)
                    {
                        availableEnemies.Add(enemyPrefabs[1]);
                        availableEnemies.Add(enemyPrefabs[1]);
                    }
                    else
                    {
                        availableEnemies.Add(enemyPrefabs[j]);
                    }
                }

                GameObject enemyPrefabToSpawn = availableEnemies[Random.Range(0, availableEnemies.Count)];
                
                if(script.gameAlive){
                GameObject enemy = Instantiate(enemyPrefabToSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation);
                Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
                float forceMagnitude = enemyPrefabToSpawn == enemyPrefabs[0] ? 40f : 70f;
                enemyRigidbody.AddForce(-spawnPoint.transform.right * forceMagnitude);
                }

                yield return new WaitForSeconds(currentSpawnInterval);
            }

            currentWave++;
            enemyPerWave++;
            currentSpawnInterval *= 0.98f;
        }
    }
}