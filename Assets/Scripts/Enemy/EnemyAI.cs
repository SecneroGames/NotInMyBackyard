using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float dist;
    [SerializeField] float enemyDamage = 1f;
    GameObject player;
    PlayerHealth playerHealth;
    Transform target;
    NavMeshAgent enemy;
    Rigidbody rb;
    Animator anim;
    GameObject hurtSFX;
    AudioSource hurtAudio;
    float attackDistance;

    void Start()
    {
        hurtSFX = GameObject.FindGameObjectWithTag("HurtSFX");
        hurtAudio = hurtSFX.GetComponent<AudioSource>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        attackDistance = GetComponent<NavMeshAgent>().stoppingDistance;
    }

    void Update()
    {
        followPlayer();

        dist = Vector3.Distance(transform.position, target.transform.position);
        attackAnim();
    }

    void followPlayer()
    {
        enemy.SetDestination(target.position);
        transform.LookAt(2 * transform.position - target.position);
    }

    void attackAnim()
    {
        if(dist <= attackDistance)
        {
            anim.SetBool("Attack1", true);
        }
        else
        {
            anim.SetBool("Attack1", false);
        }   
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            dealDamage();
        }
    }

    void dealDamage()
    {
        CameraShake.Instance.ShakeCamera(4f, 0.1f);
        playerHealth.currentHealth -= enemyDamage;
        playerHealth.UpdatePlayerHealthBar();
        hurtAudio.Play();
    }
}
