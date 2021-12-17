using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    
   // [SerializeField] float shootSoundRange = 10f;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 1f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity; // Enemy won't know where the player is, unlike there was = 0
    //float shotdist = Mathf.Infinity; // Enemy won't know where the player is, unlike there was = 0
    bool isProvoked = false; 
    EnemyHealth isDead;
    Transform target;

    //Shooting shotDistance;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        isDead = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
        //shotDistance = FindObjectOfType<Shooting>();
        
    }

    
    void Update()
    {
        if(isDead.IsDead())
       {
           enabled = false;
           navMeshAgent.enabled = false;
       }

       distanceToTarget = Vector3.Distance(target.position, transform.position);
       //shotdist = Vector3.Distance(target.position, shotDistance.lastShotPosition);
      
       
       if(isProvoked) EngageTarget();

       else if(distanceToTarget <= chaseRange) 
       {
            isProvoked = true;
            //navMeshAgent.SetDestination(target.position);
       }
       
        
    }

    public void OnDamage()
    {
        isProvoked = true;
    }
  

    void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        
    }
    void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("Move");
        GetComponent<Animator>().SetBool("Attack", false);
        navMeshAgent.SetDestination(target.position);
        
    
    }
    
    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,chaseRange);
    }

    
}
