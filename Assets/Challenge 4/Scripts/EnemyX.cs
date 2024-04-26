using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyX : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private SpawnManagerX spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManagerX>();
        speed += spawnManager.waveCount / 2;
        Debug.Log(speed + " Speed increased from wave count ");
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindGameObjectWithTag("PlayerGoal");
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (transform.position - playerGoal.transform.position ).normalized;
        foreach (GameObject enemy in spawnManager.spawnedEnemies)
        {

            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            if (agent == null) { spawnManager.spawnedEnemies.Remove(enemy); }
            else { agent.SetDestination(lookDirection); }
        }
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
            spawnManager.spawnedEnemies.Remove(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
            spawnManager.spawnedEnemies.Remove(gameObject);
        }

    }

}
