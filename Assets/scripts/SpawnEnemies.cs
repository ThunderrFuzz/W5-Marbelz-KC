using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnEnemies : PickupManager
{
    public GameObject[] enemyPrefab;
    public Transform[] enemySpawns;
    public int maxEnemies;
    public float spawnDelay = 2f;
    protected static int totalEnemies;
    protected List<GameObject> spawnedEnemies = new List<GameObject>();
    public float enemyHealth = 15;
    public GameObject fireParticleSystemPrefab; // Prefab of the fire particle system
    private int explosionForce = 5000;
    private Transform player;

    private GameObject firePrefab;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            if (totalEnemies < maxEnemies)
            {
                GameObject enemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], enemySpawns[Random.Range(0, enemySpawns.Length)]);
                spawnedEnemies.Add(enemy);
                totalEnemies++;

                // Randomize color accents of enemies between red and blue
                Renderer renderer = enemy.GetComponent<Renderer>();
                Material material = renderer.material;
                Color randomColor = Random.ColorHSV(.75f, 1f, 1f, .5f, 0.95f, 1f);
                material.color = randomColor;


            }
        }
    }

    void Update()
    {
        List<GameObject> enemiesCopy = new List<GameObject>(spawnedEnemies);
        foreach (GameObject enemy in enemiesCopy)
        {
            if (enemy == null)
            {
                spawnedEnemies.Remove(enemy);
            }
            else
            {
                NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                agent.SetDestination(player.position);


                if (onFire)
                {
                    if (enemy.transform.childCount == 0)
                    {
                        firePrefab = Instantiate(fireParticleSystemPrefab, enemy.transform.position + new Vector3(0f, .5f, 0f), Quaternion.identity);
                        firePrefab.transform.parent = enemy.transform;
                    }

                    enemyHealth -= .003f;
                }
                else
                {
                    if (enemy.transform.childCount != 0)
                    {
                        Destroy(enemy.transform.GetChild(0).gameObject);
                    }
                }
                if(nukeUsed)
                {
                    // nav mesh agent direction
                    Vector3 direction = agent.velocity.normalized;

                    // inverted direction(away from player)
                    Vector3 inverseDirection = -direction;

                    // add force away from player
                    agent.GetComponent<Rigidbody>().AddForce(inverseDirection * explosionForce * Time.deltaTime, ForceMode.Impulse);
                }


            }
        }
    }
}

