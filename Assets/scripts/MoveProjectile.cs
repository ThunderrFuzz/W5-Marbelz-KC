using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : SpawnEnemies
{
    public float speed;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            spawnedEnemies.Remove(collision.gameObject);
            score.AddScore(10);
            totalEnemies--;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
