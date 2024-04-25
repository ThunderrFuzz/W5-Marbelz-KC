using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShoot : PickupManager
{
    public GameObject projectilePrefab;
    public Transform playerPos;
    public float xOffset = 0.65f;
    public float zOffset = 0.65f;
    public PickupManager _pm;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            
            Vector3 spawnPosition = playerPos.position + new Vector3(xOffset, 0f, 0f);
            if (!doubleFire)
            {
                Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            }
            else
            { 
                Vector3 spawnPosition2 = playerPos.position + new Vector3(-xOffset, 0f, 0f);
                Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
                Instantiate(projectilePrefab, spawnPosition2, Quaternion.identity);
            }
        }
    }
}
