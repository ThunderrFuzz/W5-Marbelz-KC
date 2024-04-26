using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;

public class Nuke : SpawnEnemies
{
    public float explosionForce = 10000f;
    static EnemyStats stats;

    private void Start()
    {
         
    }
    void Update()
    {
        if (nukeUsed)
        {
            List<GameObject> enemiesCopy = new List<GameObject>(spawnedEnemies);
            foreach (GameObject enemy in enemiesCopy)
            {

                // other way theya re going - away from player
                Vector3 oppositeDirection = -enemy.GetComponent<NavMeshAgent>().velocity.normalized;
                
                enemy.GetComponent<NavMeshAgent>().enabled = false;
                //gets rigid body of agent
                Rigidbody agentRigidbody = enemy.GetComponent<Rigidbody>();
                if (agentRigidbody != null)
                {
                    agentRigidbody.AddForce(oppositeDirection * explosionForce, ForceMode.Impulse);
                    enemy.GetComponent<NavMeshAgent>().enabled = true;
                }
            }
        }
    }
}

