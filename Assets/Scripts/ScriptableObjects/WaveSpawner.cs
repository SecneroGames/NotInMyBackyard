using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
 
    private Wave currentWave;
 
    [SerializeField]
    private Transform[] spawnpoints;
 
    private float timeBtwnSpawns;
    private int i = 0;
 
    private bool stopSpawning = false;
 
    private void Awake()
    {
 
        currentWave = waves[i];
        timeBtwnSpawns = currentWave.TimeBeforeThisWave;
    }
 
    private void Update()
    {
        if (stopSpawning)
        {
            return;
        }
 
        if (Time.time >= timeBtwnSpawns)
        {
            SpawnWave();
            IncWave();
 
            timeBtwnSpawns = Time.time + currentWave.TimeBeforeThisWave;
        }
    }
 
    private void SpawnWave()
    {
        int i = 0;
 
        foreach (var enemyType in currentWave.EnemyTypes)
        {
            SpawnEnemyType(i);
            i++;
        }
    }
 
    private void SpawnEnemyType(int index)
    {
        if(currentWave.EnemyTypes[index] != null)
        {
            for (int i = 0; i < currentWave.NumberTypesToSpawn[index]; i++)
            {
                int num = Random.Range(0, spawnpoints.Length);
 
                Instantiate(currentWave.EnemyTypes[index], spawnpoints[num].position, 
                spawnpoints[num].rotation);
            }
        }
    }
 
    private void IncWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
        }
        else
        {
            stopSpawning = true;
        }
    }
}
