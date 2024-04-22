using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform[] enemySpawns;
    public int maxEnemies;
    public float spawnDelay = 2f;
    private int totalEnemies;
    private List<GameObject> spawnedEnemies = new List<GameObject>(); // Initialize the list

    private Transform player; // Use Transform instead of GameObject

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // gets player tag
        StartCoroutine(SpawnEnemyRoutine()); // Start coroutine for spawning enemies
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (totalEnemies < maxEnemies)
        {
            GameObject enemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], enemySpawns[Random.Range(0, enemySpawns.Length)]);
            spawnedEnemies.Add(enemy);
            totalEnemies++;



            //randomize colour accents of enemies between red and blue
            Renderer renderer = enemy.GetComponent<Renderer>();
            
            Material material = renderer.material;
            
            Color randomColor = Random.ColorHSV(.75f, 1f, 1f, .5f, 0.95f, 1f); 
            
            material.color = randomColor;


            yield return new WaitForSeconds(spawnDelay); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach (GameObject enemy in spawnedEnemies)
        {
            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
            agent.SetDestination(player.position);
        }
    }
}

