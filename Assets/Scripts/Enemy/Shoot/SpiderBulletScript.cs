using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBulletScript : MonoBehaviour
{
    [SerializeField] float bulletDamage;
    [SerializeField] GameObject bulletDestroyFX;
    GameObject bcSFX;
    GameObject player;
    PlayerHealth playerHealth;
    GameObject hurtSFX;
    AudioSource hurtAudio;
    AudioSource bcAudio;

    void Start()
    {
        bcSFX = GameObject.FindGameObjectWithTag("BulletCollideSFX");
        bcAudio = bcSFX.GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        hurtSFX = GameObject.FindGameObjectWithTag("HurtSFX");
        hurtAudio = hurtSFX.GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag != "InsideBoundary")
        {
            bcAudio.Play();
            Destroy(gameObject);
            Instantiate(bulletDestroyFX, transform.position, Quaternion.identity);
        }

        if(col.gameObject.tag == "Player")
        {
            CameraShake.Instance.ShakeCamera(4f, 0.1f);
            playerHealth.currentHealth -= bulletDamage;
            playerHealth.UpdatePlayerHealthBar();
            hurtAudio.Play();
        }   
    }
}
