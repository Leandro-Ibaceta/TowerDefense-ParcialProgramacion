using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int enemyAmount = 5;
    private float spawnRate = 1.0f;
    private float timeSinceLastSpawn;
    [SerializeField] private List<Enemy> typeOfEnemy = new List<Enemy>();

    private void Update()
    {
        //Spawnea enemigos cada 1 segundo
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnRate)
        {
          
            Debug.Log("Spawning Enemy");
            timeSinceLastSpawn = 0;
        }
    }

}
