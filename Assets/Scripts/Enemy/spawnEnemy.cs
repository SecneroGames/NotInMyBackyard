using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] float spawnStart = 10f;

    [SerializeField] float spawnSpeed = 10f;
    [SerializeField] float spawnRate = 0.5f;
    private float minSpawnSpeed = 1f;

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        StartCoroutine(Spawn());
        StartCoroutine(UpdateSpawnSpeed());
    }

    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        Invoke("spawnGameobject", spawnStart);
        yield return new WaitForSeconds(spawnSpeed);
        StartCoroutine(Spawn());
    }

    IEnumerator UpdateSpawnSpeed()
    {
        yield return new WaitForSeconds(10f);
        if(spawnSpeed >= minSpawnSpeed)
        {
            spawnSpeed -= spawnRate;
        }
        StartCoroutine(UpdateSpawnSpeed());
    }

    void spawnGameobject()
    {
        int randSpawn = Random.Range(0, spawnPoints.Length);
        Instantiate(objectToSpawn, spawnPoints[randSpawn].transform.position, 
        Quaternion.identity);
    }
}
