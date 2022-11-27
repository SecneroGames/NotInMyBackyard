using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletSpawnLoc;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shootFlashFX;
    [SerializeField] float speed;
    [SerializeField] float fireRate = 1f;
    Animator anim;

    
    float spawnRate = 1f;
    float timeStamp = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(PlayerMovement.isIdle == false)
        {
            runShoot();
        }
        else
        {
            idleShoot();
        }
    }

    void runShoot()
    {
        if(Input.GetKey(KeyCode.Mouse0) && Time.time >= timeStamp)
        {
            timeStamp = Time.time + fireRate;
            spawnBullet();
        }
    }

    void idleShoot()
    {
        if(Input.GetKey(KeyCode.Mouse0) && Time.time >= timeStamp)
        {
            timeStamp = Time.time + spawnRate;
            anim.SetBool("Attack", true);
            Invoke("spawnBullet", 0.3f);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    void spawnBullet()
    {
        Instantiate(shootFlashFX, bulletSpawnLoc.transform.position, transform.rotation);

        GameObject projectile = 
        Instantiate(bullet, bulletSpawnLoc.transform.position, Quaternion.identity);

        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
}
