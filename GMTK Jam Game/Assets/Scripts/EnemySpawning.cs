using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] List<GameObject> spawnEnemies;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float playerScoreTarget = 1000;
    [SerializeField] private float playerScoreIntervals = 1000;
    [SerializeField] private PlayerComponent player;

    void Start()
    {
        //SpawnEnemy();
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.score >= playerScoreTarget)
        {
            spawnInterval *= 0.85f;
            CancelInvoke();
            InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
            playerScoreTarget += playerScoreIntervals;
        }
    }

    void SpawnEnemy()
    {
        GameObject spawnpoint = spawnPoints[Random.Range(0, spawnPoints.Count - 1)];
        GameObject spawnEnemy = spawnEnemies[Random.Range(0, spawnEnemies.Count - 1)];

        Instantiate(spawnEnemy, spawnpoint.transform);
    }
}
