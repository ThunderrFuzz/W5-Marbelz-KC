using System.Collections;
using System.Net.Sockets;
using System.Transactions;
using UnityEngine;



public class PickupManager : MonoBehaviour
{
    protected HealthManager healthManager;
    protected ScoreingSystem score;
    protected bool doubleFire = false;
    protected bool activeScoreX = false;
    public static bool onFire = false;
    protected bool speedBoost = false;
    protected bool nukeUsed = false;

    private void Start()
    {

        score = FindObjectOfType<ScoreingSystem>();
       
        healthManager = FindObjectOfType<HealthManager>();
    }


    void OnCollisionEnter(Collision collision)
    {

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

    void AddGemScore()
    {
        // error 

    }

    void ActivateFireEffect()
    {

        StartCoroutine(effectDuration(5f, () => onFire = false));


    }

    void AddMoney()
    {
        

    }

    void ExplodeEnemies()
    {
        StartCoroutine(effectDuration(1f, () => nukeUsed = false));
    }

    void ActivateSpeedup()
    {
        StartCoroutine(effectDuration(3f, () => speedBoost = false));
       
    }

    void ActivateSecret()
    {
        
        
       
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
