using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public static float bulletAttackDamage;
    [SerializeField] float bulletDamage;
    [SerializeField] GameObject bulletDestroyFX;
    GameObject bcSFX;
    AudioSource bcAudio;

    void Start()
    {
        bulletAttackDamage = bulletDamage;
        bcSFX = GameObject.FindGameObjectWithTag("BulletCollideSFX");
        bcAudio = bcSFX.GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag != "InsideBoundary")
        {
            bcAudio.Play();
            Destroy(gameObject);
            Instantiate(bulletDestroyFX, transform.position, Quaternion.identity);
        }   
    }
}
