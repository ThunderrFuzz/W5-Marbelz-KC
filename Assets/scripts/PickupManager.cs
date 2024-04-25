using System.Collections;
using System.Net.Sockets;
using System.Transactions;
using UnityEngine;



public class PickupManager : MonoBehaviour
{
    public static HealthManager healthManager;
    public static ScoreingSystem score;
    public GameObject[] pickups;

    /* static variables are needed here to prevent copies of them being made,
       and the value from THIS script gets parsed around correctly   
       these bools are used to toggle on and off the effects.
     */

    protected static bool onFire = false;
    protected static bool nukeUsed = false;
    protected static bool doubleFire = false;
    protected static bool activeScoreX = false;
    protected static bool speedBoost = false;
    protected static bool hasShield = false;
    int maxPickups = 10;
    int currPickups;
    float pickupTime;
    void Start()
    {
        //InvokeRepeating("spawnPickups", 2, 2);


        score = FindObjectOfType<ScoreingSystem>();
        
        healthManager = FindObjectOfType<HealthManager>();
        
    }
    private void Update()
    {
        
        pickupTime += Time.deltaTime;
        spawnPickups();
    }

    void spawnPickups()
    {
        SpawnEnemies enemyM = FindObjectOfType<SpawnEnemies>();  
        if (currPickups < maxPickups || pickupTime % 30f == 0 || enemyM.newWave)
        {
            Instantiate(pickups[Random.Range(0, pickups.Length)], Random_Pickup_spawnpoint_in_Bounds("PickupSpawns"), Quaternion.Euler(Vector3.zero));
            currPickups++;
        }
    }
    Vector3 Random_Pickup_spawnpoint_in_Bounds(string tag)
    {
        // find collider with tag
        GameObject objectWithTag = GameObject.FindGameObjectWithTag(tag);

        Collider collider = objectWithTag.GetComponent<Collider>();


        // bounds of chosen collider 
        Bounds bounds = collider.bounds;

        // creates a random point
        Vector3 randomPoint = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            -1.5f,
            Random.Range(bounds.min.z, bounds.max.z)
        );
        return randomPoint;
    }




    void OnCollisionEnter(Collision collision)
    {
        pickupTime = 0;
        currPickups--;
        switch (collision.gameObject.tag)
        {
            case "DoubleFire":
                doubleFire = true;
                //destroy pickup
                Destroy(collision.gameObject);
                //active effect
                ActivateDoubleFire();
                break;


            case "HealthPot":
                Destroy(collision.gameObject);

                AddHealth();
                break;

            case "ScoreMulti":
                Destroy(collision.gameObject);
                activeScoreX = true;
                ActivateScoreMultiplier();
                break;

            case "GemCollectable":
                Destroy(collision.gameObject);
                //AddGemScore();
                score.AddScore(500);
                break;

            case "Fire":
                Destroy(collision.gameObject);
                onFire = true;
                ActivateFireEffect();
                break;

            case "Money":
                Destroy(collision.gameObject);
                if (score == null) { Debug.LogWarning("Couldn't find score system inside money collisionenter "); }
                score.AddCash(500);
                //AddMoney(); //error
                break;

            case "Nuke":
                nukeUsed = true;
                Destroy(collision.gameObject);
                ExplodeEnemies();
                break;

            case "Speedup":
                speedBoost = true;
                Destroy(collision.gameObject);
                ActivateSpeedup();
                break;

            case "Secret":
                Destroy(collision.gameObject);
                score.secret();
                //ActivateSecret();// error 
                break;
            case "Shield":
                hasShield = true;
                Destroy(collision.gameObject);
                activateShield();
                break;


            default:
                // if tag does nothing, do nothing....
                break;
        }
    }


    void ActivateDoubleFire()
    {

        // start timer
        StartCoroutine(effectDuration(5f, () => doubleFire = false));
    }

    void AddHealth()
    {
        healthManager.Heal(45);
        Debug.Log("HealthPot collected: +45 HP");
    }

    void ActivateScoreMultiplier()
    {
        StartCoroutine(effectDuration(5f, () => activeScoreX = false));
        Debug.Log("ScoreMultiplier activated: Double score for 30 seconds");
    }



    void ActivateFireEffect()
    {

        StartCoroutine(effectDuration(5f, () => onFire = false));


    }



    void ExplodeEnemies()
    {
        StartCoroutine(effectDuration(.5f, () => nukeUsed = false));
    }

    void ActivateSpeedup()
    {
        StartCoroutine(effectDuration(3f, () => speedBoost = false));

    }
    void activateShield()
    {
        StartCoroutine(effectDuration(15f,() => hasShield = false));
    }


    IEnumerator effectDuration(float duration, System.Action action)
    {
        yield return new WaitForSeconds(duration);
        action();
    }



}


/*
 tags & effect 
ScoreMulti : doubles score for 30 seconds DONE - works
DoubleFire  : shoot 2  times projectiles at once  30 seconds DONE WORKS
Fire  :  adds damage over time to enemies  DONE WORKS
HealthPot : gives 45 hp more lives  DONE WORKS
Speedup : doubles movement speed for 5 seconds  DONE WOKRS



GemCollectable : +250 score DONE ALMOST WORKS
Money : adds 500 Money DONE ALMOST WORKS
Nuke : explodes!!! this needs to add force to every enemy  DONE NOT WORKING
Secret  :  doubles final score - DONE NOT WOKRING
 
 
 */
