using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] spawnPoints;

    public float spawnInterval = 2f;
    private int enemyPerWave = 3;
    public float timeBetweenWaves = 10f;

    private int currentWave = 0;
    private bool isSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        isSpawning = true;
        float currentSpawnInterval = spawnInterval;

        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            for (int i = 0; i < enemyPerWave; i++)
            {
                int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
                GameObject spawnPoint = spawnPoints[randomSpawnPointIndex];

                int strengthLevel = Mathf.FloorToInt(currentWave / 2f); // Increase strength level every 5 waves
                strengthLevel = Mathf.Clamp(strengthLevel, 0, enemyPrefabs.Length - 1); // Clamp strength level to array bounds

                // Create a list of enemy prefabs that can spawn at the current strength level, with the desired spawn rates
                List<GameObject> availableEnemies = new List<GameObject>();
                for (int j = 0; j <= strengthLevel; j++)
                {
                    if (j == 0)
                    {
                        // Add enemyPrefabs[0] with 70% spawn rate
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
                        // Add enemyPrefabs[1] with 30% spawn rate
                        availableEnemies.Add(enemyPrefabs[1]);
                        availableEnemies.Add(enemyPrefabs[1]);
                    }
                    else
                    {
                        availableEnemies.Add(enemyPrefabs[j]);
                    }
                }

                // Randomly select an enemy prefab from the available enemies list
                GameObject enemyPrefabToSpawn = availableEnemies[Random.Range(0, availableEnemies.Count)];

                GameObject enemy = Instantiate(enemyPrefabToSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation);
                enemy.GetComponent<Rigidbody2D>().AddForce(-spawnPoint.transform.right * 30f);

                yield return new WaitForSeconds(currentSpawnInterval);
            }

            currentWave++;
            enemyPerWave++;
            currentSpawnInterval *= 0.98f; // Gradually decrease spawn interval by 2% every wave
        }
    }

}
