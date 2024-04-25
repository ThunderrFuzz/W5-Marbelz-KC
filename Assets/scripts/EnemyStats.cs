using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float impactForce;
    public float enemyHealth = 15;
    

    public void doDamage(float damage)
    {
        enemyHealth -= damage;
    }


}
