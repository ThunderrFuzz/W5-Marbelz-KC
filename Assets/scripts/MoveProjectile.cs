using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : SpawnEnemies
{
    public float speed;
    EnemyStats stats;

    private void Start()
    {
        stats = FindObjectOfType<EnemyStats>();
    }
    // Update is called once per frame
    void Update()
    {
        GameObject focalpoint = FindObjectOfType<Camera>().transform.parent.gameObject;
        transform.Translate(focalpoint.transform.position * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            
            
            Destroy(gameObject);
            stats.doDamage(3);
           
            
            if(stats.enemyHealth < 0)
            {
                spawnedEnemies.Remove(collision.gameObject);
                Destroy(collision.gameObject);
                totalEnemies--;
                score.AddScore(30);
            }
            
           
        }
    }
}
