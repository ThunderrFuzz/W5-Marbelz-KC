using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Boss : EnemyStats
{
    public GameObject bossAttackPrefab;
    
    float maxhealth;
    // Start is called before the first frame update
    void Start()
    {
        //sets boss destination 
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        agent.SetDestination(player.transform.position);
        maxhealth = enemyHealth;
    }

    
    void Update()
    {
        
        if (enemyHealth % 10 == 1 || enemyHealth % 4 == 0)
        {
            // attack
            Instantiate(bossAttackPrefab);

            // delay 
            StartCoroutine(BossAttackDelay());
        }

        // if half health, perform "big" attack
        if (enemyHealth <= maxhealth / 2 )
        {
            // Spawn multiple attacks
            for (int i = 0; i < 15; i++)
            {
                Attack();
            }
        }
    }

    IEnumerator BossAttackDelay()
    {
        
        yield return new WaitForSeconds(1f);

        // 'Reset' attack state
        maxhealth = enemyHealth;
    }

    void Attack()
    {
        // spawn attack
        Instantiate(bossAttackPrefab, transform.position, Quaternion.identity, transform);
    }

}
