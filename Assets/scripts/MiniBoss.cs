using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniBoss : EnemyStats
{
    float MB_maxhealth;
    // Start is called before the first frame update
    void Start()
    {
        //sets boss destination 
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        agent.SetDestination(player.transform.position);
        MB_maxhealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
