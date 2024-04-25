using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : PickupManager
{
    public GameObject shieldPrefab;
    GameObject shieldInstance;
    PlayerMove player;
    
    public int shieldHealth = 5;

    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        

        if (hasShield)
        {
            
            if (player.transform.childCount == 0)
            {
                shieldInstance = Instantiate(shieldPrefab, player.transform.position, player.transform.rotation);
                shieldInstance.transform.parent = player.transform;
            }
            if (shieldHealth <= 0)
            {
                hasShield = false;
                DestroyShield();
            }
        }
        else
        {
            DestroyShield();
        }
    }

    private void DestroyShield()
    {
        if (player.transform.childCount != 0)
        {
            Destroy(player.transform.GetChild(0).gameObject);
        }
    }

   
}
