using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int enemyAmount = 3;
    private int enemiesAlive;
    private float spawnRate = 2.0f;
    private float timeSinceLastSpawn;
    private bool startWave = false;
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();

    public int EnemiesAlive => enemiesAlive;

    private void Start()
    {
        enemiesAlive = enemyAmount;
    }

    private void Update()
    {
        if (startWave)
        {
            SpawnWave();
        }
        //Spawnea enemigos cada 1 segundo
    }

    private void SpawnWave()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnRate && enemyAmount != 0)
        {
            GameObject enemy = Instantiate(enemyPrefabs[0].gameObject, GameManager.instance.startPoint);
            enemy.transform.parent = null;
            Debug.Log("Spawning Enemy");
            timeSinceLastSpawn = 0;
            enemyAmount--;            
        }

    }

    public void StartWave()
    {
        GameManager.instance.SetTowerPlacementSystem(false);
        startWave = true;
    }

}
