using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] spawnPoints;

    public float spawnInterval = 2f;
    public int enemyPerWave = 5;
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

        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            currentWave++;

            for (int i = 0; i < enemyPerWave; i++)
            {
                int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
                GameObject spawnPoint = spawnPoints[randomSpawnPointIndex];

                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                enemy.GetComponent<Rigidbody2D>().AddForce(-spawnPoint.transform.right * 70f);


                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}

