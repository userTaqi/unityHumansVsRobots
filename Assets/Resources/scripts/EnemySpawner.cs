using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameOver script;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] spawnPoints;

    private float spawnInterval = 2f;
    private int enemyPerWave = 1;
    private float timeBetweenWaves = 25f;

    public Text waveText;
    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        waveText = GameObject.FindGameObjectWithTag("waveCount").GetComponent<Text>();
    }

    void Update()
    {
        waveText.text = currentWave.ToString();
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

                List<GameObject> availableEnemies = new List<GameObject>();

                if (currentWave <= 10)
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
                else
                {
                    int strengthLevel = Mathf.FloorToInt((currentWave - 10) / 2f) + 1;
                    strengthLevel = Mathf.Clamp(strengthLevel, 0, enemyPrefabs.Length - 1);

                    for (int j = 0; j <= strengthLevel; j++)
                    {
                        availableEnemies.Add(enemyPrefabs[j]);
                    }
                }

                GameObject enemyPrefabToSpawn = availableEnemies[Random.Range(0, availableEnemies.Count)];

                if (script.gameAlive)
                {
                    GameObject enemy = Instantiate(enemyPrefabToSpawn, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();

                    float forceMagnitude;

                    if (enemyPrefabToSpawn == enemyPrefabs[0])
                    {
                        forceMagnitude = 45f + currentWave * 2.5f;
                    }
                    else if (enemyPrefabToSpawn == enemyPrefabs[1])
                    {
                        forceMagnitude = 65f + currentWave * 0.5F;
                    }
                    else
                    {
                        forceMagnitude = 90f + currentWave * 0.5F;
                    }

                    enemyRigidbody.AddForce(-spawnPoint.transform.right * forceMagnitude);
                }

                yield return new WaitForSeconds(currentSpawnInterval);
            }

            currentWave++;
            enemyPerWave += 2;
            currentSpawnInterval *= 0.90f;
        }
    }
}
