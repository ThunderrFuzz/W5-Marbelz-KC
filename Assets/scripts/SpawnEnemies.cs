using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnEnemies : PickupManager
{
    public GameObject[] enemyPrefab;
    public Transform[] enemySpawns;
    public int maxEnemies;
    public float spawnDelay = 5f;
    protected static int totalEnemies;
    protected List<GameObject> spawnedEnemies = new List<GameObject>();

    public GameObject fireParticleSystemPrefab; // Prefab of the fire particle system
    int explosionForce = 5000;
    Transform player;
    public int waveCount;
    public GameObject minibossPrefab;
    public GameObject bossPrefab;
    public bool newWave;

    static bool miniBossNotSpawned = true;
    static bool bossNotSpawned = true;

    GameObject firePrefab;
    void Start()
    {
        waveCount = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;


    }


    IEnumerator waveDelay(System.Action action)
    {

        yield return new WaitForSeconds(spawnDelay);
        action();
    }
    void EnemySpawner()
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
                //sets enemy destination 
                NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                agent.SetDestination(player.position);

                //activate fire prefab when on fire 
                if (onFire)
                {
                    if (enemy.transform.childCount == 0)
                    {
                        firePrefab = Instantiate(fireParticleSystemPrefab, enemy.transform.position + new Vector3(0f, .5f, 0f), Quaternion.identity);
                        firePrefab.transform.parent = enemy.transform;
                    }
                    EnemyStats stats = enemy.GetComponent<EnemyStats>();
                    stats.enemyHealth -= .3f * Time.deltaTime;
                }
                else
                {
                    if (enemy.transform.childCount != 0)
                    {
                        Destroy(enemy.transform.GetChild(0).gameObject);
                    }
                }
                if (nukeUsed)
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

        if (totalEnemies == 0)
        {
            newWave = true;
            StartCoroutine(waveDelay(() => newWave = false));
            for (int i = 0; i < maxEnemies; i++)
            {

                EnemySpawner();

            }

            maxEnemies++;
            waveCount++;
        }

        bossCheck();
    }

    void bossCheck()
    {
        if (waveCount % 1 == 0)
        {
            // Spawn miniboss
            if (miniBossNotSpawned)
            {
                Instantiate(minibossPrefab, Vector3.zero, Quaternion.identity);
                miniBossNotSpawned = false;
            }
        }
        if (waveCount % 2 == 0)
        {
            // Spawn boss
            if (bossNotSpawned)
            {
                Instantiate(bossPrefab, Vector3.zero, Quaternion.identity);
                bossNotSpawned = false;
            }
        }
    }


}

