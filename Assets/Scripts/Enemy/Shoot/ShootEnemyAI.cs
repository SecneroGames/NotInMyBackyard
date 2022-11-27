using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootEnemyAI : MonoBehaviour
{
    [SerializeField] float dist;
    Transform target;
    NavMeshAgent enemy;
    Rigidbody rb;
    Animator anim;
    SpiderShooting spiderShooting;
    float attackDistance;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        attackDistance = GetComponent<NavMeshAgent>().stoppingDistance;

        spiderShooting = GetComponent<SpiderShooting>();
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
            anim.SetBool("Idle", true);
            spiderShooting.Shoot();
        }
        else
        {
            anim.SetBool("Idle", false);
        }   
    }
}
