using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletSpawnLoc;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shootFlashFX;
    [SerializeField] float speed;
    [SerializeField] float spawnRate = 2f;
    float timeStamp = 0f;
    

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Shoot()
    {
        if(Time.time >= timeStamp)
        {
            timeStamp = Time.time + spawnRate;
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        Instantiate(shootFlashFX, bulletSpawnLoc.transform.position, transform.rotation);

        GameObject projectile = 
        Instantiate(bullet, bulletSpawnLoc.transform.position, Quaternion.identity);

        projectile.GetComponent<Rigidbody>().AddForce(-transform.forward * speed);
    }
}
