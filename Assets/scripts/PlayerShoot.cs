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
            GameObject focalpoint = FindObjectOfType<Camera>().transform.parent.gameObject;
            Vector3 spawnPosition = playerPos.position + new Vector3(xOffset, 0f, 0f);
            if (!doubleFire)
            {
                Instantiate(projectilePrefab, spawnPosition + focalpoint.transform.forward, focalpoint.transform.rotation);
            }
            else
            { 
                Vector3 spawnPosition2 = playerPos.position + new Vector3(-xOffset, 0f, 0f);
                Instantiate(projectilePrefab, spawnPosition + focalpoint.transform.forward, focalpoint.transform.rotation);
                Instantiate(projectilePrefab, spawnPosition2 + focalpoint.transform.forward, focalpoint.transform.rotation);
            }
        }
    }
}
