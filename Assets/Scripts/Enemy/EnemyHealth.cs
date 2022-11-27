using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float currentHealth = 10;
    [SerializeField] float maxHealth = 10;
    [SerializeField] GameObject spiderDestroyFX;
    [SerializeField] EnemyHealthBar enemyHealthBar;

    GameObject destroySFX;
    AudioSource destroyAudio;

    void Start()
    {
        destroySFX = GameObject.FindGameObjectWithTag("DestroySFX");
        destroyAudio = destroySFX.GetComponent<AudioSource>();

        currentHealth = maxHealth;

        enemyHealthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            currentHealth -= BulletScript.bulletAttackDamage;
            enemyHealthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
    }

    void Die()
    {
        ScoreScript.score++;
        destroyAudio.Play();
        Instantiate(spiderDestroyFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
